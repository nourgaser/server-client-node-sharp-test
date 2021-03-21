using System;
using WebSocket4Net;

namespace Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebSocket ws = new WebSocket("ws://localhost:8080/");
            ws.Opened += (sender, e) =>
            {
                ws.Send("Hello node! :)");
            };
            ws.Closed += (sender, e) =>
            {
                ws.Send("Bye node! :)");
            };
            ws.MessageReceived += (sender, e) =>
            {
                ws.Send("Got it node! You said: " + e.Message);
                Console.WriteLine("Received: " + e.Message);
                
            };

            try
            {
                ws.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
