using Java.Util;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AptGenie.ViewModels
{
    public class AddAptVM : INotifyPropertyChanged
    {
        byte[] imgArr;
        public AddAptVM()
        {
            SubmitApt = new Command(async () =>
            {
                try
                {
                    #region Field validations
                    if (aptName.Trim() == "" || aptName == null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Alert", "Apartment name cannot be blank", "OK");
                        return;
                    }
                    if (address.Trim() == "" || address == null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Alert", "Address cannot be blank", "OK");
                        return;
                    }
                    if (price == 0)
                    {
                        await Application.Current.MainPage.DisplayAlert("Alert", "Price cannot be blank or zero", "OK");
                        return;
                    }
                    #endregion
                    var location = await Geolocation.GetLastKnownLocationAsync();


                    //bool res = await Application.Current.MainPage.DisplayAlert("Geolocation", "Latitude = " + location.Latitude + " and " + "Longitude = " + location.Longitude, "Test AddApt API", "Cancel");

                    await PostForm(location.Latitude, location.Longitude);
                }
                catch (Exception ex)
                {

                }
            });


            AddImgCmd = new Command(async () =>
            {
                try
                {
                    FileData fileData = await CrossFilePicker.Current.PickFile();
                    if (fileData == null)
                        return; // user canceled file picking
                    fileNameLbl = fileData.FileName;
                    string fileName = fileData.FileName;
                    imgArr = fileData.DataArray;
                }
                catch (Exception ex)
                {

                }
            });
        }

        private async Task<string> PostForm(double x, double y)
        {
            try
            {

                HttpClient httpClient = new HttpClient();
                MultipartFormDataContent form = new MultipartFormDataContent();

                form.Add(new StringContent("1"), "is_active");
                form.Add(new StringContent("4"), "User_id");
                form.Add(new StringContent(aptName), "apt_name");
                form.Add(new StringContent(address), "apt_address");
                form.Add(new StringContent(price.ToString()), "price");
                //form.Add(new ByteArrayContent(imgArr,));
                form.Add(new StringContent(avlbltill.ToString()), "available_till");
                form.Add(new StringContent(x.ToString()), "lat");
                form.Add(new StringContent(y.ToString()), "lng");

                HttpResponseMessage response = await httpClient.PostAsync("https://aptgenie-266222.appspot.com/addApts", form);

                response.EnsureSuccessStatusCode();
                httpClient.Dispose();
                string sd = response.Content.ReadAsStringAsync().Result;
                return response.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string aptName { get; set; }
        public string address { get; set; }
        public double price { get; set; }
        public Date avlbltill { get; set; }

        public string fileNameLbl { get; set; }

        public Command AddImgCmd { get; }
        public Command SubmitApt { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
