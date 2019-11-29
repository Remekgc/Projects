using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ArduinoAccelerometer
{
    public class BallController : MonoBehaviour
    {
        private TcpClient client;
        private Thread connector;
        private Thread reciver;

        [SerializeField]
        private bool connected = false;
        [SerializeField]
        private float nextConnCheck, a, b;
        public int test = 0;

        // Use this for initialization
        void Start()
        {
            nextConnCheck = Time.time + 10f;
            connector = new Thread(ConnectToServer);
            reciver = new Thread(ReadServerMessanges);

            connector.Start();
        }

        // Update is called once per frame
        void Update()
        {
            if (nextConnCheck < Time.time && connected == false)
            {
                if (connector.IsAlive == true)
                {
                    nextConnCheck = 10f + Time.time; // If thread is still rurning add 10sek
                }
                else
                {
                    connector = new Thread(ConnectToServer);
                    connector.Start();
                }    
            }
            else if(connected)
            {
                if (reciver.IsAlive == false)
                {
                    reciver.Start();
                }
            }
            transform.Translate(a/100, 0, b/100);
        }
        void ConnectToServer()
        {
            test += 5;
            try
            {
                client = new TcpClient(); //creatring new tcp client on the heap
                client.Connect(Dns.GetHostName(), 1234); //Connect to server [Hostname] port [1234]
                print("Connection established");
                connected = true;
            }
            catch (Exception x)
            {
                print("Failed to connect");
                print(x);
                print("Restablishing connection");
            }
        }

        void ReadServerMessanges()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[1000]; // Allocate data for server messange
                    Int32 bytes = client.GetStream().Read(data, 0, data.Length); // Get byte sream from client - buffer, offset, size
                    string responseData = Encoding.ASCII.GetString(data, 0, bytes); // Convert Bytes to string - bytes, index, count 
                    DisplayMessange(responseData); // set up data to display
                }
                catch (Exception x)
                {
                    connected = false;
                    print("Could not read data:");
                    print(x);
                    print("!Restablishing connection!");
                    client.Close();
                    Thread.Sleep(5000);
                }

            }

        }

        private void DisplayMessange(string DataToDecode)
        {
            string temp = "";
            List<float> DecodedData = new List<float>();

            foreach (var item in DataToDecode)
            {
                if (item != ',') // data from server is devided by , so every char from x to ',' is assgined to temp string
                {
                    temp += item;
                }
                else // if item(char) = ',' then we cut the string, add temp to the list and convert it in the way
                {
                    print(temp);
                    DecodedData.Add(float.Parse(temp));
                    temp = "";
                }
            }

            a = DecodedData[0];
            b = DecodedData[1];
            print("Decoded Data:");
            foreach (var item in DecodedData)
            {
                print(item);
            }
        }

        void OnDestroy()
        {
            print("Closing threads");
            connector.Abort();
            reciver.Abort();
            client.Close();
        }
    }

}
