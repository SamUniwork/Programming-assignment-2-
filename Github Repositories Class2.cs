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