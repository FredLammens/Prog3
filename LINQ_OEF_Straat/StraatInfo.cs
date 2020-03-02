using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LINQ_OEF_Straat
{
    class StraatInfo
    {
        public string straat { get; set; }
        public string gemeente {get;set;}
        public string provincie{get;set;}
        public StraatInfo(string provincie, string gemeente, string straat) => (this.provincie, this.gemeente, this.straat) = (provincie,gemeente,straat);
        public override string ToString()
        {
            return $"straat : {straat}, gemeente : {gemeente}, provincie : {provincie}";
        }
    }
}
