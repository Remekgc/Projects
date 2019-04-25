using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CoffeShop
{
    class FileManager
    {
        public static string path = @"Receipt.txt";

        public static void CreateFile(string fileData)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(fileData);
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        public static void ReadFile()
        {
            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        


    }
}
