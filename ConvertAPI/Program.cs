
using BLConverter.Services;
using DALConverter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddTransient<IConvertRepository, ConvertRepository>();
        services.AddTransient<IConvertService, ConvertService>();

    })
    .Build();
var builder = new ConfigurationBuilder()
                   .AddJsonFile($"appsettings.json", true, true);
var config = builder.Build();

try
{
    Console.WriteLine("Enter route to get convert");
    string route = Console.ReadLine();
    Console.WriteLine("Enter format to get convert");
    string format=Console.ReadLine();
    var convertService = host.Services.GetRequiredService<IConvertService>();
    convertService.Convert(route, format);
    Console.WriteLine("The file is created succesfull");
    Console.ReadKey();
}

catch (Exception Ex)
{
    Debug.Write("The Error in the Program" + Ex.Message);
    Console.WriteLine("The Error in the Program" + Ex.Message);
}





