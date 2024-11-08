
using ShortestRouteFinder.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ShortestRouteFinder
{
    public partial class MainWindow : Window
    {
        private List<Route> routes;

        public MainWindow()
        {
            InitializeComponent();
            routes = RouteHelper.LoadRoutesFromFile("routes.json");  // Load the JSON data using the helper
        }

        private void OnSortButtonClick(object sender, RoutedEventArgs e)
        {
            // Get the selected algorithm
            string selectedAlgorithm = ((ComboBoxItem)SortAlgorithmComboBox.SelectedItem).Content.ToString();

            // Sort based on user selection
            if (selectedAlgorithm == "Bubble Sort")
            {
                RouteHelper.BubbleSort(routes);  // Use BubbleSort from RouteHelper
            }
            else if (selectedAlgorithm == "Quick Sort")
            {
                RouteHelper.QuickSort(routes, 0, routes.Count - 1);  // Use QuickSort from RouteHelper
            }

            // Display sorted routes in the ListBox
            RoutesListBox.Items.Clear();
            foreach (var route in routes)
            {
                RoutesListBox.Items.Add($"{route.Start} -> {route.Destination} : {route.Distance} km");
            }
        }
    }
}