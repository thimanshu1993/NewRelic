namespace CrashAnalyticsPOC;
using NewRelic.MAUI.Plugin;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

        CrossNewRelic.Current.HandleUncaughtException();
        CrossNewRelic.Current.TrackShellNavigatedEvents();

        // Set optional agent configuration
        // Options are: crashReportingEnabled, loggingEnabled, logLevel, collectorAddress, crashCollectorAddress
         AgentStartConfiguration agentConfig = new AgentStartConfiguration(true, true, LogLevel.INFO, "mobile-collector.newrelic.com", "mobile-crash.newrelic.com");

        if (DeviceInfo.Current.Platform == DevicePlatform.Android)
        {
            CrossNewRelic.Current.Start("AA01a01d918d9a37a252fa1c240cc66800e6d60b97-NRMA");
            // Start with optional agent configuration 
            // CrossNewRelic.Current.Start("<YOUR_ANDROID_TOKEN>", agentConfig);
        }
        else if (DeviceInfo.Current.Platform == DevicePlatform.iOS)
        {
            CrossNewRelic.Current.Start("AA99222da157237e14a60d22d6e96a09a80c68efc7-NRMA");
            // Start with optional agent configuration 
            // CrossNewRelic.Current.Start("<YOUR_IOS_TOKEN>", agentConfig);
        }
    }
}