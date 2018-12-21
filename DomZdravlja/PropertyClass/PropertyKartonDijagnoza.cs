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
    public class PropertyKartonDijagnoza : PropertyInterface
    {
        #region Atributi
        private int kartonDijagnozaID;
        private int kartonID;
        private int dijagnozaID;
        #endregion

        #region Property 
        [DisplayName("Šifra karton dijagnoza")]
        [SqlName("KartonDijagnozaID")]
        [GenerateComponent(ComponentType.Tekst)]
        [PrimaryKey]
        [Invisible]
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

        [DisplayName("Šifra kartona")]
        [SqlName("KartonID")]
        [GenerateComponent(ComponentType.Lookup)]
        [ForeignKey("DomZdravlja.PropertyClass.PropertyKarton", "PacijentID")]
        [ValidatePattern(@"^\d+$")]

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

        [DisplayName("Šifra dijagnoze")]
        [SqlName("DijagnozaID")]
        [GenerateComponent(ComponentType.Lookup)]
        [ForeignKey("DomZdravlja.PropertyClass.PropertyDijagnoza", "DijagnozaID")]
        [ValidatePattern(@"^\d+$")]

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

        #region Querys

        public string GetSelectQuery()
        {
            return @"
                    SELECT [KartonDijagnozaID]
                          ,[KartonID]
                          ,[DijagnozaID]
                      FROM [dbo].[KartonDijagnoza]
                    ";
        }

        public string GetInsertQuery()
        {
            return @"
                    INSERT INTO [dbo].[KartonDijagnoza]
                               ([KartonID]
                               ,[DijagnozaID])
                         VALUES
                               (@KartonID
                               ,@DijagnozaID)
                    ";
        }

        public string GetUpdateQuery()
        {
            return @"
                    UPDATE [dbo].[KartonDijagnoza]
                       SET [KartonID] = @KartonID
                          ,[DijagnozaID] = @DijagnozaID
                     WHERE KartonDijagnozaID = @KartonDijagnozaID
                    ";
        }

        public string GetDeleteQuery()
        {
            return @"
                    DELETE FROM [dbo].[KartonDijagnoza]
                          WHERE KartonDijagnozaID = @KartonDijagnozaID
                    ";
        }

        #endregion

        #region Parametri

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter KartonDijagnozaID = new SqlParameter("@KartonDijagnozaID", System.Data.SqlDbType.Int);
            KartonDijagnozaID.Value = kartonDijagnozaID;
            list.Add(KartonDijagnozaID);

            return list;
        }

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter KartonID = new SqlParameter("@KartonID", System.Data.SqlDbType.Int);
            KartonID.Value = kartonID;
            list.Add(KartonID);

            SqlParameter DijagnozaID = new SqlParameter("@DijagnozaID", System.Data.SqlDbType.Int);
            DijagnozaID.Value = dijagnozaID;
            list.Add(DijagnozaID);

            return list;
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter KartonDijagnozaID = new SqlParameter("@KartonDijagnozaID", System.Data.SqlDbType.Int);
            KartonDijagnozaID.Value = kartonDijagnozaID;
            list.Add(KartonDijagnozaID);

            SqlParameter KartonID = new SqlParameter("@KartonID", System.Data.SqlDbType.Int);
            KartonID.Value = kartonID;
            list.Add(KartonID);

            SqlParameter DijagnozaID = new SqlParameter("@DijagnozaID", System.Data.SqlDbType.Int);
            DijagnozaID.Value = dijagnozaID;
            list.Add(DijagnozaID);

            return list;
        }

        #endregion
    }
}
