using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new RecipeOne();
            Console.WriteLine("Create recipe");
            Console.WriteLine(recipe.Spriredate.ToString("dd MMMM, yyyy"));
            recipe = new ContinueRecipeDays(recipe);
            recipe.SetDate(12);
            Console.WriteLine("Added 12 days to recipe");
            Console.WriteLine(recipe.Spriredate.ToString("dd MMMM, yyyy"));
            recipe = new ContinueRecipeMonths(recipe);
            recipe.SetDate(3);
            Console.WriteLine("Added 2 months to recipe");
            Console.WriteLine(recipe.Spriredate.ToString("dd MMMM, yyyy"));
            
            Console.ReadKey();
        }
    }
    /// <summary>
    /// Абстактний клас рецепту
    /// </summary>
    abstract class Recipe
    {
        private List<string> drugs;
        protected DateTime spireDate;
        public Recipe()
        {
            this.drugs = new List<string>() {"Ношпа","Синупрет"};
            this.spireDate = new DateTime();
            this.spireDate = DateTime.Now;
           // Console.WriteLine(this.spireDate.ToString("MMMM dd, yyyy"));
            this.spireDate = this.spireDate.AddDays(10);
           // Console.WriteLine(this.spireDate.ToString("MMMM dd, yyyy"));
        }
        public abstract void SetDate(int n);
        public DateTime Spriredate
        {
            get { return this.spireDate; }
        }
    }
    /// <summary>
    /// Перший тип рецептів
    /// </summary>
    class RecipeOne : Recipe
    {
        public RecipeOne():base()
        {}
        public override void SetDate(int n)
        { }
    }
    /// <summary>
    /// Абстрактиний клас декораторів для рецептів
    /// </summary>
    abstract class ConstinueRecipe : Recipe
    {
        protected Recipe recipe;
        public ConstinueRecipe(Recipe recipe)
        {
            this.recipe = recipe;
        }
    }
    /// <summary>
    /// Клас додавання днів до терміну придатності рецепту
    /// </summary>
    class ContinueRecipeDays : ConstinueRecipe
    {
        public ContinueRecipeDays(Recipe recipe):base(recipe)
        { }
        public override void SetDate(int n)
        {
            spireDate = spireDate.AddDays(n);
        }
    }
    /// <summary>
    /// Клас додавання місяців до терімну придатності рецепту
    /// </summary>
    class ContinueRecipeMonths : ConstinueRecipe
    {
        public ContinueRecipeMonths(Recipe recipe)
            : base(recipe)
        { }
        public override void SetDate(int n)
        {
            spireDate = spireDate.AddMonths(n);
        }
    }
}
