//See https://aka.ms/new-console-template for more information
using NetTools;
using System.Net;

//Console.WriteLine("Hello, World!");
//string a;
//a = Console.ReadLine();
//Console.WriteLine(a);

List<IPAddress> IpAddressList = new List<IPAddress>();

foreach (var ip in IPAddressRange.Parse("192.168.17.1" + "/" + "255.255.255.0"))
{
    Console.WriteLine(ip.ToString());
}
