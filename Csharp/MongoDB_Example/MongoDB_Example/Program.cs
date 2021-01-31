using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string user, password, databaseName, serverAddress;

            Console.WriteLine("Enter user:");
            user = Console.ReadLine();
            Console.WriteLine("Enter pass:");
            password = Console.ReadLine();
            Console.WriteLine("Enter server address:");
            serverAddress = Console.ReadLine();
            Console.WriteLine("Enter database:");
            databaseName = Console.ReadLine();


            Thread mongoConnection = new Thread(() => TestMongoConnection(user, password, serverAddress, databaseName));
            mongoConnection.Start();

            Console.WriteLine("press any key to exit");
            Console.ReadKey();

            mongoConnection.Abort();
        }

        static void TestMongoConnection(string user, string password, string serverAddress, string databaseName)
        {
            var client = new MongoClient($"mongodb+srv://{user}:{password}@{serverAddress}/{databaseName}?retryWrites=true&w=majority");
            var database = client.GetDatabase("test");

            Console.WriteLine(client.Cluster);
            Console.WriteLine(database.Client);
        }
    }
}
