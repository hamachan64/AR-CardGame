using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System;
using System.IO;
using UnityEngine.SocialPlatforms;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.InputSystem.HID;

/*void TcpConnect()
{
    static string localIP = "127.0.0.1";
    static int localPort = 50001;
    static IPAddress localAddress = IPAddress.Parse(localIpString);
    IPEndPoint localEP = new IPEndPoint(localAddress, localPort);

    // ソケット生成
    Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

    // 接続
    socket.Connect(localEP);
    Debug.Log("Success, now connect!");

    // 送信
    var data = Encoding.UTF8.GetBytes("Start");
    // 転送するデータの長さをbigエンディアンで変換してサーバで送る。(4byte)
    socket.Send(BitConverter.GetBytes(data.Length));
    socket.Send(data);

    //ソケット終了
    socket.Shutdown(SocketShutdown.Both);
    socket.Close();
}*/

public class SensorConnect : MonoBehaviour
{
    public GameObject hololens2;
    public GameObject tofCamera;
    //public GameObject[] card;
    public GameObject tofPic;
    //Boolean tofKing;

    //Vector3 direction = new Vector3(0, 0, 1); // X軸方向を表すベクトル


    static string localIP = "127.0.0.1";
    static int localPort = 50001;
    static IPAddress localAddress = IPAddress.Parse(localIP);
    IPEndPoint localEP = new IPEndPoint(localAddress, localPort);

    static UdpClient udp;
    IPEndPoint remoteEP = null;

    void Start()
    {
        // ソケット生成
        Socket socket = new Socket(localAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        // 接続
        socket.Connect(localEP);
        Debug.Log("Success, now connect!");

        // 送信
        var data = Encoding.UTF8.GetBytes("Start");
        // 転送するデータの長さをbigエンディアンで変換してサーバで送る。(4byte)
        socket.Send(BitConverter.GetBytes(data.Length));
        socket.Send(data);

        //ソケット終了
        socket.Shutdown(SocketShutdown.Both);
        socket.Close();


        int LOCA_LPORT = 50001;

        udp = new UdpClient(LOCA_LPORT);
        udp.Client.ReceiveTimeout = 2000;

        //tofKing = card[0].GetComponent<Renderer>().enabled;
        //tofKing = false;
    }

    void Update()
    {
        IPEndPoint remoteEP = null;
        byte[] data = udp.Receive(ref remoteEP);
        string text = Encoding.UTF8.GetString(data);
        Debug.Log(text);

        Ray ray = new Ray(tofCamera.transform.position, tofCamera.transform.forward); // Rayを生成;
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) // もしRayを投射して何らかのコライダーに衝突したら
        {
            if (hit.collider.CompareTag("Card")) // タグを比較
            {
                //tofKing = true;

                // 座標を取得
                Vector3 cardPos = tofPic.transform.localPosition;      // HoloLens2からARカードまでのベクトル
                Vector3 sensorPos = tofCamera.transform.localPosition;  // HoloLens2からToFセンサまでのベクトル
                Vector3 sensorToCard = Vector3.Normalize(cardPos - sensorPos); // ToFセンサからARカードまでの正規化ベクトル

                /* センサとARカードの距離を取得 */
                float disSentoCard = float.Parse(text);

                // HoloLens2からARカードまでのベクトル
                cardPos = sensorPos + sensorToCard * disSentoCard;
            }
        }
        /*else if (tofKing)
        {
            tofKing = false;
        }*/

    }
}


