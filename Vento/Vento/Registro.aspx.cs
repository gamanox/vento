using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vento
{
    public partial class Registro : System.Web.UI.Page
    {
        [WebMethod]
        public static List<string> GetLocations(string hint)
        {
            List<string> result = new List<string>();
            string sConection = WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(sConection))
            {
                SqlCommand sqlCom = new SqlCommand("select location from [dbo].[locations] where location like 'hint%'", sqlCon);
                sqlCon.Open();
                SqlDataReader dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    result.Add(dr[0].ToString());
                }
                sqlCon.Close();
            }
            return result;
        }
        [WebMethod]
        public static List<string> GetOcupations(string hint)
        {
            List<string> result = new List<string>();
            string sConection = WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(sConection))
            {
                SqlCommand sqlCom = new SqlCommand("select ocupation from [dbo].[ocupations] where ocupation like 'hint%'", sqlCon);
                sqlCon.Open();
                SqlDataReader dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    result.Add(dr[0].ToString());
                }
                sqlCon.Close();
            }
            return result;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.DatePicker1.Culture = CultureInfo.GetCultureInfo("es-MX");
            //this.DatePicker1.SelectedDateChanged += new EventHandler(DatePicker1_DateChanged);
            if (IsPostBack)
            {
                bool register = true;
                //Foto
                if (!fuFoto.HasFile)
                {
                    lblFoto.Text = "*";
                    register = false;
                }
                else
                //Nombre
                if (txtNombre.Text == "")
                {
                    lblNombre.Text = "*";
                    register = false;
                }
                else
                {
                    lblNombre.Text = ""; 
                }
                //Edad
                if (txtEdad.Text == "")
                {
                    lblEdad.Text = "*";
                    register = false;
                }
                else
                {
                    lblEdad.Text = "";
                    DateTime dt;
                    //Obtener fecha de Nacimiento en formato dd/mm/YYYY
                    string[] fecha = txtEdad.Text.Split('/');
                    if (fecha.Length != 3)
                    {
                        register = false;
                        lblEdad.Text = "La fecha no tiene los campos correctos: dd/mm/aaaa.";
                    }
                    else
                    {
                        string fecha_original = fecha[0] + "/" + fecha[1] + "/" + fecha[2];
                        IFormatProvider culture = new System.Globalization.CultureInfo("es-MX", true);
                        dt = DateTime.Parse(fecha_original, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                        DateTime now = System.DateTime.Now;
                        int age2 = now.Year - dt.Year;
                        if (dt > now.AddYears(-age2)) age2--;
                        if (age2 < 18)
                        {
                            lblEdad.Text = "Menor de edad.";
                            register = false;
                        }
                    }
                }
                //Residencia
                if (txtResidencia.Text == "")
                {
                    lblResidencia.Text = "*";
                    register = false;
                }
                else
                {
                    lblResidencia.Text = "";
                }
                //Ocupación
                if (txtOcupacion.Text == "")
                {
                    lblOcupacion.Text = "*";
                    register = false;
                }
                else
                {
                    lblOcupacion.Text = "";
                }
                //Expeciencia
                if (txtExperiencia.Text == "")
                {
                    lblExperiencia.Text = "*";
                    register = false;
                }
                else
                {
                    lblExperiencia.Text = "";
                }
                //Email
                if (IsValidEmail(txtEmail.Text))
                {
                    lblEmail.Text = "*";
                    register = false;
                }
                else
                {
                    lblEmail.Text = "*";
                }
                //Teléfono
                if (txtTelefono.Text == "")
                {
                    lblTelefono.Text = "*";
                    register = false;
                }
                else
                {
                    lblTelefono.Text = "";
                }
                int chb1val=0;
                int chb2val=0;
                if(chb1.Checked==false && chb2.Checked==false)
                {
                    register = false;
                    lblRegistro.Text = "* Debes registrarte por lo menos en una opción.";
                }
                else
                {
                    if (chb1.Checked)
                    {
                        chb1val = 1;
                    }
                    if (chb2.Checked)
                    {
                        chb2val = 1;
                    }
                }
                if (register)
                { 
                    //puede registrarse.
                    //Guardar foto ahora que todos los datos se pueden guardar.
                    string it = HttpContext.Current.Server.MapPath("~/Images/assets/Fotos/Registro");
                    DateTime now_foto = System.DateTime.Now;
                    String foto_name = now_foto.ToString();//.Replace(' ', '');
                    foto_name = foto_name.Replace('/', ' ');
                    foto_name = foto_name.Replace(':', ' ');
                    foto_name = foto_name.Replace("p.m.", " ");
                    foto_name = foto_name.Replace("a.m.", " ");
                    foto_name = Regex.Replace(foto_name, @"\s+", "");
                    string ext = Path.GetExtension(fuFoto.FileName);
                    string filePath1 = it + "/FOTO_CATALOGO/" + foto_name + ext;
                    fuFoto.SaveAs(filePath1);
                    //Foto subida falta guardar.
                    string sConection = WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
                    using (SqlConnection sqlCon = new SqlConnection(sConection))
                    {
                        SqlCommand sqlCom = new SqlCommand("", sqlCon);
                        sqlCon.Open();
                        sqlCom.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
            }
        
        }
        protected void btnNext1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                lblEdad.Text = "*";
            }
        }
        #region datepicker
        /*void DatePicker1_DateChanged(object sender, EventArgs e)
        {

        }
        */
        #endregion
        #region Validación_mail
        bool invalid = false;
        public bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names. 
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper, RegexOptions.None);
            }
            catch (Exception)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format. 
            try
            {
                return Regex.IsMatch(strIn, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$", RegexOptions.IgnoreCase);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
        #endregion
    }
}