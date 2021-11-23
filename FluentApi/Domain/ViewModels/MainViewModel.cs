using FluentApi.Commands;
using FluentApi.Domain.Entities;
using FluentApi.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FluentApi.Domain.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public RelayCommand SelectCustomerCommand { get; set; }
        public RelayCommand SelectOrderCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand DeleteCustomerCommand { get; set; }
        public RelayCommand OrderNowCommand { get; set; }
        public RelayCommand DeleteOrderCommand { get; set; }

        public MainViewModel()
        {
            Customer = new Customer();
            AllCustomers = App.DB.CustomerRepository.GetAllData();
            AllOrders = App.DB.OrderRepository.GetAllData();
            DeleteCustomerCommand = new RelayCommand((sender) =>
            {


                App.DB.CustomerRepository.DeleteData(Customer);
                AllOrders = new ObservableCollection<Order>();
                AllCustomers = App.DB.CustomerRepository.GetAllData();
                MessageBox.Show("Deleted");

            }, (pred) =>
            {
                if (Customer != null && Customer.Id != 0)
                {
                    return true;
                }
                return false;
            }
            );
            SelectCustomerCommand = new RelayCommand((sender) =>
              {
                 
                      if (Customer != null)
                      {
                          var customer = App.DB.CustomerRepository.GetData(Customer.Id);
                          Customer = customer;
                          AllOrders = new ObservableCollection<Order>(Customer.Orders);

                      }
                 
              });   
            SelectOrderCommand = new RelayCommand((sender) =>
              {
                 
                      if (SelectedOrder != null)
                      {
                          var order = App.DB.OrderRepository.GetData(SelectedOrder.Id);
                          SelectedOrder = order;

                      }
                 
              });
            DeleteOrderCommand = new RelayCommand((sender) =>
            {
                App.DB.OrderRepository.DeleteData(SelectedOrder);
                AllOrders = App.DB.OrderRepository.GetAllData();
                MessageBox.Show("DELETED");


            }, (pred) =>
            {
                if (SelectedOrder != null && SelectedOrder.Id != 0)
                {
                    return true;
                }
                return false;
            }

            );
            OrderNowCommand = new RelayCommand((sender)=>
            {
                var order = new Order();
                order.OrderDate = DateTime.Now;
                order.CustomerId = Customer.Id;

                App.DB.OrderRepository.AddData(order);
                AllOrders = App.DB.OrderRepository.GetAllData();
                MessageBox.Show("Added");



            }, (pred) =>
            {
                if (Customer != null && Customer.Id != 0)
                {
                    return true;
                }
                return false;
            }
            );




            AddCommand = new RelayCommand((sender) =>
            {
                var item = App.DB.CustomerRepository.GetData(Customer.Id);
                if (item == null)
                {
                    App.DB.CustomerRepository.AddData(Customer);
                    AllCustomers = App.DB.CustomerRepository.GetAllData();
                    MessageBox.Show("Added");
                }
                else
                {
                    MessageBox.Show("This customer is already exist");
                }
                Customer = new Customer();

            }
                );

            ResetCommand = new RelayCommand((sender) =>
            {
                Customer = new Customer();
            }
                );
            UpdateCommand = new RelayCommand((sender) =>
            {
                App.DB.CustomerRepository.UpdateData(Customer);
                MessageBox.Show("Updated");
                Customer = new Customer();

            }, (s) =>
            {
                if (Customer?.Id == 0) { return false; }
                else
                {
                    return true;
                }
            });

        }
        private Customer customer;

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; OnPropertyChanged(); }
        }    

        private Order selectedOrder;

        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set { selectedOrder = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Customer> allCustomers;

        public ObservableCollection<Customer> AllCustomers
        {
            get { return allCustomers; }
            set { allCustomers = value; OnPropertyChanged(); }
        }
        private ObservableCollection<Order> allOrders;

        public ObservableCollection<Order> AllOrders
        {
            get { return allOrders; }
            set { allOrders = value; OnPropertyChanged(); }
        }

    }
}
