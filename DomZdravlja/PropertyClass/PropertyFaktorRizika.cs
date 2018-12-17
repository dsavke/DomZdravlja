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
    public class PropertyFaktorRizika : PropertyInterface
    {
        #region Atributi
        private int faktorRizikaID;
        private string nazivRizika;
        private string opis;
        #endregion

        #region Property

        [DisplayName("Faktor rizika ID")]
        [SqlName("FaktorRizikaID")]
        [GenerateComponent(ComponentType.Tekst)]
        [PrimaryKey]
        public int FaktorRizikaID
        {
            get
            {
                return faktorRizikaID;
            }
            set
            {
                faktorRizikaID = value;
            }
        }

        [DisplayName("Naziv rizika")]
        [SqlName("NazivRizika")]
        [GenerateComponent(ComponentType.Tekst)]

        public string NazivRizika
        {
            get
            {
                return nazivRizika;
            }
            set
            {
                nazivRizika = value;
            }
        }

        [DisplayName("Opis")]
        [SqlName("Opis")]
        [GenerateComponent(ComponentType.Tekst)]

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

        #region Querys

        public string GetSelectQuery()
        {
            return @"USE [Tim4]
                    GO
                    SELECT [FaktorRizikaID]
                          ,[NazivRizika]
                          ,[Opis]
                      FROM [dbo].[FaktorRizika]
                    GO";
        }

        public string GetInsertQuery()
        {
            return @"USE [Tim4]
                    GO
                    INSERT INTO [dbo].[FaktorRizika]
                               ([NazivRizika]
                               ,[Opis])
                         VALUES
                               @NazivRizika
                               ,@Opis
                    GO";
        }

        public string GetUpdateQuery()
        {
            return @"USE [Tim4]
                    GO

                    UPDATE [dbo].[FaktorRizika]
                       SET [NazivRizika] = @NazivRizika
                          ,[Opis] = @Opis
                     WHERE FaktorRizikaID = @FaktorRizikaID
                    GO";
        }

        public string GetDeleteQuery()
        {
            return @"USE [Tim4]
                    GO
                    DELETE FROM [dbo].[FaktorRizika]
                          WHERE FaktorRizikaID = @FaktorRizikaID
                    GO";
        }

        #endregion

        #region Parametri

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter FaktorRizikaID = new SqlParameter("@FaktorRizikaID", System.Data.SqlDbType.Int);
            FaktorRizikaID.Value = faktorRizikaID;
            list.Add(FaktorRizikaID);

            return list;
        }

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter NazivRizika = new SqlParameter("@NazivRizika", System.Data.SqlDbType.NVarChar);
            NazivRizika.Value = nazivRizika;
            list.Add(NazivRizika);

            SqlParameter Opis = new SqlParameter("@Opis", System.Data.SqlDbType.NVarChar);
            Opis.Value = opis;
            list.Add(Opis);

            return list;
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter FaktorRizikaID = new SqlParameter("@FaktorRizikaID", System.Data.SqlDbType.Int);
            FaktorRizikaID.Value = faktorRizikaID;
            list.Add(FaktorRizikaID);

            SqlParameter NazivRizika = new SqlParameter("@NazivRizika", System.Data.SqlDbType.NVarChar);
            NazivRizika.Value = nazivRizika;
            list.Add(NazivRizika);

            SqlParameter Opis = new SqlParameter("@Opis", System.Data.SqlDbType.NVarChar);
            Opis.Value = opis;
            list.Add(Opis);

            return list;
        }

        #endregion
    }
}
