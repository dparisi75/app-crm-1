using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using XamarinCRM.Statics;

namespace XamarinCRM.Pages.Test
{
    public class SearchBarPlacesPage : ContentPage
    {
        Label resultsLabel;
        private List<string> places;
        public SearchBarPlacesPage()
        {
            Label header = new Label
            {
                Text = "Imposta la località",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            var listView = new ListView();

            SearchBar searchBar = new SearchBar
            {
                Placeholder = "Cerca...",
            };
            //searchBar.SearchButtonPressed += OnSearchBarButtonPressed;

            searchBar.TextChanged += (sender, e) => Filter(listView, e.NewTextValue);
            searchBar.SearchButtonPressed += (sender, args) => Filter(listView, searchBar.Text);

           

            //listView.ItemsSource = new[] { "Bresc", "b", "c" };
            places = new List<string>();

            for (int i = 0; i < 100; i++)
            {
                places.Add(Faker.Address.City());
            }
            listView.ItemsSource = places;

            // Using ItemTapped
            listView.ItemTapped += async (sender, e) => {
                //await DisplayAlert("Tapped", e.Item + " row was tapped", "OK");
                //Debug.WriteLine("Tapped: " + e.Item);
                MessagingCenter.Send(this, MessagingServiceConstants.PLACE_FILTER_SET, e.Item.ToString());

                ((ListView)sender).SelectedItem = null; // de-select the row

                //close
                await Navigation.PopModalAsync();
            };


            resultsLabel = new Label();

            var dismissButton = new Button()
            {
                Text = "Chiudi"
            };
            dismissButton.Clicked += DismissButton_Clicked;

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    dismissButton,
                    header,
                    searchBar,
                    //new ScrollView
                    //{
                    //    Content = resultsLabel,
                    //    VerticalOptions = LayoutOptions.FillAndExpand
                    //}
                    listView
                }
            };
        }

        private async void DismissButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void Filter(ListView listView, string newTextValue)
        {
            listView.ItemsSource = string.IsNullOrEmpty(newTextValue)
            ? places
            : places.Where(itemSearch => itemSearch.ToLower().Contains(newTextValue.ToLower()))
            .ToList();
        }

        void OnSearchBarButtonPressed(object sender, EventArgs args)
        {
            // Get the search text.
            SearchBar searchBar = (SearchBar)sender;
            string searchText = searchBar.Text;

            // Create a List and initialize the results Label.
            //var list = new List<Tuple<Type, Type>>();
            //resultsLabel.Text = "";

            //// Get Xamarin.Forms assembly.
            //Assembly xamarinFormsAssembly = typeof(View).GetTypeInfo().Assembly;

            //// Loop through all the types.
            //foreach (Type type in xamarinFormsAssembly.ExportedTypes)
            //{
            //    TypeInfo typeInfo = type.GetTypeInfo();

            //    // Public types only.
            //    if (typeInfo.IsPublic)
            //    {
            //        // Loop through the properties.
            //        foreach (PropertyInfo property in typeInfo.DeclaredProperties)
            //        {
            //            // Check for a match
            //            if (property.Name.ToLowerInvariant().Contains(searchText.ToLowerInvariant()))
            //            {
            //                // Add it to the list.
            //                list.Add(Tuple.Create<Type, Type>(type, property.PropertyType));
            //            }
            //        }
            //    }
            //}

            //if (list.Count == 0)
            //{
            //    resultsLabel.Text =
            //        String.Format("No Xamarin.Forms properties with " +
            //                      "the name of {0} were found",
            //                      searchText);
            //}
            //else
            //{
            //    resultsLabel.Text = "The ";

            //    foreach (Tuple<Type, Type> tuple in list)
            //    {
            //        resultsLabel.Text +=
            //            String.Format("{0} type defines a property named {1} of type {2}",
            //                          tuple.Item1.Name, searchText, tuple.Item2.Name);

            //        if (tuple != list.Last())
            //        {
            //            resultsLabel.Text += "; and the ";
            //        }
            //    }

            //    resultsLabel.Text += ".";
            //}
        }
    }
}
