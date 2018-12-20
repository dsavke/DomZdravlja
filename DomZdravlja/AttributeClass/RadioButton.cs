using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomZdravlja.AttributeClass
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RadioButton : Attribute
    {
        public string Param1;
        public string Param2;

        public RadioButton(string Param1, string Param2)
        {
            this.Param1 = Param1;
            this.Param2 = Param2;
        }
    }
}
