using System;
using System.Collections.Generic;
using System.Linq;
using PizzaCalories.Common;

public class Pizza
{
    private string name;


    private Pizza()
    {
        this.Toppings = new List<Topping>();
    }

    public Pizza(string name)
        : this()
    {
        this.Name = name;
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (value.Length < 1 || value.Length > 15)
            {
                throw new Exception(GlobalConstants.InvalidPizzaNameLengthMessage);
            }

            this.name = value;
        }
    }

    public Dough PizzaDough { get; set; }

    public void Add(Topping topping)
    {
        if (this.Toppings.Count >= 10)
        {
            throw new Exception(GlobalConstants.InvalidPizzaNumberOfToppings);
        }

        this.Toppings.Add(topping);
    }

    public double PizzaCalories()
    {
        var totalToppingCalories = this.Toppings.Select(c => c.ToppingCalories())
            .Sum();

        return this.PizzaDough.DoughCalories() + totalToppingCalories;
    }

    private List<Topping> Toppings { get; }
}