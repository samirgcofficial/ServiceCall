using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ServiceCallApp.Models.AddFieldInformation
{
    public class PictureGridModel : INotifyPropertyChanged
    {
        private ImageSource ImageSource { get; set; }
      
        public string ImgStream { get; set; }
        public int Id { get; set; }
        public PictureGridModel()
        {
            Id = new Random().Next();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public ImageSource ImgSrc
        {
            get
            {
                return ImageSource;
            }
            set
            {
                ImageSource = value;
                NotifyPropertyChanged();
            }
        }



    }
}
