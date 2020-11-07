
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Alge.Procedures
{
    public static class ListHelper
    {
       
        public static void AddKey(ref List<String> list1,ref List<String> list2,string value1,string value2)
        {
            list1.Add(value1);
            list2.Add(value2);
        }

        public static void AddKey(ref List<int> list1, ref List<int> list2, int value1, int value2)
        {
            list1.Add(value1);
            list2.Add(value2);
        }
       
    }
}