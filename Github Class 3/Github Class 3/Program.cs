class TheItems
{//this class here shows the items which is avaiable for renting 
 //it has a constructor which will initiate the item and the name and its availability
    public string Name { get; }
    public bool Available { get; set; }

    public TheItems(string customername)
    {
        Name = customername;
        Available = true;
    }
}

class Customer
{//this class here shows the customer renting the item
 // the constructor will initiate the customer with the name and the email as well
    public string Name { get; }
    public string Email { get; }

    public Customer(string customername, string customeremail)
    {
        Name = customername;
        Email = customeremail;
    }
}

class Renting
{//this class is for renting the transaction 
 //it will initiate the renting retails for the customers
    public TheItems Item { get; }
    public Customer Client { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public double FinePerDay { get; }
    public double Fine { get; private set; }

    public Renting(TheItems items, Customer customer, DateTime thestartDate, int theduration)
    {//this will check if the rental is overdue and will then do a calculation a fine (if there is one)
        Item = items;
        Client = customer;
        StartDate = thestartDate;
        EndDate = StartDate.AddDays(theduration);
        FinePerDay = 10;
        Fine = 0;
    }

    public void CheckOverdue()
    {
        if (DateTime.Now > EndDate)
        {
            int anyoverdueDays = (int)(DateTime.Now - EndDate).TotalDays;
            Fine = anyoverdueDays * FinePerDay;
        }
    }
}