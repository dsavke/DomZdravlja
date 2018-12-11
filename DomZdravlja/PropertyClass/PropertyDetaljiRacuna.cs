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
    public class PropertyDetaljiRacuna:PropertyInterface
    {
        #region Atributi
        private int detaljiRacunaID;
        private int racunID;
        private int cijenaID;
        private int kolicina;
        #endregion

        #region Property

        [DisplayName("Detalji racuna ID")]
        [SqlName("DetaljiRacunaID")]
        [PrimaryKey]
        public int DetaljiRacunaID
        {
            get
            {
                return detaljiRacunaID;
            }
            set
            {
                detaljiRacunaID = value;
            }
        }

        [DisplayName("Racun ID")]
        [SqlName("RacunID")]
      
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

        [DisplayName("Cijena ID")]
        [SqlName("CijenaID")]

        public int CijenaID
        {
            get
            {
                return cijenaID;
            }
            set
            {
                cijenaID = value;
            }
        }

        [DisplayName("Kolicina")]
        [SqlName("Kolicina")]

        public int Kolicina
        {
            get
            {
                return kolicina;
            }
            set
            {
                kolicina = value;
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
