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
    public class PropertyPacijent:PropertyInterface
    {
        #region Atributi
        private int pacijentID;
        private int doktorID;
        private int osobaID;
        private int brojKartona;
        private int osiguran;
        #endregion

        #region Property

        [DisplayName("Pacijent ID")]
        [SqlName("PacijentID")]
        [PrimaryKey]
        public int PacijentID
        {
            get
            {
                return pacijentID;
            }
            set
            {
                pacijentID = value;
            }
        }

        [DisplayName("Doktor ID")]
        [SqlName("DoktorID")]
       
        public int DoktorID
        {
            get
            {
                return doktorID;
            }
            set
            {
                doktorID = value;
            }
        }

        [DisplayName("Osoba ID")]
        [SqlName("OsobaID")]

        public int OsobaID
        {
            get
            {
                return osobaID;
            }
            set
            {
                osobaID = value;
            }
        }

        [DisplayName("Broj kartona")]
        [SqlName("BrojKartona")]

        public int BrojKartona
        {
            get
            {
                return brojKartona;
            }
            set
            {
                brojKartona = value;
            }
        }

        [DisplayName("Osiguran")]
        [SqlName("Osiguran")]

        public int Osiguran
        {
            get
            {
                return osiguran;
            }
            set
            {
                osiguran = value;
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
