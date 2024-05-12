class MainProgram
{
    static void Main(string[] args)
    {
        Rentingmanagementsystem system = new Rentingmanagementsystem();
        //this is all of the items in which the customer can request for 
        system.AddItem("Ladder");
        system.AddItem("Lawnmower");
        system.AddItem("Chainsaw");

        while (true)
        {//the menu which will loop after you have created one of them 
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Would you like to rent an item?");
            Console.WriteLine("2. Check for any overdue rentals");
            Console.WriteLine("3. Display available items");
            Console.WriteLine("4. Display customers");
            Console.WriteLine("5. Add a new customer");
            Console.WriteLine("6. Leave");

            Console.Write("Please enter the number of your choice: ");//it will ask you to put in a number between 1 - 6 (depending on what option you would go for)
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Please enter the item name: ");//asking the customer for its name
                        string itemName = Console.ReadLine();
                        system.RentOutItem(itemName);
                        break;
                    case 2:
                        system.CheckOverdueRentals();
                        break;
                    case 3:
                        system.DisplayAvailableItems();
                        break;
                    case 4:
                        system.DisplayClients();
                        break;
                    case 5:
                        system.AddNewClient();
                        break;
                    case 6:
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
            }
        }
    }//the switch will handle any different cases which is based on what the customer selected , the case works with one of the options for the customer
}
}