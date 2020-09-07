using Microsoft.Owin.Hosting;
using System;
using ECIT.GIS.WebService;
namespace ConsoleApp1
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9003/";
            Microsoft.Owin.Hosting.WebApp.Start<Startup>(url: baseAddress);
            Console.WriteLine("程序已启动,按任意键退出");
            Console.ReadLine();
        }
    }
}