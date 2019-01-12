using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomZdravlja.AttributeClass
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DefaultPropertValue:Attribute
    {
        public TargetValue Target { get; set; }
        public object Value { get; set; }

        public DefaultPropertValue(TargetValue target, object value)
        {
            Target = target;
            Value = value;
        }

    }
}
