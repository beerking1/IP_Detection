using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP_Detection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CheckFormat());
            Console.ReadKey();
        }
        static string ip;
        private static int[] octets = new int[4];
        private static bool status = false;
        public static string CheckFormat()
        {
            Console.Write("Zadej validní IP adresu: ");
            ip = Console.ReadLine();
            string[] splitIp = ip.Split('.');
            if (splitIp.Length != 4) 
            {
                return "Zadaná IP nemá 4 oktety.";
            }
            for (int i = 0; i < octets.Length; i++)
            {
                if (int.TryParse(splitIp[i], out octets[i]))
                {
                    status = true;
                }
                else
                {
                    status = false;
                    break;
                }
                if (octets[i] < 0 || octets[i] > 255)
                {
                    status = false;
                    break;
                }
            }
            return DetectionIP();
        }
        public static string DetectionIP()
        {
            if (status == false)
            {
               return "Zadaná IP obsahuje oktety mimo rozsah.";
            }            
            
            if (((octets[0] == 10) && // first segment
                (octets[1] >= 0) && 
                (octets[1] <= 255) && 
                (octets[2] >= 0) && 
                (octets[2] <= 255) && 
                (octets[2] >= 0) && 
                (octets[2] <= 255)) || 
                ((octets[0] == 172) && // second segment
                (octets[1] >= 16) && 
                (octets[1] <= 31) && 
                (octets[2] >= 0) && 
                (octets[2] <= 255) && 
                (octets[3] >= 0) && 
                (octets[3] <= 255)) || 
                ((octets[0] == 192) && // third segment
                (octets[1] == 168) && 
                (octets[2] >= 0) && 
                (octets[2] <= 255) && 
                (octets[3] >= 0) && 
                (octets[3] <= 255)))
            {
                return $"Tato IP adresa ({ip}) je soukromá.";
            }
            return $"Tato IP adresa ({ip}) je veřejná.";
        }
    }
}
