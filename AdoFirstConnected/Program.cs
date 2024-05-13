namespace AdoFirstConnected
{
    internal class Program
    {

        public static void GotoContact()
        {
            ContactLayer cl = new ContactLayer();
            while (true)
            {
                Console.WriteLine("\nWhat you want to do? \n1: Want to Add contact to the AdressBook \n2: Want to Update contact to the AdressBook \n3: Want to Search person by their First Name \n4: Want to Delete contact to the AdressBook \n5: count of all persons \n6: Display all persons");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 0)
                {
                    Console.WriteLine("\nExiting from System");
                    break;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Contact Details");
                        Console.Write("Enter First Name: ");
                        string firstName = Console.ReadLine();


                        Console.Write("Enter Last Name: ");
                        string lastName = Console.ReadLine();

                        Console.Write("Enter Address: ");
                        string address = Console.ReadLine();

                        Console.Write("Enter City: ");
                        string city = Console.ReadLine();

                        Console.Write("Enter State: ");
                        string state = Console.ReadLine(); ;

                        Console.Write("Enter Zip: ");
                        string zip = Console.ReadLine();

                        Console.Write("Enter PhoneNumber: ");
                        string phone = Console.ReadLine();

                        Console.Write("Enter email: ");
                        string email = Console.ReadLine();

                        Console.Write("Enter Book Name: ");
                        string bookName = Console.ReadLine();

                        Contact c = new Contact(firstName, lastName, address, city, state, zip, phone, email, bookName);
                        cl.Insert(c);
                        break;

                    case 3:
                        Console.WriteLine("Enter Name to search");
                        cl.DisplayByName(Console.ReadLine());
                        break;

                    case 4:
                        Console.WriteLine("Enter name to delete");
                        cl.Delete(Console.ReadLine());
                        break;

                    case 6:
                        cl.DisplayAll();
                        break;


                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Address Book");
            GotoContact();
        }
    }
}