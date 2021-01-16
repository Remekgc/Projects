using System;
using System.IO;
using System.IO.Pipes;
using System.Text;

class PipeClient
{
    static void Main(string[] args)
    {
        using (NamedPipeClientStream pipeClient =
            new NamedPipeClientStream(".", "hole_pipe", PipeDirection.InOut))
        {
            Console.WriteLine("Attempting to connect to pipe...");
            pipeClient.Connect();

            try
            {
                using (BinaryWriter _bw = new BinaryWriter(pipeClient))
                using (BinaryReader _br = new BinaryReader(pipeClient))
                {
                    while (true)
                    {
                        #region Writer
                        //Console.WriteLine("Your message:");
                        //byte[] buf = Encoding.ASCII.GetBytes(Console.ReadLine());
                        //string responseData = Encoding.ASCII.GetString(buf);

                        //_bw.Write((uint)buf.Length);
                        //_bw.Write(buf);
                        //Console.WriteLine("Let's hear from the server now..");
                        #endregion
                        #region Reader
                        int len = _br.Read(new byte[1000], 0, 1000);

                        string serverMessage = Encoding.ASCII.GetString(_br.ReadBytes(len));

                        Console.WriteLine();
                        Console.WriteLine("Received from client: {0}", serverMessage);
                        #endregion
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }

        }
        Console.Write("Press Enter to continue...");
    }
}