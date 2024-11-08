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
            var json = File.ReadAllText("EuropeRoutes.json");
            return JsonSerializer.Deserialize<List<Route>>(json);
        }

        // BubbleSort algorithm
        public static void BubbleSort(List<Route> routes)
        {
            int n = routes.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (routes[j].Distance > routes[j + 1].Distance)
                    {
                        var temp = routes[j];
                        routes[j] = routes[j + 1];
                        routes[j + 1] = temp;
                    }
                }
            }
        }

        // QuickSort algorithm
        public static void QuickSort(List<Route> routes, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(routes, low, high);

                QuickSort(routes, low, pi - 1); // Before partition
                QuickSort(routes, pi + 1, high); // After partition
            }
        }

        private static int Partition(List<Route> routes, int low, int high)
        {
            var pivot = routes[high].Distance;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (routes[j].Distance < pivot)
                {
                    i++;
                    var temp = routes[i];
                    routes[i] = routes[j];
                    routes[j] = temp;
                }
            }

            var swap = routes[i + 1];
            routes[i + 1] = routes[high];
            routes[high] = swap;

            return i + 1;
        }
    }
}