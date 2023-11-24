using h2a.Core.Editor.Interfaces;
using h2a.Core.Editor.Invokers;
using h2a.Core.Editor.Receiver;
using Microsoft.Extensions.DependencyInjection;

namespace h2a.Core.Editor;

public static class DependencyInjection
{
    public static void AddEditor(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IImageProcessor, ImageProcessor>()
            .AddSingleton<ICommandInvoker, CommandInvoker>();
    }
}