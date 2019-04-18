using System;

using Xamarin.Forms;

namespace LoginNavigation
{
    public class RecipePage : ContentPage
    {
        public RecipePage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

