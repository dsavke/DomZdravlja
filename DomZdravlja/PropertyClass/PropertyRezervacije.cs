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
    public class PropertyRezervacije:PropertyInterface
    {
        #region Atributi
        private int rezervacijaID;
        private int pacijentID;
        private DateTime vrijemeRezervacije;
        private DateTime termin;
        private int doktorID;
        #endregion

        #region Property

        [DisplayName("Rezervacija ID")]
        [SqlName("RezervacijaID")]
        [PrimaryKey]
        public int RezervacijaID
        {
            get
            {
                return rezervacijaID;
            }
            set
            {
                rezervacijaID = value;
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

        [DisplayName("Vrijeme rezervacije")]
        [SqlName("VrijemeRezervacije")]

        public DateTime VrijemeRezervacije
        {
            get
            {
                return vrijemeRezervacije;
            }
            set
            {
                vrijemeRezervacije = value;
            }
        }

        [DisplayName("Termin")]
        [SqlName("Termin")]

        public DateTime Termin
        {
            get
            {
                return termin;
            }
            set
            {
                termin = value;
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
