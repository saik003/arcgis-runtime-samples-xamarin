﻿// Copyright 2016 Esri.
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at: http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an 
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific 
// language governing permissions and limitations under the License.

using Esri.ArcGISRuntime.Mapping;
using System;
using Xamarin.Forms;

namespace ArcGISRuntimeXamarin.Samples.ChangeBasemap
{
    public partial class ChangeBasemap : ContentPage
    {
        // String array to store titles for the viewpoints specified above.
        private string[] titles = new string[]
        {
            "Topo",
            "Streets",
            "Imagery",
            "Ocean"
        };
        public ChangeBasemap ()
        {
            InitializeComponent ();

            Title = "Change basemap";

            // Create the UI, setup the control references and execute initialization 
            Initialize();
        }

        private async void OnChangeBasemapButtonClicked(object sender, EventArgs e)
        {
            // Show sheet and get title from the selection
            var selectedBasemap =
                await DisplayActionSheet("Select basemap", "Cancel", null, titles);

            // If selected cancel do nothing
            if (selectedBasemap == "Cancel") return;

            switch (selectedBasemap)
            {
                case "Topo":

                    // Set the basemap to Topographic
                    MyMapView.Map.Basemap = Basemap.CreateTopographic();
                    break;

                case "Streets":

                    // Set the basemap to Streets
                    MyMapView.Map.Basemap = Basemap.CreateStreets();
                    break;

                case "Imagery":

                    // Set the basemap to Imagery
                    MyMapView.Map.Basemap = Basemap.CreateImagery();
                    break;

                case "Ocean":

                    // Set the basemap to Imagery
                    MyMapView.Map.Basemap = Basemap.CreateOceans();
                    break;

                default:
                    break;
            }
        }

        private void Initialize()
        {
            // Create new Map with basemap and initial location
            Map myMap = new Map(Basemap.CreateTopographic());

            // Assign the map to the MapView
            MyMapView.Map = myMap;
        }
    }
}