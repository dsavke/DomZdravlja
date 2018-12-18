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
        public string ReferencedTable { get; set; }
        public string ReferencedColumn { get; set; }

        public ForeignKey(string referencedTable, string referencedColumn)
        {
            this.ReferencedTable = referencedTable;
            this.ReferencedColumn = referencedColumn;
        }

    }
}
