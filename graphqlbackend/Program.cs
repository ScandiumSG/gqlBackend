using graphqlbackend.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HotChocolate;
using graphqlbackend.Models;
using graphqlbackend.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

builder.Services.Configure<MovieDataDatabaseSettings>(
    builder.Configuration.GetSection("MovieDatabase"));

builder.Services.AddScoped<MoviesService>();

// Insert the query class into the graphQL server
builder.Services
    .AddGraphQLServer()
    .AddDefaultTransactionScopeHandler()
    .AddMutationConventions()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSorting()
    .AddFiltering();

var app = builder.Build();
app.MapGraphQL();

app.MapHealthChecks("/healthz");

app.Run();


