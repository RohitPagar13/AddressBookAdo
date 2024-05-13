using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoFirstConnected
{
    internal class Contact
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string bookName { get; set; }

        public Contact(string firstName, string lastName, string address, string city, string state, string zip, string phone, string email, string bookName)
        {

            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phone = phone;
            this.email = email;
            this.bookName = bookName;

        }

        public Contact() { }

        public override string ToString()
        {
            return "AddressBook Name: " + bookName + ", First Name: " + firstName + ", Last Name: " + lastName + ", Address: " + address + ", City: " + city + ", State: " + state + ", Zip: " + zip + ", Phone No.: " + phone + ", Email: " + email;
        }
    }
}
