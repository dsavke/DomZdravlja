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
        [GenerateComponent(ComponentType.Tekst)]
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
        [GenerateComponent(ComponentType.Tekst)]

        [ValidatePattern(@"^\d+$")]

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
        [GenerateComponent(ComponentType.Tekst)]
        [ValidatePattern(@"^\d+$")]

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
        [GenerateComponent(ComponentType.Tekst)]
        [ValidatePattern(@"^\d+$")]

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
        [GenerateComponent(ComponentType.Tekst)]
        [ValidatePattern(@"^\d+$")]

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

        #region Querys

        public string GetDeleteQuery()
        {
            return @"USE [Tim4]
                    GO
                    DELETE FROM [dbo].[Pacijent]
                          WHERE PacijentID = @PacijentID
                    GO";
        }

        public string GetInsertQuery()
        {
            return @"USE [Tim4]
                    GO
                    INSERT INTO [dbo].[Pacijent]
                               ([DoktorID]
                               ,[OsobaID]
                               ,[BrojKartona]
                               ,[Osiguran])
                         VALUES
                               (@DoktorID
                               ,@OsobaID
                               ,@BrojKartona
                               ,@Osiguran)
                    GO";
        }

        public string GetSelectQuery()
        {
            return @"USE [Tim4]
                    GO
                    SELECT [PacijentID]
                          ,[DoktorID]
                          ,[OsobaID]
                          ,[BrojKartona]
                          ,[Osiguran]
                      FROM [dbo].[Pacijent]
                    GO
                    ";
        }

        public string GetUpdateQuery()
        {
            return @"USE [Tim4]
                    GO
                    UPDATE [dbo].[Pacijent]
                       SET [DoktorID] = @DoktorID
                          ,[OsobaID] = @OsobaID
                          ,[BrojKartona] = @BrojKartona
                          ,[Osiguran] = @Osiguran
                     WHERE PacijentID = @PacijentID
                    GO";
        }

        #endregion

        #region Parametri

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter PacijentID = new SqlParameter("@PacijentID", System.Data.SqlDbType.Int);
            PacijentID.Value = pacijentID;
            list.Add(PacijentID);

            return list;
        }

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter DoktorID = new SqlParameter("@DoktorID", System.Data.SqlDbType.Int);
            DoktorID.Value = doktorID;
            list.Add(DoktorID);

            SqlParameter OsobaID = new SqlParameter("@OsobaID", System.Data.SqlDbType.Int);
            OsobaID.Value = osobaID;
            list.Add(OsobaID);

            SqlParameter BrojKartona = new SqlParameter("@BrojKartona", System.Data.SqlDbType.Int);
            BrojKartona.Value = brojKartona;
            list.Add(BrojKartona);

            SqlParameter Osiguran = new SqlParameter("@Osiguran", System.Data.SqlDbType.TinyInt);
            Osiguran.Value = osiguran;
            list.Add(Osiguran);

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

            SqlParameter OsobaID = new SqlParameter("@OsobaID", System.Data.SqlDbType.Int);
            OsobaID.Value = osobaID;
            list.Add(OsobaID);

            SqlParameter BrojKartona = new SqlParameter("@BrojKartona", System.Data.SqlDbType.Int);
            BrojKartona.Value = brojKartona;
            list.Add(BrojKartona);

            SqlParameter Osiguran = new SqlParameter("@Osiguran", System.Data.SqlDbType.TinyInt);
            Osiguran.Value = osiguran;
            list.Add(Osiguran);

            return list;
        }

        #endregion

    }
}
