using ShortestRouteFinder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ShortestRouteFinder
{
    public partial class MainWindow : Window
    {
        private readonly List<Route> routes;

        public MainWindow()
        {
            InitializeComponent();

            // Load routes from the file
            var loadedRoutes = RouteHelper.LoadRoutesFromFile("EuropeRoutes.json");

            // Remove duplicate routes
            routes = loadedRoutes?
                .GroupBy(route => new { route.Start, route.Destination, route.Distance })
                .Select(group => group.First())
                .ToList() ?? [];


            UpdateListBox(); // Display the routes initially
        }

        private void OnSortButtonClick(object sender, RoutedEventArgs e)
        {
            if (SortAlgorithmComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a sorting algorithm.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (OrderComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a sorting order.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string selectedAlgorithm = ((ComboBoxItem)SortAlgorithmComboBox.SelectedItem).Content?.ToString() ?? string.Empty;
            string selectedOrder = ((ComboBoxItem)OrderComboBox.SelectedItem).Content?.ToString() ?? string.Empty;

            // Determine sorting order
            bool ascending = selectedOrder == "Shortest Distance";

            // Time tracking with high precision
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            // Perform sorting based on user selection
            if (selectedAlgorithm == "Bubble Sort")
            {
                RouteHelper.BubbleSort(routes, ascending); // Call BubbleSort with sorting order
            }
            else if (selectedAlgorithm == "Quick Sort")
            {
                RouteHelper.QuickSort(routes, 0, routes.Count - 1, ascending); // Call QuickSort with sorting order
            }

            stopwatch.Stop();
            double elapsedTime = stopwatch.Elapsed.TotalMilliseconds; // High precision timing

            // Update the sorting time in the TextBlock
            SortingTimeTextBlock.Text = $"Sorting Time: {elapsedTime:F2} ms";

            // Show a popup with sorting time
            MessageBox.Show($"Sorting completed in {elapsedTime:F2} ms.", "Sorting Time", MessageBoxButton.OK, MessageBoxImage.Information);

            // Update the display after sorting
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            RoutesListBox.Items.Clear();
            foreach (var route in routes)
            {
                // Ensure both StartingPoint and Destination are displayed
                RoutesListBox.Items.Add($"{route.Start} -> {route.Destination} : {route.Distance} km");
            }
        }
    }
}
