using System;
using System.Collections.Generic;
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

namespace Lab2_EF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MakdoknekEntities dazabannix = new MakdoknekEntities();

        bool ClientTableIsEnabled = false;
        bool MenuTableIsEnabled = false;
        bool BookingTableIsEnabled = false;

        public MainWindow()
        {
            InitializeComponent();
            DishNameTbx.IsEnabled = false;
            DishPriceTbx.IsEnabled = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // кнопка показа таблицы клиентов
        {
            ClientDgr.ItemsSource = dazabannix.Client.ToList();
            DishNameTbx.IsEnabled = false; // блок текстблока
            DishPriceTbx.IsEnabled = false;

            AddButton.IsEnabled = false; // блок кнопки добавления
            DeleteButton.IsEnabled = true; // анлок кнопки удаления

            ClientTableIsEnabled = true;
            MenuTableIsEnabled = false;
            BookingTableIsEnabled = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // кнопка показа таблицы меню
        {
            ClientDgr.ItemsSource = dazabannix.Menu.ToList();
            DishNameTbx.IsEnabled = true;
            DishPriceTbx.IsEnabled = true;

            AddButton.IsEnabled = true;
            DeleteButton.IsEnabled = true;

            ClientTableIsEnabled = false;
            MenuTableIsEnabled = true;
            BookingTableIsEnabled = false;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) // кнопка показа таблицы заказов
        {
            ClientDgr.ItemsSource = dazabannix.Booking.ToList();
            DishNameTbx.IsEnabled = false; // блок текстблока
            DishPriceTbx.IsEnabled = false;

            AddButton.IsEnabled = false; // блок кнопки добавления
            DeleteButton.IsEnabled = false;

            ClientTableIsEnabled = false;
            MenuTableIsEnabled = false;
            BookingTableIsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e) // кнопка добавления
        {
            Menu m = new Menu();
            m.Dish_name = DishNameTbx.Text;

            int price = Convert.ToInt32(DishPriceTbx.Text);
            m.Dish_price = price;

            dazabannix.Menu.Add(m);
            dazabannix.SaveChanges();
            ClientDgr.ItemsSource = dazabannix.Menu.ToList();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) // кнопка удаления
        {
            if (ClientTableIsEnabled == true) // если отображается таблица клиентов
            {
                if (ClientDgr.SelectedItem != null)
                {
                    dazabannix.Client.Remove(ClientDgr.SelectedItem as Client);
                    dazabannix.SaveChanges();
                    ClientDgr.ItemsSource = dazabannix.Client.ToList();
                }
            }
            if (MenuTableIsEnabled == true) // если отображается таблица меню
            {
                if (ClientDgr.SelectedItem != null)
                {
                    dazabannix.Menu.Remove(ClientDgr.SelectedItem as Menu);
                    dazabannix.SaveChanges();
                    ClientDgr.ItemsSource = dazabannix.Menu.ToList();
                }
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e) // кнопка изменения
        {
            dazabannix.SaveChanges();
        }
    }
}