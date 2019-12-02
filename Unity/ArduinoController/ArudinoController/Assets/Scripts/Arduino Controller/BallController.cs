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
        private TcpClient client; // creating local client
        private Thread connector; // connector thread to establish connection without lagging Unity
        private Thread reciver; // Reciver thread that changes a and b values simultaneously with the main unity thread

        [SerializeField]
        private bool connected = false;
        [SerializeField]
        private float nextConnCheck, a, b; // nectConnCheck is the time for next check of connection, a and b are values for transform.Translate(a/100, 0, b/100);

        // Use this for initialization
        void Start()
        {
            nextConnCheck = Time.time + 10f; // check connection after 10 sek
            connector = new Thread(ConnectToServer); // assigning new trhead with ConnectToServer function to Connector
            reciver = new Thread(ReadServerMessanges); // assigning new thread with ReadServerMessanges function to reciver

            connector.Start(); // start connector thread;
        }

        // Update is called once per frame
        void Update()
        {
            ManageConnection();

            transform.Translate(a * Time.deltaTime, 0, b * Time.deltaTime); // change ball possition by a and b values.
        }

        private void ManageConnection()
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
            else if (connected) // if connection has been made
            {
                if (reciver.IsAlive == false)
                {
                    reciver.Start(); //start reciver thread.
                }
            }
        }

        void ConnectToServer()
        {
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
                    Thread.Sleep(5000); // try again after 5 sec.
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
            //Uncomment to see the values in inspector console
            /* 
            foreach (var item in DecodedData)
            {
                print(item);
            }
            */
        }

        void OnDestroy()
        {
            //Clear threads to be secure - not required.
            print("Closing threads");
            connector.Abort();
            reciver.Abort();
            client.Close();
        }
    }

}
