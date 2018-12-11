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
    public class PropertyDijagnoza:PropertyInterface
    {
        #region Atributi
        private int dijagnozaID;
        private int pacijentID;
        private int doktorID;
        private string terapija;
        private string opis;
        #endregion


        #region Property

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
        [PrimaryKey]

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

        [DisplayName("Terapija")]
        [SqlName("Terapija")]
        [PrimaryKey]

        public string Terapija
        {
            get
            {
                return terapija;
            }
            set
            {
                terapija = value;
            }
        }

        [DisplayName("Opis")]
        [SqlName("Opis")]
        [PrimaryKey]

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

        #region Qurey

        public string GetDeleteQuery()
        {
            return @"  DELETE FROM dbo.Dijagnoza
                        WHERE DijagnozaID = @dijagnozaID
                    ";

        }
        public string GetInsertQuery()
        {
            return @"
                    INSERT INTO dbo.Dijagnoza
                       (PacijentID
                        ,DoktorID
                        ,Terapija
                        ,Opis)    
                    VALUES
                       (@pacijentID,@doktorID,@terapija,@opis)
                    ";
        }

        public string GetUpdateQuery()
        {
            return @"UPDATE dbo.Dijagnoza
                       set[PacijentID]=@PacijentID,
                       [DoktorID]=@DoktorID;
                       [Terapija]=@Terapija;
                       [Opis]=@Opis;
                   where @DijagnozaID=Dijagnoza.DijagnozaID";
        }

        public string GetSelectQuery()
        {
            return @"
                       SELECT DijagnozaID
                       ,PacijentID
                       ,DoktorID
                       ,Terapija
                       ,Opis
                      FROM dbo.Dijagnoza
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
