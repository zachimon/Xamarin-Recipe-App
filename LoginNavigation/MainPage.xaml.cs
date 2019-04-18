using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace LoginNavigation
{
	public partial class MainPage : ContentPage
	{
        //RecipeList recipes;
        public MainPage(string search)
        {
            InitializeComponent();
            GetRecipes(search);


        }

#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
        private async void GetRecipes(string search)
        {
            //var uri = new Uri("https://www.food2fork.com/api/search?key=d5a99efcee2509c99b3c350ac2c08f7b&q=chicken%20breast&page=2");
            var builder = new UriBuilder("https://www.food2fork.com/api/search");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["key"] = "d5a99efcee2509c99b3c350ac2c08f7b";
            query["q"] = search;
            builder.Query = query.ToString();
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(builder.Uri);
            {
                string content = await response.Content.ReadAsStringAsync();
                RecipeList list = JsonConvert.DeserializeObject<RecipeList>(content);
                foreach (Recipe recipe in list.recipes)
                {
                    recipe.title = HttpUtility.HtmlDecode(recipe.title); //changes things like &amp; to just &
                }
                listView.ItemsSource = list.recipes;
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e == null || ((ListView)sender).SelectedItem == null) return; // has been set to null, do not 'process' tapped event
            Recipe recipe = (Recipe)e.SelectedItem;
            var builder = new UriBuilder("https://www.food2fork.com/api/get");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["key"] = "d5a99efcee2509c99b3c350ac2c08f7b";
            query["rId"] = recipe.recipe_id;
            builder.Query = query.ToString();
            Debug.Write(builder.Uri);
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(builder.Uri).Result;

            string content = response.Content.ReadAsStringAsync().Result;
            RecipeDetail detail = JsonConvert.DeserializeObject<RecipeDetail>(content);
            await Navigation.PushAsync(new RecipePage(detail));
            ((ListView)sender).SelectedItem = null;
            /*
             Recipe recipe = (Recipe)e.SelectedItem;
             Uri uri = new Uri(recipe.source_url);
             Device.OpenUri(uri);
             ((ListView)sender).SelectedItem = null; // de-select the row
             */
        }

        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            //DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");

        }
    }
}
