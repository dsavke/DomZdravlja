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

        [DisplayName("Šifra faktor rizika")]
        [SqlName("FaktorRizikaID")]
        [GenerateComponent(ComponentType.Tekst)]
        [PrimaryKey]
        [Invisible(Use.Insert)]
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
        [ValidatePattern(@"(?!^.*[A-Z]{2,}.*$)^[A-Za-z\s]+$")]
        [Editing(Use.Insert)]
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
        [ValidatePattern(@"(?!^.*[A-Z]{2,}.*$)^[A-Za-z0-9\s\.]*$")]
        [Editing(Use.Insert)]
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
            return @"
                    SELECT [FaktorRizikaID]
                          ,[NazivRizika]
                          ,[Opis]
                      FROM [dbo].[FaktorRizika]
                    ";
        }

        public string GetInsertQuery()
        {
            return @"
                    INSERT INTO [dbo].[FaktorRizika]
                               ([NazivRizika]
                               ,[Opis])
                         VALUES
                               @NazivRizika
                               ,@Opis
                    ";
        }

        public string GetUpdateQuery()
        {
            return @"

                    UPDATE [dbo].[FaktorRizika]
                       SET [NazivRizika] = @NazivRizika
                          ,[Opis] = @Opis
                     WHERE FaktorRizikaID = @FaktorRizikaID
                    ";
        }

        public string GetDeleteQuery()
        {
            return @"
                    DELETE FROM [dbo].[FaktorRizika]
                          WHERE FaktorRizikaID = @FaktorRizikaID
                    ";
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
