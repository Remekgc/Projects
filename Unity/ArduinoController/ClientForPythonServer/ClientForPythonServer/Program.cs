using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{

    class Program
    {
        private static TcpClient client;

        // Main Method 
        static void Main(string[] args)
        {
            Console.WriteLine("Client Started");

            ConnectToServer(); //While loop for server connection
            ReadServerMessanges(); //While loop to read data
        }

        private static void ConnectToServer()
        {
            bool connected = false; //connection status
            while (!connected) //If not connected
            {
                try
                {
                    client = new TcpClient(); //creatring new tcp client on the heap
                    client.Connect(Dns.GetHostName(), 1234); //Connect to server [Hostname] port [1234]
                    Console.WriteLine("Connection established");
                    connected = true;
                }
                catch (Exception x)
                {
                    Console.WriteLine("Failed to connect");
                    Console.WriteLine(x);
                    connected = false;
                    Console.WriteLine("\n\n!Restablishing connection in 5 seconds!\n\n");
                    Thread.Sleep(5000); //Try again in 5 sek
                }
            }
        }

        private static void ReadServerMessanges()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[1000]; // Allocate data for server messange
                    Int32 bytes = client.GetStream().Read(data, 0, data.Length); // Get byte sream from client - buffer, offset, size
                    string responseData = Encoding.ASCII.GetString(data, 0, bytes); // Convert Bytes to string - bytes, index, count 
                    Console.WriteLine("Server msg: " + responseData); // Check msg format
                    DisplayMessange(responseData); // set up data to display
                }
                catch (Exception x)
                {
                    Console.WriteLine("Could not read data:");
                    Console.WriteLine(x);
                    Console.WriteLine("\n\n!Restablishing connection!\n\n");
                    Thread.Sleep(5000);
                    client.Close();
                    ConnectToServer(); // try reconectring
                }
            }

        }

        private static void DisplayMessange(string DataToDecode)
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
                    Console.WriteLine(temp);
                    DecodedData.Add(float.Parse(temp));
                    temp = "";
                }
            }

            Console.WriteLine("Decoded Data:");
            foreach (var item in DecodedData)
            {
                Console.WriteLine(item);
            }
        }
    }
}