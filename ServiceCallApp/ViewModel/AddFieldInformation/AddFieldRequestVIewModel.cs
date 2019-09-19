using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using ServiceCallApp.Models.AddFieldInformation;
using Xamarin.Forms;

namespace ServiceCallApp.ViewModel.AddFieldInformation
{
    public class AddFieldRequestVIewModel
    {
        public ICommand OpenCameraCommand { get; set; }
        public ICommand SendPhotoCommand { get; set; }
        public ObservableCollection<PictureGridModel> Images { get; set; }

        public AddFieldRequestVIewModel()
        {

            OpenCameraCommand = new Command(async () => await OpenCamera());
            SendPhotoCommand = new Command(async () => await SendGalleryImage());


        }

        private async Task SendGalleryImage()
        {

            App.Current.MainPage.DisplayAlert("Sucess","Thanks file Uploaded","Ok");
            //HttpClient httpClient = new HttpClient();
            //MultipartFormDataContent form = new MultipartFormDataContent();


            //form.Add(new StringContent(username), "username");
            //    form.Add(new StringContent("samirgc112@gmail.com"), "email");
            //form.Add(new StringContent(password), "password");

           // form.Add(new ByteArrayContent(fileBytes, 0, fileBytes.Length), "profile_pic", "hello1.jpg");
          //  HttpResponseMessage response = await httpClient.PostAsync("https://hrms-chat.herokuapp.com/api/email/file", form);
            //response.EnsureSuccessStatusCode();
            //httpClient.Dispose();
            //string sd = response.Content.ReadAsStringAsync().Result;



        }

        private async Task OpenCamera()
        {
            try
            {
                await Plugin.Media.CrossMedia.Current.Initialize();
                if (!Plugin.Media.CrossMedia.Current.IsCameraAvailable || !Plugin.Media.CrossMedia.Current.IsTakePhotoSupported)
                {

                    return;
                }
                var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });


                if (photo != null)
                {
                    var Pic = new PictureGridModel();
                    Pic.ImgSrc = ImageSource.FromStream(() => { return photo.GetStream();});
                    Pic.ImgStream = ReadFully(photo.GetStream());
                    if (Images == null)
                       Images = new ObservableCollection<PictureGridModel>();
                    Images.Add(Pic);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //VisibleCamera = true;
        }

        public static string ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                try
                {
                    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
}
