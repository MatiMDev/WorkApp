using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorkApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        HttpClient client = new HttpClient();
        string url = "http://192.168.1.147:3000/test/";
        public MainPage()
        {
            InitializeComponent();
        }

        public async void Post()
        {
            var order = new Order();
            //order.OrderDate = DateTime.Now.Date;
            //order.EndOrderDate = order.OrderDate.AddDays(7);
            var orders = new List<Order> { order };
            ObservableCollection<Order> ordersToSend;
            ordersToSend = new ObservableCollection<Order>(orders);
            var toSend = JsonConvert.SerializeObject(ordersToSend);
            HttpResponseMessage response = await client.PostAsync(url, new StringContent(toSend, Encoding.UTF8, "application/json"));
            mainText.Text = response.Content.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Post();
            mainText.Text += "Done! ";
        }
    }
}
