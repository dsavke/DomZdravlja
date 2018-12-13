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
        private int brojKartona;
        #endregion

        #region Property

        [DisplayName("Pacijent ID")]
        [SqlName("PacijentID")]
        [PrimaryKey]
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

        [DisplayName("Broj Kartona")]
        [SqlName("BrojKartona")]

        public int KartonID
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
                   USE [Tim4]
                    GO
                    INSERT INTO [dbo].[Karton]
                               ([PacijentID]
                               ,[BrojKartona])
                         VALUES
                               (@PacijentID
                               ,@BrojKartona)
                    GO";
        }

        public string GetUpdateQuery()
        {
            return @"USE [Tim4]
                    GO
                    UPDATE [dbo].[Karton]
                       SET [BrojKartona] = @BrojKartona   
                     WHERE [PacijentID] = @PacijentID
                    GO";
        }

        public string GetSelectQuery()
        {
            return @"USE [Tim4]
                    GO
                    SELECT [PacijentID]
                          ,[BrojKartona]
                      FROM [dbo].[Karton]
                    GO
                    ";
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

            SqlParameter PacijentID = new SqlParameter("@PacijentID", System.Data.SqlDbType.Int);
            PacijentID.Value = pacijentID;
            list.Add(PacijentID);

            SqlParameter BrojKartona = new SqlParameter("@BrojKartona", System.Data.SqlDbType.Int);
            BrojKartona.Value = brojKartona;
            list.Add(BrojKartona);

            return list;
        }


        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter PacijentID = new SqlParameter("@PacijentID", System.Data.SqlDbType.Int);
            PacijentID.Value = pacijentID;
            list.Add(PacijentID);

            SqlParameter BrojKartona = new SqlParameter("@BrojKartona", System.Data.SqlDbType.Int);
            BrojKartona.Value = brojKartona;
            list.Add(BrojKartona);

            return list;
        }

      
        #endregion



    }
}
