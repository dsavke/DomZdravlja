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
    public class PropertyRecepcija:PropertyInterface
    {
        #region Atributi
        private int prijemID;
        private int prijemZaposlenihID;
        private int pacijentID;
        private int doktorID;
        private int prioritet;
        private DateTime vrijemePrijema;
        private DateTime vrijemeOtpusta;
        #endregion

        #region Property

        [DisplayName("Prijem ID")]
        [SqlName("PrijemID")]
        [PrimaryKey]
        public int PrijemID
        {
            get
            {
                return prijemID;
            }
            set
            {
                prijemID = value;
            }
        }

        [DisplayName("Prijem zaposlenih ID")]
        [SqlName("PrijemZaposlenihID")]
       
        public int PrijemZaposlenihID
        {
            get
            {
                return prijemZaposlenihID;
            }
            set
            {
                prijemZaposlenihID = value;
            }
        }

        [DisplayName("Pacijent ID")]
        [SqlName("PacijentID")]

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

        [DisplayName("Prioritet")]
        [SqlName("Prioritet")]

        public int Prioritet
        {
            get
            {
                return prioritet;
            }
            set
            {
                prioritet = value;
            }
        }

        [DisplayName("Vrijeme prijema")]
        [SqlName("VrijemePrijema")]

        public DateTime VrijemePrijema
        {
            get
            {
                return vrijemePrijema;
            }
            set
            {
                vrijemePrijema = value;
            }
        }

        [DisplayName("Vrijeme otpusta")]
        [SqlName("VrijemeOtpusta")]

        public DateTime VrijemeOtpusta
        {
            get
            {
                return vrijemeOtpusta;
            }
            set
            {
                vrijemeOtpusta = value;
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
