using ShortestRouteFinder.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ShortestRouteFinder
{
    public static class RouteHelper
    {
        // Helper method to load the routes from the JSON file
        public static List<Route> LoadRoutesFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }

            string jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Route>>(jsonData) ?? [];

        }

        // BubbleSort algorithm with sorting order
        public static void BubbleSort(List<Route> routes, bool ascending)
        {
            int n = routes.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    bool shouldSwap = ascending
                        ? routes[j].Distance > routes[j + 1].Distance
                        : routes[j].Distance < routes[j + 1].Distance;

                    if (shouldSwap)
                    {
                        (routes[j], routes[j + 1]) = (routes[j + 1], routes[j]); // Using tuple to swap
                    }
                }
            }
        }

        // QuickSort algorithm with sorting order
        public static void QuickSort(List<Route> routes, int low, int high, bool ascending)
        {
            if (low < high)
            {
                int pi = Partition(routes, low, high, ascending);

                QuickSort(routes, low, pi - 1, ascending); // Before partition
                QuickSort(routes, pi + 1, high, ascending); // After partition
            }
        }

        private static int Partition(List<Route> routes, int low, int high, bool ascending)
        {
            var pivot = routes[high].Distance;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                bool condition = ascending
                    ? routes[j].Distance < pivot
                    : routes[j].Distance > pivot;

                if (condition)
                {
                    i++;
                    (routes[i], routes[j]) = (routes[j], routes[i]); // Using tuple to swap
                }
            }

            (routes[i + 1], routes[high]) = (routes[high], routes[i + 1]); // Using tuple to swap

            return i + 1;
        }
    }
}
