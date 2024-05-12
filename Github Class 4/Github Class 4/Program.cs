class Rentingmanagementsystem
{//this class is to manage the renting system it checks if the item is being rented, it has the list of any avaiable items a 
 // a list of the customer and a list of the renting


    private List<TheItems> items = new List<TheItems>();
    private List<Customer> clients = new List<Customer>();
    private List<Renting> rentals = new List<Renting>();

    public void AddItem(string name)//this will add the new item to your inventory 
    {
        items.Add(new TheItems(name));
    }
    //class which creates a new customer
    public void AddNewClient()
    {
        Console.Write("Enter your full name: ");//ask the customer to enter its full name
        string name = Console.ReadLine();
        Console.Write("Enter your email address: ");//ask the customer to enter its email address
        string email = Console.ReadLine();
        clients.Add(new Customer(name, email));
        Console.WriteLine("Your information has been successfully recorded.");//informs the customer that all of the details was added 
    }

    public void RentOutItem(string desiredItem)//how the item is being rented to the customer 
    {
        TheItems item = items.Find(i => i.Name.Equals(desiredItem, StringComparison.OrdinalIgnoreCase) && i.Available);
        if (item == null)
        {
            Console.WriteLine("We apologize, but the requested item is currently unavailable.");//if the customer ask for a item it will output this msg if its not avaiable
            return;
        }

        Console.Write("Please enter the customer name: ");//asking the customer name 
        string clientName = Console.ReadLine();
        Customer client = clients.Find(c => c.Name.Equals(clientName, StringComparison.OrdinalIgnoreCase));
        if (client == null)
        {
            Console.WriteLine("The customer was not found. Please add customer details:");//it will output this if the customer was not found and will ask you to input some details
            AddNewClient();
            client = clients[clients.Count - 1];
        }

        Console.Write("Please enter a rental duration (in days): ");//this will ask you to pick how many days you would rent the item out for 
        int duration;
        if (!int.TryParse(Console.ReadLine(), out duration))
        {
            Console.WriteLine("This is an invalid duration.");// it will only output this message out if the days you have requested is invalid 
            return;
        }

        Renting rental = new Renting(item, client, DateTime.Now, duration);
        rentals.Add(rental);
        item.Available = false;
        Console.WriteLine($"{desiredItem} rented to {clientName} for {duration} days.");
    }

    public void CheckOverdueRentals()//this is how it checks for any overdue rentails and it will show any fines as well 
    {
        foreach (Renting rental in rentals)
        {
            rental.CheckOverdue();
            if (rental.Fine > 0)
            {
                Console.WriteLine($"Overdue item: {rental.Item.Name} for {rental.Client.Name}. Fine: £{rental.Fine}");
            }
        }
    }

    public void DisplayAvailableItems()// this will check for any avaiable items for the customer
    {
        Console.WriteLine("The available items are:");//this will output out the avaiable item for the customer 
        foreach (TheItems item in items)
        {
            if (item.Available)
            {
                Console.WriteLine(item.Name);
            }
        }
    }

    public void DisplayClients()//this is how the the customers name and email will be displayed 
    {
        Console.WriteLine("Clients:");
        foreach (Customer client in clients)
        {
            Console.WriteLine($"{client.Name} - {client.Email}");
        }
    }
}
