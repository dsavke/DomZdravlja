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
        [DisplayName("Šifra cjenovnika")]
        [SqlName("CjenovnikID")]
        [GenerateComponent(ComponentType.Tekst)]
        [PrimaryKey]
        [Invisible(Use.Insert)]
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
        [GenerateComponent(ComponentType.Tekst)]
        [ValidatePattern(@"^[1-9a-zA-ZšđčćžŠĐČĆŽ\s.,]+$")]
        [MainSearch(null)]
        [Editing(Use.Insert)]
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
        [GenerateComponent(ComponentType.Tekst)]
        [ValidatePattern(@"^[0-9]{1,5}([\.]{1}[0-9]{1,5})?$")]
        [Editing(Use.Insert)]
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
        [GenerateComponent(ComponentType.Datum)]
        [DefaultPropertValue(TargetValue.Today, "")]
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
        [GenerateComponent(ComponentType.RadioButton)]
        [OpcijeRadioButton("Da", "Ne", 1, 0)]
        [Invisible(Use.Insert)]
        [Editing(Use.Update)]
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
            return @"
                    SELECT [CjenovnikID]
                          ,[NazivUsluge]
                          ,[CijenaUsluge]
                          ,[DatumUspostavljanjaCijene] 
                          ,[Aktivno]  
                      FROM [dbo].[Cjenovnik]
                    ";
        }

        public string GetInsertQuery()
        {
            return @"

                    INSERT INTO [dbo].[Cjenovnik]
                               ([NazivUsluge]
                               ,[CijenaUsluge]
                               ,[DatumUspostavljanjaCijene]
                               ,[Aktivno])
                         VALUES
                               (@NazivUsluge
                               ,@CijenaUsluge
                               ,GETDATE()
                               ,1)
                    ";
        }

        public string GetUpdateQuery()
        {
            return @"

                    UPDATE [dbo].[Cjenovnik]
                       SET [Aktivno] = @Aktivno,
                        [NazivUsluge] = @NazivUsluge
                     WHERE CjenovnikID = @CjenovnikID
                   
                    ";
        }

        public string GetDeleteQuery()
        {
            return @"

                    UPDATE [dbo].[Cjenovnik]
                       SET [Aktivno] = 0
                     WHERE CjenovnikID = @CjenovnikID
                    ";
        }
        #endregion

        #region Parametri

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter CjenovnikID = new SqlParameter("@CjenovnikID", System.Data.SqlDbType.Int);
            CjenovnikID.Value = cjenovnikID;
            list.Add(CjenovnikID);

            return list;
        }        

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter NazivUsluge = new SqlParameter("@NazivUsluge", System.Data.SqlDbType.NVarChar);
            NazivUsluge.Value = nazivUsluge;
            list.Add(NazivUsluge);

            SqlParameter CijenaUsluge = new SqlParameter("@CijenaUsluge", System.Data.SqlDbType.Money);
            CijenaUsluge.Value = cijenaUsluge;
            list.Add(CijenaUsluge);

            return list;
        }        

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter CjenovnikID = new SqlParameter("@CjenovnikID", System.Data.SqlDbType.Int);
            CjenovnikID.Value = cjenovnikID;
            list.Add(CjenovnikID);

            SqlParameter NazivUsluge = new SqlParameter("@NazivUsluge", System.Data.SqlDbType.NVarChar);
            NazivUsluge.Value = nazivUsluge;
            list.Add(NazivUsluge);

            SqlParameter AktivnoPar = new SqlParameter("@Aktivno", System.Data.SqlDbType.TinyInt);
            AktivnoPar.Value = aktivno;
            list.Add(AktivnoPar);

            return list;
        }
        
        #endregion

    }
}
