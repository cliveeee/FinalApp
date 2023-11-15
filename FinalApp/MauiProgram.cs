using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Xe.AcrylicView;

namespace FinalApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			}) .UseMauiCommunityToolkit()
               .UseAcrylicView();
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

