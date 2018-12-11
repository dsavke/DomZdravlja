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
    public class PropertyFaktorRizikaKarton:PropertyInterface
    {

        #region Atributi
        private int frkid;
        private int faktorRizikaID;
        private int kartonID;
        private string tipRizika;
        private string status;
        #endregion

        #region Property

        [DisplayName("FRKID")]
        [SqlName("FRKID")]
        [PrimaryKey]
        public int FRKID
        {
            get
            {
                return frkid;
            }
            set
            {
                frkid = value;
            }
        }

        [DisplayName("Faktor rizika ID")]
        [SqlName("FaktorRizikaID")]
        
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

        [DisplayName("Karton ID")]
        [SqlName("KartonID")]

        public int KartonID
        {
            get
            {
                return kartonID;
            }
            set
            {
                kartonID = value;
            }
        }

        [DisplayName("Tip rizika")]
        [SqlName("TipRizika")]

        public string TipRizika
        {
            get
            {
                return tipRizika;
            }
            set
            {
                tipRizika = value;
            }
        }

        [DisplayName("Status")]
        [SqlName("Status")]

        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
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
