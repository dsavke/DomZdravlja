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

        [DisplayName("FRKID")]
        [SqlName("FRKID")]
        [PrimaryKey]
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

        [DisplayName("Faktor rizika ID")]
        [SqlName("FaktorRizikaID")]
        [ForeignKey("dbo.FaktorRizika", "FaktorRizikaID")]
        
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

        #endregion

        #region Querys

        public string GetSelectQuery()
        {
            return @"USE [Tim4]
                    GO
                    SELECT [FRKID]
                          ,[FaktorRizikaID]
                          ,[KartonID]
                      FROM [dbo].[FaktorRizikaKarton]
                    GO";
        }

        public string GetInsertQuery()
        {
            return @"USE [Tim4]
                    GO
                    INSERT INTO [dbo].[FaktorRizikaKarton]
                               ([FaktorRizikaID]
                               ,[KartonID])
                         VALUES(
                               @FaktorRizikaID
                               ,@KartonID)
                    GO";
        }

        public string GetUpdateQuery()
        {
            return @"USE [Tim4]
                    GO
                    UPDATE [dbo].[FaktorRizikaKarton]
                       SET [FaktorRizikaID] = @FaktorRizikaID
                          ,[KartonID] = @KartonID
                     WHERE FRKID = @FRKID
                    GO";
        }

        public string GetDeleteQuery()
        {
            return @"USE [Tim4]
                    GO
                    DELETE FROM [dbo].[FaktorRizikaKarton]
                          WHERE FRKID = @FRKID
                    GO";
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
