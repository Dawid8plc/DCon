using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DConExec
{
    class Program
    {

        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";

        static void Main(string[] args)
        {
            

            

            Start();
            
            void Start()
            {



                try
                {
                    Console.WriteLine("What do you want to do?");
                    if (Console.ReadLine() == "Client")
                    {
                        Client();
                    }
                    else
                    {
                        StartServer();
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("An error has occured");
                    Console.WriteLine(ex);
                    Start();
                }
            }





            void StartServer()
            {
                Console.WriteLine("Starting up the server...");
                //---listen at the specified IP and port no.---
                IPAddress localAdd = IPAddress.Parse(SERVER_IP);
                TcpListener listener = new TcpListener(localAdd, PORT_NO);
                Console.WriteLine("Listening...");
                listener.Start();

                //---incoming client connected---
                TcpClient client = listener.AcceptTcpClient();

                //---get the incoming data through a network stream---
                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];

                //---read incoming stream---
                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                //---convert the data received into a string---
                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received : " + dataReceived);

                //---write back the text to the client---
                bool keeponchatting = true;
                while (keeponchatting)
                {
                    Console.WriteLine("Sending back : " + Console.ReadLine());
                    nwStream.Write(buffer, 0, bytesRead);
                }
                //client.Close();
                //listener.Stop();
                
            }

            void Client()
            {
                

                Console.WriteLine("Starting up the client...");
                //---data to send to the server---


                //---create a TCPClient object at the IP and port no.---
                TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
                NetworkStream nwStream = client.GetStream();

                //Thread thread = new Thread(ReadChatC(client, nwStream));
                thread.Start();

                bool keeponchatting = true;
                while (keeponchatting)
                {
                    if(Console.In == null)
                    {
                       
                    }
                    //---send the text---
                    string potato = Console.ReadLine();
                    Console.WriteLine("Sending : " + potato);
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(potato);
                    nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                    
                }

                //---read back the text---
               
                Console.ReadLine();
                //Client();
                //client.Close();
            }
             void ReadChatC(TcpClient client, NetworkStream nwStream)
            {
                byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            }

        }

        

        


    }
}
