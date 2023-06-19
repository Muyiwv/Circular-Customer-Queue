// Namespace declaration
namespace Question_1c;

// Internal class declaration
internal class Program
{
    // Main method
    static void Main(string[] args)
    {
        // Variable to control the loop
        bool isRunning = true;

        // Create an instance of the CustomerQueue class
        myQueue myQueue = new myQueue();

        // Display app options to the user
        Console.WriteLine("Hi there! This is a queue app and below is a list of things you can do on this app?\n");

        // Main loop
        while (isRunning)
        {
            // Display menu options
            Console.WriteLine("1. Add a customer to the queue");
            Console.WriteLine("2. Remove customer from the queue");
            Console.WriteLine("3. Show number of customers in the queue");
            Console.WriteLine("4. Show all customers in the queue");
            Console.WriteLine("5. Reverse first K elements");
            Console.WriteLine("6. I'm done, close the app\n");

            // Prompt user for input
            Console.Write("What would you like to do?: ");
            string input = Console.ReadLine();

            // Check if user entered anything
            if (input == null)
            {
                Console.WriteLine("You must select an option or select 6 to close the app.\n");
                continue;
            }

            // Check if user input is a valid integer
            if (!int.TryParse(input, out int userChoice))
            {
                Console.WriteLine("You can only enter a number, please select a number.\n");
                continue;
            }

            // Handle user's choice
            switch (userChoice)
            {
                case 1:
                    // Prompt user for customer's name
                    Console.Write("What is the customer's name?: ");
                    string customerName = Console.ReadLine();

                    // Prompt user for customer's age
                    Console.Write("How old is the Customer?: ");
                    if (!int.TryParse(Console.ReadLine(), out int customerAge))
                    {
                        Console.WriteLine("The customers age must be a number. eg. 20,40 etc.\n");
                        break;
                    }

                    // Create a new Customer object
                    Customer customer = new Customer(customerName, customerAge);

                    // Enqueue the customer into the customerQueue
                    myQueue.Enqueue(customer);
                    Console.WriteLine("The customer has been added to the queue.\n");
                    break;

                case 2:
                    // Check if the queue is empty
                    if (myQueue.IsEmpty())
                    {
                        Console.WriteLine("There are currently no customers in this queue.\n");
                    }
                    else
                    {
                        // Dequeue a customer from the customerQueue
                        Customer removedCustomer = myQueue.Dequeue();
                        Console.WriteLine($"{removedCustomer.Name}, was removed from the queue.\n");
                    }
                    break;

                case 3:
                    // Display the number of customers in the queue
                    Console.WriteLine($"There are {myQueue.NumItems} customer(s) in the queue.\n");
                    break;

                case 4:
                    // Display all customers in the queue
                    Console.WriteLine("Showing all customers:\n");
                    int counter = 1;
                    for (int i = myQueue.Head; i != myQueue.Tail; i++)
                    {
                        Customer cust = myQueue.getCustomers()[i];
                        Console.WriteLine($"{counter} : Name: {cust.Name} : Age:{cust.Age}");
                        counter++;
                    }
                    Console.WriteLine();
                    break;

                case 5:
                    // Prompt user for the number of customers to reverse
                    Console.WriteLine("What number of customers would you like to reverse?: ");
                    if (!int.TryParse(Console.ReadLine(), out int k))
                    {
                        Console.WriteLine("You don't have enough customers in the queue to reverse by this number. Please try again!\n");
                        break;
                    }

                    // Reverse the first K elements in the customerQueue
                    myQueue.ReverseFirstKElements(k);
                    Console.WriteLine("Action completed. Please view the list to see results.\n");
                    break;

                case 6:
                    // Exit the application
                    Console.WriteLine("Goodbye, see you again soon.....\n");
                    return;

                default:
                    Console.WriteLine("You can't perform that action. Please try again.\n");
                    break;
            }
        }
    }
}
