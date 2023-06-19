using System;
namespace Question_1c
{
    public class myQueue // Circular queue implementation
    {
        // Variables
        private readonly int MaxSize = 10;
        private readonly Customer[] Buffer;
        private int head;
        private int tail;
        private int numItems;

       
        public myQueue()
        {
            Buffer = new Customer[MaxSize];
        }

        // Constructor to adjust queue size during creation
        public myQueue(int size)
        {
            MaxSize = size;
            Buffer = new Customer[size];
        }

        // Properties
        public int Head => head;
        public int Tail => tail;
        public int NumItems => numItems;

        // Enqueue method to add a customer to the queue
        public void Enqueue(Customer customer)
        {
            if (numItems == MaxSize)
            {
                Console.WriteLine("We have reached the maximum number of customers we can accomodate");
                return;
            }

            Buffer[tail] = customer;
            tail = (tail + 1) % MaxSize;
            numItems++;
        }

        // Method to remove and return the customer at the head of the queue
        public Customer Dequeue()
        {
            if (numItems == 0)
            {
                Console.WriteLine("There are currently no customers in this queue.");
                return null;
            }

            Customer headItem = Buffer[head];
            numItems--;
            head = (head + 1) % MaxSize;
            return headItem;
        }

        // Method for swapping two elements in the queue
        private void Swap(int pointer1, int pointer2)
        {
            Customer temp = Buffer[pointer1];
            Buffer[pointer1] = Buffer[pointer2];
            Buffer[pointer2] = temp;
        }

        // Method to reverse the order of the first k elements in the queue
        public void ReverseFirstKElements(int k)
        {
            if (k > numItems)
            {
                Console.WriteLine("Can't reverse by a number greater than the number of customers in the queue");
                return;
            }

            int pointer1 = head;
            int pointer2 = (head + k - 1) % MaxSize;
            int count = 0;

            while (count < k / 2)
            {
                Swap(pointer1, pointer2);
                pointer1 = (pointer1 + 1) % MaxSize;
                pointer2 = (pointer2 - 1 + MaxSize) % MaxSize;
                count++;
            }
        }

        // Method to check if the queue is empty
        public bool IsEmpty() => numItems == 0;

        // Method to check if the queue is full
        public bool IsFull() => numItems == MaxSize;

        // Method to get the queue buffer
        public Customer[] getCustomers() => Buffer;
    }
}

