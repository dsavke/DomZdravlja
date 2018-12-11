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
    public class PropertyKarton:PropertyInterface
    {

        #region Atributi
        private int pacijentID;
        private int kartonID;
        private int dijagnozaID;

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

        [DisplayName("Dijagnoza ID")]
        [SqlName("DijagnozaID")]
        [PrimaryKey]

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

        #region Query
        public string GetDeleteQuery()
        {
            return @"  DELETE FROM dbo.Karton
                        WHERE PacijentID = @PacijentID
                    ";

        }
        public string GetInsertQuery()
        {
            return @"
                    INSERT INTO dbo.Karton
                       (KartonID
                       ,DijagnozaID
                    VALUES
                       (@KartonID,@DijagnozaID)
                    ";
        }

        public string GetUpdateQuery()
        {
            return @"UPDATE dbo.Karton
                       set[KartonID]=@KartonID,
                       [DijagnozaID]=@DijagnozaID;
                   where @PacijentID=Karton.PacijentID";
        }

        public string GetSelectQuery()
        {
            return @"
                       SELECT PacijentID
                       ,KartonID
                       ,DijagnozaID
                      FROM dbo.Karton
                    ";
        }

        #endregion


        #region Parametri

        public List<SqlParameter> GetDeleteParameters()
        {
            throw new NotImplementedException();
        }

       

        public List<SqlParameter> GetInsertParameters()
        {
            throw new NotImplementedException();
        }


        public List<SqlParameter> GetUpdateParameters()
        {
            throw new NotImplementedException();
        }

      
        #endregion



    }
}
