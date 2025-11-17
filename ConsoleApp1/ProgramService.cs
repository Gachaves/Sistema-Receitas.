using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlannerApp
{
    public class ProgramService
    {
        private readonly DataStore _store;
        private readonly MealPlanner _planner;

        public ProgramService(DataStore store, MealPlanner planner)
        {
            _store = store;
            _planner = planner;
        }

        
        // MÉTODOS UNIT TESTABLE (SEM CONSOLE)
        

        public Recipe CreateRecipe(string name, List<string> tags, List<Ingredient> ingredients)
        {
            var r = new Recipe(name);

            foreach (var t in tags)
                r.Tags.Add(t);

            foreach (var ing in ingredients)
                r.AddIngredient(ing);

            _store.Recipes.Add(r);

            return r;
        }

        public List<Recipe> ListRecipes()
        {
            return _store.Recipes.ToList();
        }

        public List<Recipe> SuggestRecipes(User user, string preference, int quantity)
        {
            user.AddPreference(preference);
            return _planner.SuggestRecipes(user, quantity);
        }

        public GroceryList CreateMenuWithGroceries(string menuName, List<string> recipeNames)
        {
            var menu = new Menu(menuName);

            foreach (var name in recipeNames)
            {
                var recipe = _store.Recipes.FirstOrDefault(x => x.Name == name);
                if (recipe != null)
                    menu.AddRecipe(recipe);
            }

            return GroceryList.GenerateFromMenu(menu);
        }

        public int CalculateCalories(string recipeName)
        {
            var calc = new NutritionCalculator();
            var r = _store.Recipes.FirstOrDefault(x => x.Name == recipeName);

            if (r == null)
                throw new Exception("Receita não encontrada");

            return calc.CalculateCalories(r);
        }

        public double CalculateSustainability(string recipeName)
        {
            var calc = new SustainabilityCalculator();
            var r = _store.Recipes.FirstOrDefault(x => x.Name == recipeName);

            if (r == null)
                throw new Exception("Receita não encontrada");

            return calc.CalculateScore(r);
        }
    }
}
