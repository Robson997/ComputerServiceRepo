using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerService.Models
{
    public class Logic
    {

        public List<string> AllResult { get; set; }

        public string[] Ar0 = new string[] { "2", "1", "1", "1", "1", "1", "1" };
        public string[] Ar1 = new string[] { "1", "2", "1", "1", "1", "1", "1" };
        public string[] Ar2 = new string[] { "1", "1", "1", "1", "1", "2", "1" };
        public string[] Ar3 = new string[] { "2", "2", "2", "2", "2", "2", "2" };
        public string[] Ar4 = new string[] { "1", "2", "2", "2", "2", "2", "2" };
        public string[] Ar5 = new string[] { "1", "1", "2", "2", "2", "2", "2" };
        public Logic()
        {
            AllResult = new List<string>()
            {
                "If the PC does not start, first check that the power supply is turned on and connected to the mains." +
                " Recheck all plugs and cables inside the computer." +
                " Disconnect all non-essential components from the motherboard.",
                "It may be helpful to restart the router and analyze the lights on it " +
                "(usually one of them informs about the status of the Internet connection). " +
                "If the router connects correctly to our ISP's network and the user still " +
                "has no access, please contact the ISP.",                
                "Option3",
                "Option4",                
                "Option5",
                "Unfortunetly we havent any idea about slove your problem with your PC" +
                "Please try to contact with our Service - phone number: 666 777 888",

            };
        }


    }
}
