using Laborator7.Models;
using Microsoft.Maui.Devices.Sensors;
using Plugin.LocalNotification;

namespace Laborator7;


public partial class ShopPage : ContentPage
{
	public ShopPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var shop = (Shop)BindingContext;
        await App.Database.SaveShopAsync(shop);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var shop = (Shop)BindingContext;
        await App.Database.DeleteShopAsync(shop);
        await Navigation.PopAsync();
    }

    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var shop = (Shop)BindingContext;
        var address = new Location(46.7731796289, 23.6213886738);

        // comentat pentru ca nu avemtoken pentru Geocoding API 
        //var locations = await Geocoding.GetLocationsAsync(address);

        var options = new MapLaunchOptions
        {
            Name = "Magazinul meu preferat"
        };
        var location = new Location(46.7731796289, 23.6213886738);
        // var myLocation = await Geolocation.GetLocationAsync();
        var myLocation = new Location(46.7731796289, 23.6213886738);

       /* var distance = myLocation.CalculateDistance(location, DistanceUnits.Kilometers);
        if (distance < 4)
        {
           var request = new NotificationRequest
           {
               Title = "Ai de facut cumparaturi in apropiere!",
                Description = address,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }
       */
        await Map.OpenAsync(location, options);
    }
}