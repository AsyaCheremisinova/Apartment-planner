using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using System.Text.Json;
using Newtonsoft.Json;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace ApartmentPlanner
{
    public partial class MainPage : ContentPage
    {
        public List<Project> jsonContents { get; set; }
        public MainPage()
        {
            InitializeComponent();

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            var stream = assembly.GetManifestResourceStream("ApartmentPlanner.jsconfig.json");
           
            using (StreamReader sr = new StreamReader(stream))
            {
                var content = sr.ReadToEnd();
                var data = JsonConvert.DeserializeObject<RootProject>(content);
                jsonContents = data.Projects;            
            }
            ListViewProject.ItemsSource = jsonContents;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Menuu.IsVisible = true;
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            Menuu.IsVisible = false;
        }
    }
}
