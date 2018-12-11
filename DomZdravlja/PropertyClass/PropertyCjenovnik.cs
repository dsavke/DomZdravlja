using DomZdravlja.AttributeClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomZdravlja.PropertyClass
{
    public class PropertyCjenovnik:PropertyInterface
    {
        #region Atributi
        private int cjenovnikID;
        private string nazivUsluge;
        private decimal cijenaUsluge;
        private DateTime datumUspostavljanjaCijene;
        #endregion


        #region Property
        [DisplayName("Cjenovnik ID")]
        [SqlName("CjenovnikID")]
        [PrimaryKey]
        public int CjenovnikID
        {
            get
            {
                return cjenovnikID;
            }
            set
            {
                cjenovnikID = value;
            }
        }

        [DisplayName("Naziv usluge")]
        [SqlName("NazivUsluge")]
    
        public string NazivUsluge
        {
            get
            {
                return nazivUsluge;
            }
            set
            {
                nazivUsluge = value;
            }
        }

        [DisplayName("Cijena usluge")]
        [SqlName("CijenaUsluge")]
        
        public decimal CijenaUsluge
        {
            get
            {
                return cijenaUsluge;
            }
            set
            {
                cijenaUsluge = value;
            }
        }

        [DisplayName("Datum uspostavljanja cijene")]
        [SqlName("DatumUspostavljanjaCijene")]
      
        public DateTime DatumUspostavljanjaCijene
        {
            get
            {
                return datumUspostavljanjaCijene;
            }
            set
            {
                datumUspostavljanjaCijene = value;
            }
        }

        #endregion


        #region Parametri

        public List<SqlParameter> GetDeleteParameters()
        {
            throw new NotImplementedException();
        }

        public string GetDeleteQuery()
        {
            throw new NotImplementedException();
        }

        public List<SqlParameter> GetInsertParameters()
        {
            throw new NotImplementedException();
        }

        public string GetInsertQuery()
        {
            throw new NotImplementedException();
        }

        public string GetSelectQuery()
        {
            throw new NotImplementedException();
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            throw new NotImplementedException();
        }

        public string GetUpdateQuery()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
