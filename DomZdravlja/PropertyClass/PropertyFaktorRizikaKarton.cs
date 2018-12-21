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
    public class PropertyFaktorRizikaKarton:PropertyInterface
    {

        #region Atributi
        private int frkID;
        private int faktorRizikaID;
        private int kartonID;
        #endregion

        #region Property

        [DisplayName("Šifra faktor rizika karton")]
        [SqlName("FRKID")]
        [GenerateComponent(ComponentType.Tekst)]
        [PrimaryKey]
        [Invisible]
        public int FRKID
        {
            get
            {
                return frkID;
            }
            set
            {
                frkID = value;
            }
        }

        [DisplayName("Šifra faktor rizika")]
        [SqlName("FaktorRizikaID")]
        [GenerateComponent(ComponentType.Lookup)]
        [ForeignKey("DomZdravlja.PropertyClass.PropertyFaktorRizika", "FaktorRizikaID")]
        [ValidatePattern(@"^\d+$")]

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

        #endregion

        #region Querys

        public string GetSelectQuery()
        {
            return @"
                    SELECT [FRKID]
                          ,[FaktorRizikaID]
                          ,[KartonID]
                      FROM [dbo].[FaktorRizikaKarton]
                    ";
        }

        public string GetInsertQuery()
        {
            return @"
                    INSERT INTO [dbo].[FaktorRizikaKarton]
                               ([FaktorRizikaID]
                               ,[KartonID])
                         VALUES(
                               @FaktorRizikaID
                               ,@KartonID)
                    ";
        }

        public string GetUpdateQuery()
        {
            return @"
                    UPDATE [dbo].[FaktorRizikaKarton]
                       SET [FaktorRizikaID] = @FaktorRizikaID
                          ,[KartonID] = @KartonID
                     WHERE FRKID = @FRKID
                    ";
        }

        public string GetDeleteQuery()
        {
            return @"
                    DELETE FROM [dbo].[FaktorRizikaKarton]
                          WHERE FRKID = @FRKID
                    ";
        }

        #endregion

        #region Parametri

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter FRKID = new SqlParameter("@FRKID", System.Data.SqlDbType.Int);
            FRKID.Value = frkID;
            list.Add(FRKID);

            return list;
        }
        
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter FaktorRizikaID = new SqlParameter("@FaktorRizikaID", System.Data.SqlDbType.Int);
            FaktorRizikaID.Value = faktorRizikaID;
            list.Add(FaktorRizikaID);

            SqlParameter KartonID = new SqlParameter("@KartonID", System.Data.SqlDbType.Int);
            KartonID.Value = kartonID;
            list.Add(KartonID);

            return list;
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter FRKID = new SqlParameter("@FRKID", System.Data.SqlDbType.Int);
            FRKID.Value = frkID;
            list.Add(FRKID);

            SqlParameter FaktorRizikaID = new SqlParameter("@FaktorRizikaID", System.Data.SqlDbType.Int);
            FaktorRizikaID.Value = faktorRizikaID;
            list.Add(FaktorRizikaID);

            SqlParameter KartonID = new SqlParameter("@KartonID", System.Data.SqlDbType.Int);
            KartonID.Value = kartonID;
            list.Add(KartonID);

            return list;
        }

        #endregion

    }
}
