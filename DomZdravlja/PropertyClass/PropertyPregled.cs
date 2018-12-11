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
    public class PropertyPregled:PropertyInterface
    {
        #region Atributi
        private int pregledID;
        private int doktorID;
        private int pacijentID;
        private int dijagnozaID;
        #endregion

        #region Property
        [DisplayName("Pregled ID")]
        [SqlName("PregledID")]
        [PrimaryKey]
        public int PregledID
        {
            get
            {
                return pregledID;
            }
            set
            {
                pregledID = value;
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

        [DisplayName("Dijagnoza ID")]
        [SqlName("DijagnozaID")]

        public int DijagnozaID
        {
            get
            {
                return dijagnozaID;
            }
            set
            {
                dijagnozaID = value;
            }
        }
        #endregion

        #region Qurey



        #endregion



        #region Paramerti

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
