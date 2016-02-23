using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Algo_proj_01.Properties;

namespace Algo_proj_01
{
    class Program
    {

        //todo this code works. Create objects(probably a struct) for subarrays to contain just low, high and sum and return that instead of an array
        static void Main(string[] args)
        {
            // create a static array to test data with..
           // int[] testaData = {13,-3,-25,20,-3,-16,-23,18,20,-7,12,-5,-22,15,-4,7};
            Dictionary<string, string> allData = getAllData();
            var data = Resources.MaxSubArray_29;
            var bleh = data.Trim()
                .Replace("\r\n", "")
                .Split(',')
                .Where(f => !string.IsNullOrEmpty(f))
                .Select(d => Convert.ToInt32(d))
                .ToArray();
            var answer = Utility.FindMaximumSubArray(bleh, 0, bleh.Length - 1);
            Console.Write(answer.ToString());


           
           
           
        }

        public static Dictionary<string, string> getAllData()
        {
            Dictionary<string, string> resourceData = new Dictionary<string, string>();
            ResourceSet resourceSet = Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                var resourceKey = entry.Key;
                var resourceValue = entry.Value;
                resourceData.Add(resourceKey.ToString(), resourceValue.ToString());
            }

            return resourceData;
        }
    }


  
    public struct SubArray
    {
        public int Low { get; set; }
        public int High { get; set; }
        public int  Sum { get; set; } // the sum of Low + High

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CSCI 5330 Spring 2016\r\n");
            sb.Append("David Lewis\r\n");
            sb.Append("900732205\r\n\r\n");
            sb.Append("Running data for file TextBookData.csv\r\n");
            sb.Append(string.Format("{0}= {1}\r\n", "Low", Low));
            sb.Append(string.Format("{0}= {1}\r\n", "High", High));
            sb.Append(string.Format("{0}= {1}\r\n", "Max", Sum));

            return sb.ToString();
        }


    }
}
