using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomZdravlja.AttributeClass
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Editing:Attribute
    {
        public Use Use { get; set; }

        public Editing(Use use)
        {
            Use = use;
        }

    }
}
