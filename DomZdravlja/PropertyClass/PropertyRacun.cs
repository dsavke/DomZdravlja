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
    public class PropertyRacun:PropertyInterface
    {
        #region Atributi
        private int racunID;
        private DateTime vrijemeIzdavanja;
        private int zaposleniID;
        private decimal popust;
        private int pacijentID;
        #endregion

        #region Property
        [DisplayName("Racun ID")]
        [SqlName("RacunID")]
        [PrimaryKey]
        public int RacunID
        {
            get
            {
                return racunID;
            }
            set
            {
                racunID = value;
            }
        }

        [DisplayName("Vrijeme izdavanja")]
        [SqlName("VrijemeIzdavanja")]
       
        public DateTime VrijemeIzdavanja
        {
            get
            {
                return vrijemeIzdavanja;
            }
            set
            {
                vrijemeIzdavanja = value;
            }
        }

        [DisplayName("Zaposleni ID")]
        [SqlName("ZaposleniID")]

        public int ZaposleniID
        {
            get
            {
                return zaposleniID;
            }
            set
            {
                zaposleniID = value;
            }
        }

        [DisplayName("Popust")]
        [SqlName("Popust")]

        public decimal Popust
        {
            get
            {
                return popust;
            }
            set
            {
                popust = value;
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
        #endregion

        #region Paramteri

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
