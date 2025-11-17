using System.Collections.Generic;
using MealPlannerApp;
using Xunit;

namespace ConsoleApp1.Tests
{
    public class ProgramServiceTests
    {
        private DataStore GetStore() => new DataStore();

        private ProgramService GetService(DataStore store)
        {
            return new ProgramService(store, new MealPlanner(store));
        }

        // ===============================================
        // TESTE 1 – CRIAR RECEITA
        // ===============================================
        [Fact]
        public void ProgramService_Should_Create_Recipe()
        {
            var store = GetStore();
            var service = GetService(store);

            var tags = new List<string> { "vegano", "leve" };
            var ingredients = new List<Ingredient>
            {
                new Ingredient("Tomate", 20, 2),
                new Ingredient("Alface", 5, 1)
            };

            var r = service.CreateRecipe("Salada", tags, ingredients);

            Assert.Equal("Salada", r.Name);
            Assert.Equal(2, r.Tags.Count);
            Assert.Equal(2, r.Ingredients.Count);
            Assert.Single(store.Recipes);
        }

        // ===============================================
        // TESTE 2 – LISTAR RECEITAS
        // ===============================================
        [Fact]
        public void ProgramService_Should_List_Recipes()
        {
            var store = GetStore();
            var service = GetService(store);

            store.Recipes.Add(new Recipe("A"));
            store.Recipes.Add(new Recipe("B"));

            var list = service.ListRecipes();

            Assert.Equal(2, list.Count);
        }

        // ===============================================
        // TESTE 3 – SUGESTÃO DE RECEITAS
        // ===============================================
        [Fact]
        public void ProgramService_Should_Suggest_Recipes_Based_On_Preference()
        {
            var store = GetStore();
            var service = GetService(store);

            var r1 = new Recipe("Veg Salada");
            r1.Tags.Add("vegano");

            var r2 = new Recipe("Carne Assada");

            store.Recipes.Add(r1);
            store.Recipes.Add(r2);

            var u = new User("Gabriel");

            var list = service.SuggestRecipes(u, "vegano", 10);

            Assert.Single(list);
            Assert.Equal("Veg Salada", list[0].Name);
        }

        // ===============================================
        // TESTE 4 – CRIAR MENU E LISTA DE COMPRAS
        // ===============================================
        [Fact]
        public void ProgramService_Should_Create_Menu_And_GroceryList()
        {
            var store = GetStore();
            var service = GetService(store);

            var r = new Recipe("Macarronada");
            r.AddIngredient(new Ingredient("Macarrão", 200, 3));
            r.AddIngredient(new Ingredient("Molho", 50, 1));

            store.Recipes.Add(r);

            var gl = service.CreateMenuWithGroceries("Jantar", new List<string> { "Macarronada" });

            var field = typeof(GroceryList).GetField("_items",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);

            var dict = (Dictionary<string, int>)field!.GetValue(gl)!;

            Assert.Equal(1, dict["Macarrão"]);
            Assert.Equal(1, dict["Molho"]);
        }

        // ===============================================
        // TESTE 5 – CALCULAR CALORIAS
        // ===============================================
        [Fact]
        public void ProgramService_Should_Calc_Calories()
        {
            var store = GetStore();
            var service = GetService(store);

            var r = new Recipe("Teste");
            r.AddIngredient(new Ingredient("A", 10, 1));
            r.AddIngredient(new Ingredient("B", 20, 2));

            store.Recipes.Add(r);

            var result = service.CalculateCalories("Teste");

            Assert.Equal(30, result);
        }

        // ===============================================
        // TESTE 6 – CALCULAR SUSTENTABILIDADE
        // ===============================================
        [Fact]
        public void ProgramService_Should_Calc_Sustainability()
        {
            var store = GetStore();
            var service = GetService(store);

            var r = new Recipe("Eco");
            r.AddIngredient(new Ingredient("A", 10, 3));
            r.AddIngredient(new Ingredient("B", 10, 5));

            store.Recipes.Add(r);

            var result = service.CalculateSustainability("Eco");

            Assert.Equal(4, result);
        }

        // ===============================================
        // TESTE 7 – ERRO AO CALCULAR RECEITA INEXISTENTE
        // ===============================================
        [Fact]
        public void ProgramService_Should_Throw_When_Recipe_Not_Found()
        {
            var store = GetStore();
            var service = GetService(store);

            Assert.Throws<System.Exception>(() => service.CalculateCalories("X"));
            Assert.Throws<System.Exception>(() => service.CalculateSustainability("X"));
        }
    }
}
