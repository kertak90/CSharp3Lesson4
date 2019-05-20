using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.MVVM;

namespace TestPicker
{
    class Window2ViewModel : ViewModel
    {
        private string _TextProperty = "HelloWorld!!!";

        public string TextProperty
        {
            get => _TextProperty;
            //set
            //{
            //    if (Equals(_TextProperty, value))
            //        return;
            //    _TextProperty = value;
            //    OnPropertyChanged("TextProperty");
            //}
            set => Set(ref _TextProperty, value);
        }
    }
}
