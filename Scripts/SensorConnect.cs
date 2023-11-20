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

public class SensorConnect : MonoBehaviour
{
    public GameObject hololens2;
    public GameObject tofCamera;
    //public GameObject[] card;
    public GameObject tofPic;

    static string localIP = "127.0.0.1";
    static int localPort = 50001;
    static IPAddress localAddress = IPAddress.Parse(localIP);
    IPEndPoint localEP = new IPEndPoint(localAddress, localPort);

    static UdpClient udp;
    IPEndPoint remoteEP = null;

    void Start()
    {
        // �\�P�b�g����
        Socket socket = new Socket(localAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        // �ڑ�
        socket.Connect(localEP);
        Debug.Log("Success, now connect!");

        // ���M
        var data = Encoding.UTF8.GetBytes("Start");
        // �]������f�[�^�̒�����big�G���f�B�A���ŕϊ����ăT�[�o�ő���B(4byte)
        socket.Send(BitConverter.GetBytes(data.Length));
        socket.Send(data);

        //�\�P�b�g�I��
        socket.Shutdown(SocketShutdown.Both);
        socket.Close();


        int LOCA_LPORT = 50001;

        udp = new UdpClient(LOCA_LPORT);
        udp.Client.ReceiveTimeout = 2000;
    }

    void Update()
    {
        IPEndPoint remoteEP = null;
        byte[] data = udp.Receive(ref remoteEP);
        string text = Encoding.UTF8.GetString(data);
        Debug.Log(text);

        Ray ray = new Ray(tofCamera.transform.position, tofCamera.transform.forward); // Ray�𐶐�;
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) // ����Ray�𓊎˂��ĉ��炩�̃R���C�_�[�ɏՓ˂�����
        {
            if (hit.collider.CompareTag("Card")) // �^�O���r
            {

                // ���W���擾
                Vector3 cardPos = tofPic.transform.localPosition;      // HoloLens2����AR�J�[�h�܂ł̃x�N�g��
                Vector3 sensorPos = tofCamera.transform.localPosition;  // HoloLens2����ToF�Z���T�܂ł̃x�N�g��
                Vector3 sensorToCard = Vector3.Normalize(cardPos - sensorPos); // ToF�Z���T����AR�J�[�h�܂ł̐��K���x�N�g��

                /* �Z���T��AR�J�[�h�̋������擾 */
                float disSentoCard = float.Parse(text);

                // HoloLens2����AR�J�[�h�܂ł̃x�N�g��
                cardPos = sensorPos + sensorToCard * disSentoCard;
            }
        }
    }
}


