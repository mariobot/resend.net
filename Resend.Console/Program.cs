// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Resend;

var services = new ServiceCollection();

services.AddOptions();
services.Configure<ResendClientOptions>( o =>
{
    o.ApiToken = Environment.GetEnvironmentVariable( "RESEND_APITOKEN" )!;
} );
services.AddHttpClient<ResendClient>();
services.AddTransient<IResend, ResendClient>();

var serviceProvider = services.BuildServiceProvider();

// Resolve and run the service
var resend = serviceProvider.GetService<IResend>();

var result = await resend.ApiKeyListAsync();

if ( result != null )
{
    Console.WriteLine( result.Content.Count() );
}