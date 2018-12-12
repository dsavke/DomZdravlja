using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomZdravlja.AttributeClass
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ForeignKey : Attribute
    {
        public string referencedTable;
        public string referencedColumn;

        public ForeignKey(string referencedTable, string referencedColumn)
        {
            this.referencedTable = referencedTable;
            this.referencedColumn = referencedColumn;
        }
    }
}
