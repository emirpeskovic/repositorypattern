using CocktailsProject;
using CocktailsProject.Entities;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var databaseManager = new DatabaseManager(configuration);

var ingredientsManager = databaseManager.EntityManager<Ingredient>();

var ingredients = new List<Ingredient>
{
    new() { Name = "Lime Juice" },
    new() { Name = "Triple Sec" },
    new() { Name = "Tequila" },
    new() { Name = "Salt Rim" },
    new() { Name = "Crushed Ice" },
    new() { Name = "Lime Segment" },
    new() { Name = "Dark Rum" },
    new() { Name = "Orange Curacao" },
    new() { Name = "Almond Syrup" },
    new() { Name = "Lime Section" },
    new() { Name = "Maraschino Cherry" },
};

foreach (var ingredient in ingredients)
{
    ingredientsManager.Add(ingredient);
}

var drinkManager = databaseManager.EntityManager<Drink>();

var margarita = new Drink
{
    Name = "Margarita",
    Recipe = new Recipe
    {
        Ingredients = new Dictionary<Ingredient, double>
        {
            { ingredients[0], 60 },
            { ingredients[1], 30 },
            { ingredients[2], 60 },
            { ingredients[3], 1 },
            { ingredients[4], 1 },
            { ingredients[5], 1 },
        }
    }
};

drinkManager.Add(margarita);

var maitai = new Drink
{
    Name = "Mai Tai",
    Recipe = new Recipe
    {
        Ingredients = new Dictionary<Ingredient, double>
        {
            { ingredients[6], 50 },
            { ingredients[7], 15 },
            { ingredients[0], 10 },
            { ingredients[8], 60 },
            { ingredients[9], 1 },
            { ingredients[10], 1 },
            { ingredients[5], 1 },
        }
    }
};

drinkManager.Add(maitai);

var drinks = drinkManager.GetAll();

foreach (var drink in drinks)
{
    Console.WriteLine(drink.Name);
    
    foreach (var ingredient in drink.Recipe.Ingredients)
    {
        var unit = ingredient.Value > 1 ? "ml" : "part";
        Console.WriteLine($" - {ingredient.Value} {unit} of {ingredient.Key.Name}");
    }
}
