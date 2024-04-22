# GraphQL API
This repository contains some brief implementation of a graphQL based API.

## Built with
C#, .NET, HotChocolate

## How to run
Download the project, then navigate to the `gqlBackend.api` folder and run the command 
```
dotnet run
```

The server will then be available on the url 
`localhost:5000/graphql`
the specific port might change depending on your machine.

## Data
The data is not connected to anything at the moment, its just 3 movies with 3 actors to test out queries. 
<Details><summary>Data details</summary>
<Details><summary>Movies</summary>
    <details><summary markdown="span">Movie 1</summary>
    {
        name: "Movie A"
        description: "Something happens!"
        year: 1980,
        actors: [actor1, actor2]
    }
    </details>
        <Details><summary>Movie 2</summary>
    {
        name: "Movie B"
        description: "Something happens?"
        year: 2000,
        actors: [actor2, actor3]
    }
    </Details>
        <Details><summary>Movie 3</summary>
    {
        name: "Movie C"
        description: "Something happens."
        year: 2020,
        actors: [actor1, actor3]
    }
    </Details>
</Details>
<Details><summary>Actors</summary>
    <Details><summary>Actor 1</summary>
    {
        name: "Actor A"
        age: 42
    }
    </Details>
    <Details><summary>Actor 2</summary>
    {
        name: "Actor B"
        age: 62
    }
    </Details>
    <Details><summary>Actor 3</summary>
    {
        name: "Actor C"
        age: 22
    }
    </Details>
</Details>
</Details>

## Examples
GraphQL fetches data differently than REST APIs, here are some examples: 

### Filter based on movie year
<details>
    <summary>Query</summary>


    {
        movie (
            where: {or: [{year: {lt: 1990}}, {year: {gt: 2010}}]}
            order: [{year: ASC}]
        ) {
            name
            year
            actors (order: [{age: DESC}]) {
                name
                age
            }
        }
    }
</details>

<details>
    <summary>Response</summary>


    {
      "data": {
        "movie": [
          {
            "name": "Movie A",
            "year": 1980,
            "actors": [
              {
                "name": "Actor B",
                "age": 62
              },
              {
                "name": "Actor A",
                "age": 42
              }
            ]
          },
          {
            "name": "Movie C",
            "year": 2020,
            "actors": [
              {
                "name": "Actor A",
                "age": 42
              },
              {
                "name": "Actor C",
                "age": 22
              }
            ]
          }
        ]
      }
    }
</details>