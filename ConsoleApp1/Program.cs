//See https://aka.ms/new-console-template for more information
using System.Net;
using IPAddresses;

//Console.WriteLine("Hello, World!");
//string a;
//a = Console.ReadLine();
//Console.WriteLine(a);

List<IPAddress> IpAddressList = IpAdressesClass.GetUsableIPForSubnet("192.168.15.1", "255.255.240.0");

foreach (var ip in IpAddressList)
{
    Console.WriteLine(ip);
}
