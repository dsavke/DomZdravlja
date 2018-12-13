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
        [ForeignKey("dbo.Pacijent", "PacijentID")]

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
        [ForeignKey("dbo.Zaposleni", "ZaposleniID")]

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
                        WHERE DijagnozaID = @DijagnozaID
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
                       (@PacijentID,@DoktorID,@Terapija,@Opis)
                    ";
        }

        public string GetUpdateQuery()
        {
            return @"USE [Tim4]
                    GO
                    UPDATE [dbo].[Dijagnoza]
                       SET [PacijentID] = @PacijentID
                          ,[DoktorID] = @DoktorID
                          ,[Terapija] = @Terapija
                          ,[Opis] = @Opis
                     WHERE [DijagnozaID] = @DijagnozaID
                    GO";
        }

        public string GetSelectQuery()
        {
            return @"
                   USE [Tim4]
                    GO
                    SELECT [DijagnozaID]
                          ,[PacijentID]
                          ,[DoktorID]
                          ,[Terapija]
                          ,[Opis]
                      FROM [dbo].[Dijagnoza]
                    GO
                    ";
        }


        #endregion

        #region Parametri

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter DijagnozaID = new SqlParameter("@DijagnozaID", System.Data.SqlDbType.Int);
            DijagnozaID.Value = dijagnozaID;
            list.Add(DijagnozaID);

            return list;
        }

       

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter PacijentID = new SqlParameter("@PacijentID", System.Data.SqlDbType.Int);
            PacijentID.Value = pacijentID;
            list.Add(PacijentID);

            SqlParameter DoktorID = new SqlParameter("@DoktorID", System.Data.SqlDbType.Int);
            DoktorID.Value = doktorID;
            list.Add(DoktorID);

            SqlParameter Terapija = new SqlParameter("@Terapija", System.Data.SqlDbType.NVarChar);
            Terapija.Value = terapija;
            list.Add(Terapija);

            SqlParameter Opis = new SqlParameter("@Opis", System.Data.SqlDbType.NVarChar);
            Opis.Value = opis;
            list.Add(Opis);

            return list;
        }

       

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter PacijentID = new SqlParameter("@PacijentID", System.Data.SqlDbType.Int);
            PacijentID.Value = pacijentID;
            list.Add(PacijentID);

            SqlParameter DoktorID = new SqlParameter("@DoktorID", System.Data.SqlDbType.Int);
            DoktorID.Value = doktorID;
            list.Add(DoktorID);

            SqlParameter Terapija = new SqlParameter("@Terapija", System.Data.SqlDbType.NVarChar);
            Terapija.Value = terapija;
            list.Add(Terapija);

            SqlParameter Opis = new SqlParameter("@Opis", System.Data.SqlDbType.NVarChar);
            Opis.Value = opis;
            list.Add(Opis);

            SqlParameter DijagnozaID = new SqlParameter("@DijagnozaID", System.Data.SqlDbType.Int);
            DijagnozaID.Value = dijagnozaID;
            list.Add(DijagnozaID);

            return list;
        }
        

        #endregion

    }
}
