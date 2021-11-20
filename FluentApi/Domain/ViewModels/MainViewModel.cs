using FluentApi.Commands;
using FluentApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.Domain.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        public RelayCommand SelectCustomerCommand { get; set; }
        
        public MainViewModel()
        {
           
            AllCustomers = App.DB.CustomerRepository.GetAllData();
            AllOrders = App.DB.OrderRepository.GetAllData();

            SelectCustomerCommand = new RelayCommand((sender) =>
              {
                  var customer = App.DB.CustomerRepository.GetData(Customer.Id);
                  Customer = customer;
                  AllOrders = new ObservableCollection<Order>(Customer.Orders) ;
              });
        }
        private Customer customer;

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; OnPropertyChanged(); }
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
