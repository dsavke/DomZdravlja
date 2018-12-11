using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomZdravlja.AttributeClass
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SqlName:Attribute
    {
        public string Name;

        public SqlName(string name)
        {
            Name = name;
        }

    }
}
