using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection connection;
        public Login()
        {
            InitializeComponent();
            connection = DependencyService.Get<Database>().GetConnection();
        }

        public static IEnumerable<Estudiante> Select_Where(SQLiteConnection db,string user, string password)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario = ? and Contraseña = ?", user, password);
        }

        private async void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = Select_Where(db, txtUsuario.Text, txtContraseña.Text);
                if (resultado.Count() > 0)
                {
                    await Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    await DisplayAlert("Error", "Usuario o contraseña incorrectos", "Cerrar");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {

        }
    }
}