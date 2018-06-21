using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Innovative.SolarCalculator;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SolarDateTimeCalc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            appView.Title = "Dawn Calculator";
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var userDate = this.DateAndTime.Date;
            var latitude = Convert.ToDouble(this.Latitude.Text.ToString());
            var longitude = Convert.ToDouble(this.Longitude.Text.ToString());
            var time = CalculateDawn(userDate, latitude, longitude);
            this.OutputTime.Text = time;
        }

        private static string CalculateDawn(DateTimeOffset date, double latitudeInput, double longitudeInput, long elevation = 0)
        {
            try
            {
                SolarTimes solarTimes = new SolarTimes(date, latitudeInput, longitudeInput);
                DateTime sr = solarTimes.Sunrise;
                DateTime dt = Convert.ToDateTime(sr);
                string text = dt.ToString("h:mm:ss");
                return text;
            }
            catch
            {
                Console.WriteLine("Enter valid values. Error validation is yet to be written. ");
                throw;
            }
        }
    }
}
