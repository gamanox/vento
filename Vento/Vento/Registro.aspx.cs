using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vento
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.DatePicker1.Culture = CultureInfo.GetCultureInfo("es-MX");
            //this.DatePicker1.SelectedDateChanged += new EventHandler(DatePicker1_DateChanged);
            if (IsPostBack)
            {
                bool register = true;
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
                        lblEdad.Text = "*";
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
                if (register)
                { 
                    //puede registrarse.

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