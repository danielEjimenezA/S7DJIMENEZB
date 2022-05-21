using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7DJIMENEZB.Modelo;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S7DJIMENEZB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            try
            {
                var DatosRegistro = new Estudiante { Name = txtNombre.Text, User = txtUser.Text, Password = txtPassword.Text };
                con.InsertAsync(DatosRegistro);
            }
            catch (Exception)
            {

                throw;
            }
        }

        void limpiarFormulario()
        {
            txtNombre.Text = "";
            txtUser.Text = "";
            txtPassword.Text = "";
            DisplayAlert("Alert", "Se agrego correctamente", "Cerrar");
        }
    }
}