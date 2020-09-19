using Microsoft.Practices.Unity;
using MVVMPhone.Models;
using MVVMPhone.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace MVVMPhone.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MobileContext db;
        IUnityContainer container = new UnityContainer();
        
        
        public MainWindow()
        {
            InitializeComponent();
            

            db = new MobileContext();
            db.Phones.Load(); // загружаем данные
            phonesGrid.ItemsSource = db.Phones.Local.ToBindingList(); // устанавливаем привязку к кэшу

            this.Closing += MainWindow_Closing;
        }

        // добавление
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            container.RegisterType<IPhone, Phone>();

            PhoneWindow phoneWindow = container.Resolve<PhoneWindow>();//new PhoneWindow(new Phone());
            if (phoneWindow.ShowDialog() == true)
            {
                Phone phone = phoneWindow.Phone;
                db.Phones.Add(phone);
                db.SaveChanges();
            }
        }

        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (phonesGrid.SelectedItem == null) return;
            // получаем выделенный объект
            Phone phone = phonesGrid.SelectedItem as Phone;

            PhoneWindow phoneWindow = new PhoneWindow(new Phone
            {
                Id = phone.Id,
                Category = phone.Category,
                Price = phone.Price,
                Title = phone.Title
            });

            if (phoneWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                phone = db.Phones.Find(phoneWindow.Phone.Id);
                if (phone != null)
                {
                    phone.Category = phoneWindow.Phone.Category;
                    phone.Title = phoneWindow.Phone.Title;
                    phone.Price = phoneWindow.Phone.Price;
                    db.Entry(phone).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (phonesGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < phonesGrid.SelectedItems.Count; i++)
                {
                    Phone phone = phonesGrid.SelectedItems[i] as Phone;
                    if (phone != null)
                    {
                        db.Phones.Remove(phone);
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
