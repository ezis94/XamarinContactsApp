using Contacts.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Contacts
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = nameEntry.Text,
                Lastname = surnameEntry.Text,
                Email = emailEntry.Text,
                PhoneNumber = phoneEntry.Text,
                Address = addressEntry.Text,

            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Contact>();
                int rowsAdded = conn.Insert(contact);
            }
            Navigation.RemovePage(this);
        }
    }
}
