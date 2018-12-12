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
    public class PropertyCjenovnik:PropertyInterface
    {
        #region Atributi
        private int cjenovnikID;
        private string nazivUsluge;
        private decimal cijenaUsluge;
        private DateTime datumUspostavljanjaCijene;
        private int aktivno;
        #endregion


        #region Property
        [DisplayName("Cjenovnik ID")]
        [SqlName("CjenovnikID")]
        [PrimaryKey]
        public int CjenovnikID
        {
            get
            {
                return cjenovnikID;
            }
            set
            {
                cjenovnikID = value;
            }
        }

        [DisplayName("Naziv usluge")]
        [SqlName("NazivUsluge")]
    
        public string NazivUsluge
        {
            get
            {
                return nazivUsluge;
            }
            set
            {
                nazivUsluge = value;
            }
        }

        [DisplayName("Cijena usluge")]
        [SqlName("CijenaUsluge")]
        
        public decimal CijenaUsluge
        {
            get
            {
                return cijenaUsluge;
            }
            set
            {
                cijenaUsluge = value;
            }
        }

        [DisplayName("Datum uspostavljanja cijene")]
        [SqlName("DatumUspostavljanjaCijene")]
      
        public DateTime DatumUspostavljanjaCijene
        {
            get
            {
                return datumUspostavljanjaCijene;
            }
            set
            {
                datumUspostavljanjaCijene = value;
            }
        }

        [DisplayName("Aktivno")]
        [SqlName("Aktivno")]

        public int Aktivno
        {
            get
            {
                return aktivno;
            }
            set
            {
                aktivno = value;
            }
        }

        #endregion

        #region Kveriji
        public string GetSelectQuery()
        {
            return @"USE [Tim4]
                    GO

                    SELECT [CjenovnikID]
                          ,[NazivUsluge]
                          ,[CijenaUsluge]
                          ,[DatumUspostavljanjaCijene]
                          ,[Aktivno]
                      FROM [dbo].[Cjenovnik]
                    GO";
        }

        public string GetInsertQuery()
        {
            return @"USE [Tim4]
                    GO

                    INSERT INTO [dbo].[Cjenovnik]
                               ([NazivUsluge]
                               ,[CijenaUsluge]
                               ,[DatumUspostavljanjaCijene]
                               ,[Aktivno])
                         VALUES
                               @NazivUsluge
                               ,@CijenaUsluge
                               ,@DatumUspostavljanjaCijene
                               ,1)
                    GO
                    ";
        }

        public string GetUpdateQuery()
        {
            return @"USE [Tim4]
                    GO

                    UPDATE [dbo].[Cjenovnik]
                       SET [Aktivno] = 0
                     WHERE CjenovnikID = @CjenovnikID
                    GO

                    INSERT INTO [dbo].[Cjenovnik]
                               ([NazivUsluge]
                               ,[CijenaUsluge]
                               ,[DatumUspostavljanjaCijene]
                               ,[Aktivno])
                         VALUES
                               @NazivUsluge
                               ,@CijenaUsluge
                               ,GETDATE()
                               ,1)
                    GO
                    ";
        }

        public string GetDeleteQuery()
        {
            return @"USE [Tim4]
                    GO

                    UPDATE [dbo].[Cjenovnik]
                       SET [Aktivno] = 0
                     WHERE CjenovnikID = @CjenovnikID
                    GO";
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
