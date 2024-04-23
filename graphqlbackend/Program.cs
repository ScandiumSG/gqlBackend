using gqlBackend.api.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HotChocolate;

var builder = WebApplication.CreateBuilder(args);


// Insert the query class into the graphQL server
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddSorting()
    .AddFiltering();

var app = builder.Build();
app.MapGraphQL();

app.UseHttps();

app.Run();


