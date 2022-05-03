using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateOrderPage : ContentPage
    {
        public CreateOrderPage()
        {
            InitializeComponent();
        }

        private async void submitButton_Clicked(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://77.55.222.217:3008/post/";
                Order order = new Order();
                order.ClientName = clientName.Text;
                order.Name = orderName.Text;
                order.EndOrderDate = endDate.Date.ToString("yyyy-MM-dd");
                order.IsReady = false;
                order.IsStep1Done = false;
                order.IsStep2Done = false;
                order.IsStep3Done = false;
                order.IsStep4Done = false;
                order.OrderDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
                order.CreatorName = yourName.Text;
                ObservableCollection<Order> collection = new ObservableCollection<Order>(new List<Order> { order });
                var toSend = JsonConvert.SerializeObject(collection);
                ContentPage orderCreatedPage = new Page1(order);
                Application.Current.MainPage = orderCreatedPage;
                await client.PostAsync(url, new StringContent(toSend, Encoding.UTF8, "application/json"));
            }
        }
    }
}