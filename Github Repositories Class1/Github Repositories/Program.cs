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