using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            StartUp();
        }

        public async void StartUp()
        {
            grid = new Grid { RowSpacing = 10 };

            var item = new StackLayout();
            item.Orientation = StackOrientation.Vertical;
            var label = new Label { Text = "test" };
            for (int i = 0; i < 11; i++)
            {
                grid.Children.Add(label, 0, i);
            }

            using (HttpClient client = new HttpClient())
            {
                string url = "http://77.55.222.217:3008/all/";

                var input = await client.GetAsync(url);

                List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(input.Content.ReadAsStringAsync().Result);
                int temp = 0;
                foreach (var order in orders)
                {
                    if (temp == 0)
                    {
                        order.BoxColor = "Gray";
                        temp = 1;
                    }
                    else
                    {
                        order.BoxColor = "White";
                        temp = 0;
                    }
                }
                list.ItemsSource = orders;
                
            }
        }
        private void orderButton_Clicked(object sender, EventArgs e)
        {
            var order = list.SelectedItem as Order;
            ContentPage orderPage = new OrderPage(order);
            Application.Current.MainPage = orderPage;
        }
    }
}