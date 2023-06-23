using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NetTools;

namespace IPAddresses
{
    /// <summary>
    /// Klasa, która zawiera w sobie funkcje generujące listy wszystkich adresów IP dla podsieci wraz z adresem sieci i broadcatem lub bez
    /// </summary>
    public class IpAdressesClass
    { 
        /// <summary>
        /// Funkcja generuje listę wszystkich adresów IP dla podsieci - przekazanego przez networkAddress adresu IP o przekazanej przez maskAddress masce (wraz adresem sieci i broadcastem, czyli pierwszym i ostatnim wygenerowanym w foreach)
        /// </summary>
        public static List<IPAddress> GetIPListForSubnet(string networkAddress, string maskAddress)
        {
            List<IPAddress> IpAddressList = new List<IPAddress>();

            foreach (var ip in IPAddressRange.Parse(networkAddress + "/" + maskAddress))
            {
                IpAddressList.Add(ip);
            }
            return IpAddressList;
        }


        /// <summary>
        /// Funkcja usuwa pierwszy i ostatni adres (adres sieci i broadcast) z wygenerowanej przez funkcję GetIPListForSubnet listy.
        /// </summary>
        public static List<IPAddress> GetUsableIPForSubnet(string networkAddress, string maskAddress)
        {
            List<IPAddress> IpAddressList = GetIPListForSubnet(networkAddress, maskAddress);

            IpAddressList.RemoveAt(0);
            IpAddressList.RemoveAt(IpAddressList.Count - 1);

            return IpAddressList;
        }

    }
}
