using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomZdravlja.AttributeClass
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GenerateComponent:Attribute
    {

        public ComponentType ComponentType;

        public GenerateComponent(ComponentType componentType)
        {
            ComponentType = componentType;
        }
    }
}
