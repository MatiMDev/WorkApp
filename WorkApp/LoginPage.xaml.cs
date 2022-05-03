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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            var login = loginEntry.Text;
            var password = passwordEntry.Text;
        }

        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "http://77.55.222.217:3008/login/";
                    Login login = new Login();
                    if (loginEntry.Text != "" && passwordEntry.Text != "")
                    {
                        login.login = loginEntry.Text;
                        login.password = passwordEntry.Text;
                        ObservableCollection<Login> collection = new ObservableCollection<Login>(new List<Login> { login });
                        var toSend = JsonConvert.SerializeObject(collection);
                        var respond = await client.PostAsync(url, new StringContent(toSend, Encoding.UTF8, "application/json"));
                        if (respond.Content.ReadAsStringAsync().Result == "true")
                        {
                            loginEntry.Text = "Logged in";
                            ContentPage menu = new Menu();
                            Application.Current.MainPage = menu;
                        }
                        else
                        {
                            //loginEntry.Text = respond.Content.ReadAsStringAsync().Result;
                            errorLabel.Text = "Incorrect credenatials, try again";
                        }
                    }
                    else
                    {
                        errorLabel.Text = "Enter credentials and try again";
                    }

                }
            }
            catch (Exception ex)
            {

                errorLabel.Text = ex.Message;
            }
            
        }
    }
}