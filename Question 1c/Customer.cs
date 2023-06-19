using System;

namespace Question_1c
{
    public class Customer
    {
        private int age;        // Private field to store the age of the customer
        private string name;    // Private field to store the name of the customer

        // Constructor to initialize the customer object with a name and age
        public Customer(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        // Property to get or set the name of the customer
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Property to get or set the age of the customer
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        // Method to get the information of the customer as a formatted string
        public string GetInformation()
        {
            return $"Name: {this.name}, Age: {this.age}";
        }
    }
}

