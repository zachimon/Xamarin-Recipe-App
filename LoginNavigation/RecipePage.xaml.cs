using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class RecipePage : ContentPage
    {
        public RecipePage(RecipeDetail recipe)
        {
            InitializeComponent();
            Debug.WriteLine(recipe.recipe.title);
            for (int i = 0; i < recipe.recipe.ingredients.Count; i++)
            {
               recipe.recipe.ingredients[i] = HttpUtility.HtmlDecode(recipe.recipe.ingredients[i]);
            }
            image_url.Source = recipe.recipe.image_url;
            listView.ItemsSource = recipe.recipe.ingredients;
        }
    }
}
