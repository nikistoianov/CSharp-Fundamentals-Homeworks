using System;
using System.Collections.Generic;
using System.Text;

public class Person
{    
    private string name;
    private double money;
    List<Product> products;

    public string Name
    {
        get { return name; }
        private set
        {
            if (value == null || value.Trim() == "")
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }    

    public double Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    public string BuyProduct(Product product)
    {
        if (product.Cost > Money)
        {
            return $"{Name} can't afford {product.Name}";
        }

        products.Add(product);
        Money -= product.Cost;
        return $"{Name} bought {product.Name}";
    }

    public Person(string name, double money)
    {
        Name = name;
        Money = money;
        products = new List<Product>();
    }

    public Person(string[] args) : this(args[0], double.Parse(args[1])) { }

    public Person(string personInput) : this(personInput.Split('=')) { }

    public override string ToString()
    {
        string productsString = "Nothing bought";
        if (products.Count > 0)
        {
            productsString = string.Join(", ", products);
        }
        return $"{Name} - {productsString}";
    }
}
