using System;
using System.Linq;
using Microsoft.WindowsAzure;
using System.Collections.Generic;
using Microsoft.ServiceBus.Messaging;

namespace ServiceBusDemo.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = CloudConfigurationManager.GetSetting("ServiceBusConnection");

            QueueClient client = QueueClient.CreateFromConnectionString(connectionString, "imports");

            while (true)
            {
                var message = client.Receive();
                if (message != null)
                {
                    try
                    {
                        MainExtracted(message);

                        message.Complete();
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex);
                        message.Abandon();
                    }
                }

            }
        }
        private static void MainExtracted(BrokeredMessage message)
        {
            Console.WriteLine("Body:" + message.GetBody<string>());
            Console.WriteLine("Properties:");
            foreach (var property in message.Properties)
            {
                Console.WriteLine(String.Format("\t{0}: {1}", property.Key, property.Value));
            }
        }
    }
}
