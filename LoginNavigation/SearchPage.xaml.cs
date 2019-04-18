using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        async void OnSearchButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchEntry.Text))
            {
                emptyField.IsVisible = true;
                return;
            }
            await Navigation.PushAsync(new MainPage(searchEntry.Text));
            emptyField.IsVisible = false; //set this back to false when the user comes back to the page

        }
    }
}
