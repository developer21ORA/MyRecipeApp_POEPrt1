using System;
using System.Collections;
using System.Collections.Generic;

//class created for ingredients
class Ingredients
{
    public string Name { get; set; }
    public decimal Quantity { get; set; }
    public string Unit { get; set; }
    public int Calories { get; set; }
    public string FoodGroup { get; set; }   //calories & food group added in PART 2

    public Ingredients(string name, decimal quantity, string unit, int calories, string foodGroup)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
        Calories = calories;
        FoodGroup = foodGroup;
    }

    public Ingredients(string? name, decimal quantity, string? unit)
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
    public List<string> Recipes { get; set; }
    public string[] Steps { get; set; }
    public string RecipeName { get; set; }

    public Recipe(int ingrNum, int numSteps, List<Ingredients> ingredients,List<string> recipes, string[] steps, string recipeName)
    {
        numOfIngr = ingrNum;
        numOfSteps = numSteps;
        Ingredients = ingredients;
        Steps = steps;
        Recipes = recipes;
        RecipeName = recipeName;
    }

    public Recipe(string? recipeName)
    {
        RecipeName = recipeName;
    }

    public Recipe(int numIngredients, int numOfSteps, List<Ingredients> ingredients, string[] steps)
    {
        this.numOfSteps = numOfSteps;
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
    public int CalculateTotalCalories()
    {
        int totalCalories = 0;
        foreach (Ingredients ingredients in Ingredients)
        {
            totalCalories += ingredients.Calories;
        }
        return totalCalories;
    }
    
}

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
        recipe.RecipeDisplay();//END OF PART 1 !



        //PART 2 BEGINS HERE WHERE: User inputs unlimited number of recipes

        List<Recipe> newRecipes = new List<Recipe>();  //a list to store users' recipes

        while (true)
        {
            Console.WriteLine("Enter the name of the recipe OR type ('exit') to quit: ");
            string recipeName = Console.ReadLine();

            if (string.Equals(recipeName, "exit", StringComparison.OrdinalIgnoreCase))
                break;

        
            Recipe recipes = new Recipe(recipeName);
            
        while (true)
            {
                Console.WriteLine("Input the name of ingredient OR type ('done') to end recipe input>>>");
                string ingrName = Console.ReadLine();

                if (string.Equals(recipeName, "done", StringComparison.OrdinalIgnoreCase))
                    break;

                Console.Write("Please enter the number of calories for the ingredient: ");
                int calories = int.Parse(Console.ReadLine());

                Console.Write("Please enter the number of calories for the ingredient: ");
                string foodGroup = Console.ReadLine();

                Ingredients ingredient = new Ingredients(ingrName, calories, foodGroup, calories, foodGroup);
                recipe.Ingredients.Add(ingredient);
            }
            
            newRecipes.Add(recipes);
        }
        Console.WriteLine("All recipes: ");
        newRecipes.Sort((r1, r2) => string.Compare(r1.RecipeName, r2.RecipeName,StringComparison.OrdinalIgnoreCase));

        foreach (Recipe recipeName in newRecipes)
        {
            Console.WriteLine(recipeName);
        }

        Console.WriteLine("Enter the name of the recipe in order to display its details: ");
        string selectedRecipeName = Console.ReadLine();

        Recipe selectedRecipe = newRecipes.Find(r => string.Equals(r.RecipeName, selectedRecipeName, StringComparison.OrdinalIgnoreCase));
        if (selectedRecipe != null)
        {
            Console.WriteLine("Recpe Details for " + selectedRecipe.RecipeName + ":");
            foreach(Ingredients ingredient in selectedRecipe.Ingredients)
            {
                Console.WriteLine("Ingredient: " + ingredient.Name);
                Console.WriteLine("Calories: " + ingredient.Calories);
                Console.WriteLine("Ingredient: " + ingredient.FoodGroup);
            }

            int totalCalories = selectedRecipe.CalculateTotalCalories();
            Console.WriteLine("Total Calories within this ingredient: " + totalCalories);

            if(totalCalories > 300)
            {
                Console.WriteLine("WARNING: The total calories of this recipe exceed 300!!!");
            }
        }
        else
        {
            Console.WriteLine("RECIPE NOT FOUND!");
        }
        }

    }
    
    



        
    
    



