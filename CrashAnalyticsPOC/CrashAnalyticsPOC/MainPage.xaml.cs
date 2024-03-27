using NewRelic.MAUI.Plugin;

namespace CrashAnalyticsPOC;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		LogExceptionToNewRelic();
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		CrossNewRelic.Current.CrashNow("Sample crash created for New Relic Testing");
    }

	private void LogExceptionToNewRelic()
	{
		try
		{
            throw new Exception("Sample exception to show logging.");
        }
		catch (Exception ex)
		{
			CrossNewRelic.Current.RecordException(ex);
        }
	}
}


