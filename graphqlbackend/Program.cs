using gqlBackend.api.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HotChocolate;

var builder = WebApplication.CreateBuilder(args);

/*
builder.WebHost.ConfigureKestrel(opt =>
{
    opt.ListenLocalhost(5999);
});
*/

// Insert the query class into the graphQL server
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddSorting()
    .AddFiltering();

var app = builder.Build();
app.MapGraphQL();

app.Run();


