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

        [DisplayName("Šifra dijagnoze")]
        [SqlName("DijagnozaID")]
        [GenerateComponent(ComponentType.Tekst)]
        [PrimaryKey]
        [Invisible(Use.Insert)]
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

        [DisplayName("Terapija")]
        [SqlName("Terapija")]
        [GenerateComponent(ComponentType.Tekst)]
        [ValidatePattern(@"(?!^.*[A-Z]{2,}.*$)^[A-Za-z0-9\s\.]*$")]
        [Editing(Use.InsertAndUpdate)]
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
        [GenerateComponent(ComponentType.Tekst)]
        [ValidatePattern(@"(?!^.*[A-Z]{2,}.*$)^[A-Za-z0-9\s\.]*$")]
        [Editing(Use.InsertAndUpdate)]
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
                       (Terapija
                        ,Opis)    
                    VALUES
                       (@Terapija,@Opis)
                    ";
        }

        public string GetUpdateQuery()
        {
            return @"
                    UPDATE [dbo].[Dijagnoza]
                       SET [Terapija] = @Terapija
                          ,[Opis] = @Opis
                     WHERE [DijagnozaID] = @DijagnozaID
                    ";
        }

        public string GetSelectQuery()
        {
            return @"
                  
                    SELECT [DijagnozaID]
                          ,[Terapija]
                          ,[Opis]
                      FROM [dbo].[Dijagnoza]
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
