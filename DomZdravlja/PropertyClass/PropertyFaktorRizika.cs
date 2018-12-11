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
    public class PropertyFaktorRizika : PropertyInterface
    {
        #region Atributi
        private int faktorRizikaID;
        private string nazivRizika;
        private string opis;
        #endregion

        #region Property

        [DisplayName("Faktor rizika ID")]
        [SqlName("FaktorRizikaID")]
        [PrimaryKey]
        public int FaktorRizikaID
        {
            get
            {
                return faktorRizikaID;
            }
            set
            {
                faktorRizikaID = value;
            }
        }

        [DisplayName("Naziv rizika")]
        [SqlName("NazivRizika")]

        public string NazivRizika
        {
            get
            {
                return nazivRizika;
            }
            set
            {
                nazivRizika = value;
            }
        }

        [DisplayName("Opis")]
        [SqlName("Opis")]

        public string Opis
        {
            get
            {
                return opis;
            }
            set
            {
                opis = value;
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
