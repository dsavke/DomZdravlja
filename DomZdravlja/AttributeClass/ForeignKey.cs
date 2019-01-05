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
        public string BackCol1 { get; set; }
        public string BackCol2 { get; set; }
        public Tip Tip { get; set; }
        public bool? LookupInsert { get; set; }

        public ForeignKey(string referencedTable, string referencedColumn)
        {
            this.ReferencedTable = referencedTable;
            this.ReferencedColumn = referencedColumn;
        }

        public ForeignKey(string referencedTable, string referencedColumn, Tip tip)
        {
            this.ReferencedTable = referencedTable;
            this.ReferencedColumn = referencedColumn;
            Tip = tip;
        }

        public ForeignKey(string referencedTable, string referencedColumn, Tip tip, string backCol1, string backCol2, bool lookupInsert)
        {
            this.ReferencedTable = referencedTable;
            this.ReferencedColumn = referencedColumn;
            Tip = tip;
            BackCol1 = backCol1;
            BackCol2 = backCol2;
            LookupInsert = lookupInsert;
        }

    }
}
