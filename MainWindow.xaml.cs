using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List<Product> products;
        DateTime y1 = new DateTime();
        Random rnd = new Random();
        public string newProductFileName;
        public static ObservableCollection<Product> ProductList = new ObservableCollection<Product>();


        //private int maxID;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Disp_Products.ItemsSource = App._namesInput;
            Disp_Products.ItemsSource = App.items;
        }
        private void AddImage(object sender, RoutedEventArgs e)
        {
            //Product img = new Product();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPEG|*.jpg";
            ofd.ValidateNames = true;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == true)
            {
                //string selectedFileName = dlg.FileName;
                //FileNameLabel.Content = selectedFileName;
                //BitmapImage bitmap = new BitmapImage();
                //bitmap.BeginInit();
                //bitmap.UriSource = new Uri(selectedFileName);
                //bitmap.EndInit();
                //ImageViewer1.Source = bitmap;
                newProductFileName = "/Images/" + ofd.SafeFileName;
                prod.ImagePath = newProductFileName;
                Image_prod.Source = new BitmapImage(new Uri("pack://application:,,,/" +
                "WpfApp1;component" + newProductFileName));
            }
            //if(App.items.Contains =  )
            //var prod = new Product { ImagePath = newProductFileName };
            //App.items.Add(prod);
            //newProductFileName = (ofd.FileName);
            // //.Source = new BitmapImage(newProductFileName);
            // Image_prod.Source = new BitmapImage(newProductFileName);

            // img = (Product)Disp_Products.SelectedItem;
            //var itemToRemove = ProductList.IndexOf(ProductList.Where(x => x.ID == (int)FirstOrDefault()));
        }

        private Product prod = null;
        private void Btn_Generate_Click(object sender, RoutedEventArgs e)
        {
            int maxId = 0;
            if (App.items.Count() > 0)
            {
                maxId = App.items.Max(x => x.ID);
            }
            prod = new Product
            {
                ID = maxId+1,
                name = "New Product",
                origin = "Asian",
                price = 0,
                originPeriod = y1.Year,
                condition = "Good",
                height_width = "Enter values in cm",
                description = "Product_Description",
                ImagePath = newProductFileName
            };
            App.items.Add(prod);

            this.DataContext = prod;

            Disp_Products.SelectedItem = prod;
            Disp_Products.ScrollIntoView(prod);

            //products = DisplayProducts(50);
            //D_Products.ItemsSource = products;
        }

        //private List<Product> DisplayProducts(int cnt)
        //{
        //    var list = new List<Product>();
        //    for (int i = 0; i < cnt; i++)
        //    {
        //        var originDate = rnd.Next(minYear, maxYear);

        //        var year = rnd.Next(minYear, maxYear);

        //        DateTime dt = DateTime.Today.AddYears(-year);
        //        dt = dt.AddDays(rnd.Next(365));
        //        var idx = rnd.Next(App._namesInput.Count - 1);

        //        var prod = new Product { name = App._namesInput[idx].name, price = App._namesInput[idx].price, originDate = dt, origin = App._namesInput[idx].origin };

        //        list.Add(prod);
        //    }
        //    return list;

        //    //throw new NotImplementedException();
        //}


        private void D_products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_Save(object sender, RoutedEventArgs e)
        {
            MyStorage.WriteXml<ObservableCollection<Product>>(App.items, "listprod.xml");
        }

        private void Tbx_Filter_textchanged(object sender, TextChangedEventArgs e)
        {
            var lst = from m in App.items where m.name.ToLower().Contains(Tbx_Filter.Text.ToLower()) select m;
            Disp_Products.ItemsSource = lst;
        }

        private void Btn_SellProducts(object sender, RoutedEventArgs e)
        {

            var win = new AnotherWindow();
            Visibility = Visibility.Collapsed;
            win.ShowDialog();
            win.Owner = this;
        }

        //private void Tbx_Filter_textchanged1(object sender, TextChangedEventArgs e)
        //{
        //    var lst1 = from m1 in App.items where m1.origin.ToLower().Contains(Tbx_Filter1.Text.ToLower()) select m1;
        //    Disp_Products.ItemsSource = lst1;
        //}


    }
}
