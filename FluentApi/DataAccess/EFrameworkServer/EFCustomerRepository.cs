﻿using FluentApi.Domain.Abstractions;
using FluentApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.DataAccess.EFrameworkServer
{
    public class EFCustomerRepository : ICustomerRepository
    {
        public void AddData(Customer data)
        {
            using (var context=new MyContext())
            {
                context.Customers.Add(data);
                context.SaveChanges();
            }
        }

        public void DeleteData(Customer data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Customer> GetAllData()
        {
            var customers = new ObservableCollection<Customer>();
            using (var context=new MyContext())
            {
                customers = new ObservableCollection<Customer>(context.Customers);
            }
            return customers;
        }

        public Customer GetData(int id)
        {
            using (var context =  new MyContext())
            {
                var data = context.Customers.Include("Orders").FirstOrDefault(c => c.Id == id);
                return data;
            }
        }

        public void UpdateData(Customer data)
        {
            throw new NotImplementedException();
        }
    }
}
