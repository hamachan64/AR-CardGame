#python送信側
import socket
import random
import time
import serial

# Hololensと接続が可能か最初にTCPで通信する関数
def receive_tcp_start_signal():
    tcp_host = '127.0.0.1'
    tcp_port = 50001

    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as tcp_socket:
        tcp_socket.bind((tcp_host, tcp_port))   # 作成したソケットオブジェクトにIPアドレスとポートを紐づける
        tcp_socket.listen(1)                    # 作成したオブジェクトを接続可能状態にする
        print("HoloLens2からの接続待機中...")
        conn, addr = tcp_socket.accept()        # クライアントと接続する

        with conn:
            print("HoloLens2からTCP接続が確立されました")
            data = conn.recv(1024).decode('utf-8')      # データを受信する

            if data == 'Start':
                print("success")
                tcp_socket.close()

# 得られた数値データ4マスの平均の値を求めて，距離に直す関数
def average_and_distance(lu, ru, ld, rd):
    ave = (lu + ru + ld + rd) / 4
    distance = 0.004 * (ave ** 2) - 0.017 * ave
    return distance


HOST = '127.0.0.1'
PORT = 50001

receive_tcp_start_signal()
#client = socket.socket(socket.AF_INET, socket.SOCK_STREAM) TCP通信

client = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

port = 'COM5'
ser = serial.Serial(port, 115200)
if not ser.isOpen():
    ser.open()
ser.write(b'AT+DISP=3\r')
ser.write(b'AT+FPS=1\r')
ser.write(b'AT+UNIT=0\r')

if __name__ == '__main__':
    #initial = False
    while True:
        ser.read_until(b'\x00\xff')

        packet_length = int.from_bytes(ser.read(2), 'little')
        # print(f'packet length: {packet_length}')
        other = ser.read(16)
        image_frame = ser.read(packet_length-16)
        check = ser.read(1)
        end = ser.read(1)
        #print(image_frame[5050])
        num = str(average_and_distance(image_frame[5050], image_frame[5051], image_frame[5150], image_frame[5151]))
        print(num)
        client.sendto(num.encode('utf-8'),(HOST,PORT))
        #client.sendto(image_frame.encode('utf-8'),(HOST,PORT))