
namespace TARpv23_MobiileApp;

public partial class KaameraPage : ContentPage
{
	public KaameraPage()
	{
		InitializeComponent();
	}

    //Pildi teeme
    private async void Button_ClickedAsync(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult myPhoto = await MediaPicker.Default.CapturePhotoAsync();
            //FileResult myPhoto = await MediaPicker.Default.PickPhotoAsync();
            if (myPhoto != null)
            {
                // Pildi salvestamine.
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, myPhoto.FileName);
                using Stream sourceStream = await myPhoto.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);
                await sourceStream.CopyToAsync(localFileStream);
                await Shell.Current.DisplayAlert("OOPS", localFileStream.Name, "OK");
            }
        }
        else
        {
            await Shell.Current.DisplayAlert("OOPS", "Midagi läks valesti", "OK");
        }
    }
}