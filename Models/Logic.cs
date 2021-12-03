using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerService.Models
{
    public class Logic
    {

        public List<string> AllResult { get; set; }//List off all possible result
        public List<string> Result { get; set; }//List of Result
        public string[] Ar0;
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
                "You should buy new one",
                "You should buy extra RAM or",
                "Contact with our best specialists",
                "Maybe clean your computer inside or buy a new cooling",
                "Upload a new Drivers or check out your plug in",
                "Unfortunetly we havent any idea about slove your problem with your PC" +
                "Please try to contact with our Service - phone number: 666 777 888",

            };
            Result = new List<string>();
            Ar0 = new string[] { "1", "1", "1", "1", "1", "1", "1" };//case with all answes are "no"
        }


    }
}
