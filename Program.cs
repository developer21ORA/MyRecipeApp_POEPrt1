using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Xml.Linq;

//class created for ingredients
class Ingredients
{
    public string Name { get; set; }
    public decimal Quantity { get; set; }
    public string Unit { get; set; }

    public Ingredients(string name, decimal quantity, string unit)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
    }
    //overrides the difference in 'input' data types to displaying outputs as strings(ALL)
    public override string ToString()
    {
        return Name + " " + Quantity + " " + Unit;
    }
    //method to calculate scaled ingredient quantities
    public void Scale(decimal factor)
    {
        Quantity = Quantity * factor;
    }
}
internal class Recipe
{
    public int numOfIngr { get; set; }
    public int numOfSteps { get; set; }
    public List<Ingredients> Ingredients { get; set; }
    public string[] Steps { get; set; }

    public Recipe(int ingrNum, int numSteps, List<Ingredients> ingredients, string[] steps)
    {
        numOfIngr = ingrNum;
        numOfSteps = numSteps;
        Ingredients = ingredients;
        Steps = steps;
    }
    //below: method for displaying user's input
    public void RecipeDisplay()
    {
        Console.WriteLine("Ingredients: ");
        foreach (Ingredients ingredients in Ingredients)
        {
            Console.WriteLine("- " + ingredients);
        }
        Console.WriteLine("Steps: ");
        for (int i = 0; i < Steps.Length; i++)
        {
            Console.WriteLine((i + 1) + ". " + Steps[i]);
        }
    }
    public void Clear()
    {
        Recipe.ReferenceEquals(RecipeDisplay, null);

    }
}
        //method that enables user to factor their ingredient quantities

        //user input prompting is placed within the main class for execution
        class RecipeProgram
        {
            static void Main()
            {
                //displaying info to user on the purpose of the application
                Console.WriteLine("Hello User :) !!! ");
                Console.WriteLine("WELCOME TO OUR RECIPE APP." +
                    "This application allows you to store information for only ONE recipe. To begin, enter the following:  ");
                Console.WriteLine("\n");

                //Promp user for :
                // number of ingredients
                Console.WriteLine("Enter recipe information:");

                Console.Write("Number of ingredients: ");
                int numIngredients = int.Parse(Console.ReadLine());
                List<Ingredients> ingredients = new List<Ingredients>();
                for (int i = 0; i < numIngredients; i++)
                {
                    Console.Write("Ingredient " + (i + 1) + " name: ");
                    string name = Console.ReadLine();
                    Console.Write("Quantity: ");
                    decimal quantity = decimal.Parse(Console.ReadLine());
                    Console.Write("Unit: ");
                    string unit = Console.ReadLine();
                    ingredients.Add(new Ingredients(name, quantity, unit));
                }
                Console.WriteLine("Input number of steps: ");
                int numOfSteps = int.Parse(Console.ReadLine());
                string[] steps = new string[numOfSteps];
                for (int i = 0; i < numOfSteps; i++)
                {
                    Console.Write("Enter description of step " + (i + 1) + ": ");
                    steps[i] = Console.ReadLine();
                }

                Recipe recipe = new Recipe(numIngredients, numOfSteps, ingredients, steps);
                Console.WriteLine("\nRecipe created:");
                recipe.RecipeDisplay(); //method that displays user's recipe in full

                Console.Write("Enter an ingredient to scale: ");
                string ingredientName = Console.ReadLine();
                //Prompt user for a scaling factor to scale their recipe
                Console.Write("Enter a scaling factor (0.5, 1, 2, or 3): ");
                decimal factor = decimal.Parse(Console.ReadLine());
                //outer loop with inner if statement to scale an ingredient by a factor
                foreach (Ingredients ingredient in recipe.Ingredients)
                {
                    if (ingredient.Name == ingredientName)
                    {
                        ingredient.Scale(factor);
                    }
                }
                Console.WriteLine("\nRecipe scaled by a factor of " + factor + ":");
                Console.WriteLine("\nNew Recipe after scaling: ");
                recipe.RecipeDisplay();
                //prompt for user's option to input another recipe or exit application
                Console.WriteLine("Would you like to enter a NEW recipe? If yes, type (YES) or press (ENTER) to exit: ");
                string userInput = Console.ReadLine();
                if (userInput == "YES")
                {
                    
                    Console.WriteLine($"\n"); //sentencing spacing for user visibility.
                    Main(); //calling the main method that enables user to re-enter their recipe 
                }
                else
                {
                    Console.WriteLine("You've reached the end of this application. Thanks a mil for using our RECIPE APP, we " +
                        "greatly appreciate your time. GOODBYE!!!" +
                        ":-) ");
                }
            }
        } 
    



