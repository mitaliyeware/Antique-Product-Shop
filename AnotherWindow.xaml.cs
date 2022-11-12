using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AnotherWindow.xaml
    /// </summary>
    //List<Product> items;
    
    public partial class AnotherWindow : Window
    {
        double total_amt;
        public AnotherWindow()
        {
            InitializeComponent();
        }
        private void Lbx_Items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //items = new List<Prod> { new Prod { Name = "Hans", image = "a.png" },
            //new Prod { Name = "Steven", image = "a.png" },
            //new Prod { Name = "Rose", image = "a.png" },
            //new Prod { Name = "Kens", image = "a.png" }};

            Lbx_Items.ItemsSource = App.items;
            //items = MyStorage.ReadXML<List<Prod>>("listprod.xml");
            //if (items == null)
            //{
            //    items = new List<Prod>();
            //}

            //MyStorage.WriteXml<List<Prod>>(items, "listprod.xml");
            Lbx_existingusers.ItemsSource = App._euser;

            //App._euser.Add(usr);

        }

        private void D_users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var usr = new User { name = "New User", emailid = "newuser@gmail.com", address = "Germany", birthdate = DateTime.Today };
            //App._euser.Add(usr);



            //Product newProduct = new User { name = AddUserName.Text, Value = double.Parse(AddProductPrice.Text), ItemsLeft = int.Parse(AddProductTotalItems.Text), Description = AddProductDescription.Text, ImagePath = newProductFileName, GiftFor = giftForcomboAdd.Text, Ocassion = ocassionAdd.Text };
            //App._euser.Add(newProduct);
            var usr = new User { name = "New User", emailid = "newuser@gmail.com", address = "Germany", birthdate = DateTime.Today };
            App._euser.Add(usr);
            Lbx_existingusers.SelectedItem = usr;
            Lbx_existingusers.ScrollIntoView(usr);

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Owner.Visibility = Visibility.Collapsed;
            MyStorage.WriteXml<ObservableCollection<User>>(App._euser, "userss.xml");
            MyStorage.WriteXml<ObservableCollection<Product>>(App.items, "listprod.xml");
            
            //MyStorage.WriteXml<ObservableCollection<User>>(App._euser, "userss.xml");
        }

        private void Btn_cart(object sender, RoutedEventArgs e)
        {
            var itm = Lbx_Items.SelectedItem as Product;
            if (itm == null)
            {
                MessageBox.Show("Please select an item!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                total_amt = total_amt + itm.price;
                CartProduct(Lbx_Items, Lbx_cart);
                
            }
            totalAmountText.Text = total_amt.ToString();
        }

        private void CartProduct(ListBox lbx_Items, ListBox lbx_cart)
        {
            var cartproducts = lbx_Items.SelectedItems;
            foreach (var item in cartproducts)
            {
                lbx_cart.Items.Add(item);
            }
            //Lbx_cart.ItemsSource = App.items;
            //throw new NotImplementedException();
        }

        private void confirm_order(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your order has been placed", "Thank You!!");
            var remove_prod = Lbx_Items.SelectedItem as Product;
            if (remove_prod == null)
            {
                MessageBox.Show("Please select a product to be deleted!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            App.items.Remove(remove_prod);
            Lbx_cart.Items.Clear();

        }

        private void Btn_buyscreen(object sender, RoutedEventArgs e)
        {
            var window_main = new MainWindow();
            Visibility = Visibility.Collapsed;
            window_main.ShowDialog();
            window_main.Owner = this;
        }

        private void Lbx_cart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_removecart(object sender, RoutedEventArgs e)
        {
            Lbx_cart.Items.Remove(Lbx_cart.SelectedItem);
            
            //var res = MessageBox.Show($"Do you really want to delete?", "warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            //if (res == MessageBoxResult.Yes)
            //{
            //    //var itemToRemove = deliveryproduct.FindIndex(x => x.deliveryID == (int)((System.Windows.FrameworkElement)sender).Tag);
            //    //totalAmount_farmer = totalAmount_farmer - deliveryproduct[itemToRemove].farmeramount;
            //    //totalAmount_coop = totalAmount_coop - deliveryproduct[itemToRemove].coopamount;
            //    //deliveryproduct.RemoveAt(itemToRemove);
            //    //addDelivery(deliveryproduct);
            //    //total_Amount_Farmer.Text = totalAmount_farmer.ToString();
            //    //total_Amount_coop.Text = totalAmount_coop.ToString();
            //}
        }

        private void Tbx_Filter_textchanged(object sender, TextChangedEventArgs e)
        {
            var lst = from m in App.items where m.name.ToLower().Contains(Tbx_Filter.Text.ToLower()) select m;
            Lbx_Items.ItemsSource = lst;
            
        }
    }
}
