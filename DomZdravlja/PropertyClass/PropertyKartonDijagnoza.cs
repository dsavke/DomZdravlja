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
    public class PropertyKartonDijagnoza:PropertyInterface
    {
        #region Atributi
        private int kartonDijagnozaID;
        private int kartonID;
        private int dijagnozaID;
        #endregion

        #region Property 
        [DisplayName("Karton dijagnoza ID")]
        [SqlName("KartonDijagnozaID")]
        [PrimaryKey]
        public int KartonDijagnozaID
        {
            get
            {
                return kartonDijagnozaID;
            }
            set
            {
                kartonDijagnozaID = value;
            }
        }

        [DisplayName("Karton ID")]
        [SqlName("KartonID")]
        [ForeignKey("dbo.Karton", "PacijentID")]
       
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

        [DisplayName("Dijeagnoza ID")]
        [SqlName("DijagnozaID")]
        [ForeignKey("dbo.Dijagnoza", "DijagnozaID")]

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
