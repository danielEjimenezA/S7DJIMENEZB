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
    public partial class Elemento : ContentPage
    {
        private SQLiteAsyncConnection conn;
        private int idSelect;
        IEnumerable<Estudiante> RUpdate;
        IEnumerable<Estudiante> RDelete;
        public Elemento(int id)
        {
            InitializeComponent();
            idSelect = id;
            conn=DependencyService.Get<Database>().GetConnection();
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                RUpdate = Update(db, txtNombre.Text, txtUsuario.Text, txtContrasena.Text, idSelect);
                DisplayAlert("Alert", "Se Actualizo correctamente", "Cerrar");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alert", ex.Message, "Cerrar");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                RDelete = Delete(db, idSelect);
                DisplayAlert("Alert", "Se elimino correctamente", "Cerrar");
            }
            catch (Exception ex)
            {

                DisplayAlert("Alert", ex.Message, "Cerrar");
            }
        }

        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where Id = ?", id);
        }

        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string nombre, string usuario, string contrasenia, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante SET Name = ?, User = ?, Password = ? where Id = ?", nombre, usuario, contrasenia, id);
        }
    }
}