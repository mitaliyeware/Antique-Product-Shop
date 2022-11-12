using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2;

namespace WpfApp1
{
    
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public static ObservableCollection<Product> _namesInput;
        public static ObservableCollection<Product> items;
        public static ObservableCollection<User> _euser;
        

        public void Application_Startup(object sender, StartupEventArgs e)
        {
            //var names = new List<Name>() { new Name { name = "Tower Bridge from the Thames", price = 1699, origin = "British" }, new Name { name = "Tower Bridge from the Thames1", price = 1299, origin="Dutch" }, new Name { name = "Tower Bridge from the Thames2", price = 899, origin="Arabic" } };

            //MyStorage.WriteXml<List<Name>>(names, "prodInfo.xml");
            //_namesInput = MyStorage.ReadXML<ObservableCollection<Product>>("prodInfo.xml");
            if (items == null)
            {
                items = new ObservableCollection<Product>();
            }
            items = MyStorage.ReadXML<ObservableCollection<Product>>("listprod.xml");
            _euser = MyStorage.ReadXML<ObservableCollection<User>>("userss.xml");
            if (_euser == null)
            {
                _euser = new ObservableCollection<User>();
            }

        }
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            //MyStorage.WriteXml<ObservableCollection<Product>>(_namesInput, "prodInfo.xml");
            MyStorage.WriteXml<ObservableCollection<Product>>(items, "listprod.xml");
        }
    }
}
