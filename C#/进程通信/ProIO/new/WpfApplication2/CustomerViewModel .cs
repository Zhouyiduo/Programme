using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2
{
    public class Customer
    {
        public string Name
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }
    }

    public class CustomerViewModel : NotificationObject
    {
        private List<Customer> customers;

        private Customer selectedCustomer;

        public CustomerViewModel()
        {
            this.customers = new List<Customer>()
            {
                new Customer { Name = "Paul", Age = 28 },
                new Customer { Name = "Fred", Age = 37 },
                new Customer { Name = "Cherry", Age = 21 },
            };

            this.selectedCustomer = new Customer();
        }

        public List<Customer> Customers
        {
            get
            {
                return this.customers;
            }
            set
            {
                if (!this.customers.Equals(value))
                {
                    this.customers = value;
                    this.RaisePropertyChanged("Customers");
                    
                }
            }
        }

        public Customer SelectedCustomer
        {
            get
            {
                return this.selectedCustomer;
            }
            set
            {
                if (!this.selectedCustomer.Equals(value))
                {
                    this.selectedCustomer = value;
                    this.RaisePropertyChanged("SelectedCustomer");
                }
            }
        }
    }
}
