using h2a.Core.LivePreview.Interfaces;
using h2a.Core.LivePreview.Invokers;
using h2a.Core.LivePreview.Receiver;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace h2a.Core.LivePreview;

public static class DependencyInjection
{
    public static void AddEditor(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IImageProcessor, ImageProcessor>()
            .AddSingleton<ICommandInvoker, CommandInvoker>();
    }
}
