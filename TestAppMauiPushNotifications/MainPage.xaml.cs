namespace TestAppMauiPushNotifications;
using Microsoft.Maui.Controls.PlatformConfiguration;
#if IOS
using Plugin.Firebase.Auth.Platforms.iOS;
using Plugin.Firebase.Bundled.Platforms.iOS;
using Plugin.Firebase.CloudMessaging;
#else
using Plugin.Firebase.Auth.Platforms.Android;
using Plugin.Firebase.CloudMessaging;
using System.Threading.Tasks;
#endif
public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}


	private void OnCounterClicked(object sender, EventArgs e)
	{
      
        OnCounterClickedAsync().Wait();
	}
	private async Task OnCounterClickedAsync()
	{
		Console.WriteLine("Hello");
		
		await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();

#if ANDROID
		await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
		try 
		{


		var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
        await DisplayAlert("FCM token", token, "OK");
		}
		catch (Exception ex)
		{
		Console.WriteLine(ex.Message);
		}

#endif


        await Application.Current.MainPage.DisplayAlert("blabla", "", "");
    }
}

