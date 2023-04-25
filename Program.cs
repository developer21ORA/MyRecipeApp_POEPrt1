using System;
using System.Collections.Generic;

class Ingredient
{
    public string Name { get; set; }
    public decimal Quantity { get; set; }
    public string Unit { get; set; }

    public Ingredient(string name, decimal quantity, string unit)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
    }

    public override string ToString()
    {
        return Name + " " + Quantity + " " + Unit;
    }

    public void Scale(decimal factor)
    {
        Quantity *= factor;
    }
}

class Recipe
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Ingredient> Ingredients { get; set; }

    public Recipe(string name, string description, List<Ingredient> ingredients)
    {
        Name = name;
        Description = description;
        Ingredients = ingredients;
    }

    public void Display()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Description: " + Description);
        Console.WriteLine("Ingredients:");
        foreach (Ingredient ingredient in Ingredients)
        {
            Console.WriteLine("- " + ingredient);
        }
    }

    public void Scale(decimal factor, string ingredientName)
    {
        foreach (Ingredient ingredient in Ingredients)
        {
            if (ingredient.Name == ingredientName)
            {
                ingredient.Scale(factor);
            }
        }
    }
}

class RecipeProgram
{
    static void Main()
    {
        Console.WriteLine("Enter recipe information:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Number of ingredients: ");
        int numIngredients = int.Parse(Console.ReadLine());
        List<Ingredient> ingredients = new List<Ingredient>();
        for (int i = 0; i < numIngredients; i++)
        {
            Console.Write("Ingredient " + (i + 1) + " name: ");
            string ingredientName = Console.ReadLine();
            Console.Write("Quantity: ");
            decimal quantity = decimal.Parse(Console.ReadLine());
            Console.Write("Unit: ");
            string unit = Console.ReadLine();
            ingredients.Add(new Ingredient(ingredientName, quantity, unit));
        }

        Recipe recipe = new Recipe(name, description, ingredients);
        Console.WriteLine("\nRecipe created:");
        recipe.Display();

        Console.Write("Enter an ingredient to scale: ");
        string ingredientToScale = Console.ReadLine();
        Console.Write("Enter a scaling factor (0.5, 1, 2, or 3): ");
        decimal factor = decimal.Parse(Console.ReadLine());
        recipe.Scale(factor, ingredientToScale);
        Console.WriteLine("\nRecipe scaled by a factor of " + factor + " for " + ingredientToScale + ":");
        recipe.Display();
    }
}

