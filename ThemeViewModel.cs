using System.ComponentModel;
using TARpv23_MobiileApp.Resources.Styles;

namespace TARpv23_MobiileApp;

public class ThemeViewModel : INotifyPropertyChanged
{

    private ResourceDictionary _currentTheme;
    public ResourceDictionary CurrentTheme
    {
        get => _currentTheme;
        set
        {
            _currentTheme = value;
            OnPropertyChanged(nameof(CurrentTheme));
        }
    }

    public void ChangeTheme(Theme theme)
    {
        CurrentTheme = theme == Theme.Dark ? new DarkTheme() : new LightTheme();
        Application.Current.Resources = CurrentTheme;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}