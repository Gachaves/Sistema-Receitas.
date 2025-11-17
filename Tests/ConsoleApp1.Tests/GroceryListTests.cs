using MealPlannerApp;
using Xunit;

namespace ConsoleApp1.Tests
{
    public class GroceryListTests
    {
        [Fact]
        public void GroceryList_Should_Generate_From_Menu()
        {
            var r = new Recipe("Teste");
            r.AddIngredient(new Ingredient("Tomate", 10, 2));
            r.AddIngredient(new Ingredient("Tomate", 10, 2)); // duplicado

            var menu = new Menu("Almoço");
            menu.AddRecipe(r);

            var gl = GroceryList.GenerateFromMenu(menu);

            var itemsField = typeof(GroceryList).GetField("_items",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);

            var dict = (System.Collections.Generic.Dictionary<string, int>)itemsField!.GetValue(gl)!;

            Assert.Equal(2, dict["Tomate"]);
        }
    }
}
