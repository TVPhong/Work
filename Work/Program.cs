using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Net.Http.Formatting;

namespace Work
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result =  WebProxyHelper.GetAuthenticatedResponse();
            Console.WriteLine(result);
            
        }
    }

}
