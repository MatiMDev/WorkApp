using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void createOrderButton_Clicked(object sender, EventArgs e)
        {
            ContentPage ncop = new CreateOrderPage();
            Application.Current.MainPage = ncop;

        }

        private void listOrdersButton_Clicked(object sender, EventArgs e)
        {
            ContentPage list = new ListPage();
            Application.Current.MainPage = list;
        }
    }
}