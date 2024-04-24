# GraphQL API
This repository contains some brief implementation of a graphQL based API.

## Built with
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white) ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)

GraphQL implemented using [HotChocolate](https://chillicream.com/docs/hotchocolate/v13).


## How to run
**(Requires Docker dekstop)**
Down the project and navigate to the project root, then run the command
```
docker compose down; docker compose build --no-cache; docker compose up -d
```

This Docker compose command will build and run the project backend aswell as a mongodb database. 

The server will then be available at the address: `localhost:8080/graphql`

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

## Query examples
GraphQL fetches data differently than REST APIs, here are some examples: 

### Retrieve all movies, return name and description for each
<details>
    <summary>Query</summary>


    {
      movie {
        name
        description
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
            "description": "Something happens!"
          },
          {
            "name": "Movie B",
            "description": "Something happens?"
          },
          {
            "name": "Movie C",
            "description": "Something happens."
          }
        ]
      }
    }
</details>

### Retrieve all movies with name, and include all actors by name associated with the movie.
<details>
    <summary>Query</summary>

    {
      movie {
        name
        description
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
            "actors": [
              {
                "name": "Actor A"
              },
              {
                "name": "Actor B"
              }
            ]
          },
          {
            "name": "Movie B",
            "actors": [
              {
                "name": "Actor B"
              },
              {
                "name": "Actor C"
              }
            ]
          },
          {
            "name": "Movie C",
            "actors": [
              {
                "name": "Actor A"
              },
              {
                "name": "Actor C"
              }
            ]
          }
        ]
      }
    }
</details>

### Sort movie based on release year descending
<details>
    <summary>Query</summary>

    {
      movie (order: {year: DESC}){
        name
        year
      }
    }
</details>

<details>
    <summary>Response</summary>

    {
      "data": {
        "movie": [
          {
            "name": "Movie C",
            "year": 2020
          },
          {
            "name": "Movie B",
            "year": 2000
          },
          {
            "name": "Movie A",
            "year": 1980
          }
        ]
      }
    }
</details>

### Filter based on movie year, less (earlier) than 1990 or greater (later) than 2010

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

## Mutation examples

Changing data in graphQL is done using mutations, here are some examples:

### Creating new movie, return all information regarding the movie added
<details>
    <summary>Mutation</summary>

    mutation ($movie_name: String!, $year: Int!) {
      createMovie (
        input: {movie: 
          {name: $movie_name, description: "Nothing happened", year: $year, 
            actors: [{name: "Actor A", age: 25}, {name: "Actor B", age: 30}, {name: "Actor C", age: 35}]
          }
        }) {
        movie {
          id
          name
          description
          year
          actors {
            name
            age
          }
        }
      }
    }
</details>
<details>
    <summary>Variables example</summary>

    {
      "movie_name": "Movie about something",
      "year": 2222
    }
</details>

<details>
    <summary>Response</summary>

    {
      "data": {
        "createMovie": {
          "movie": {
            "id": "6628bba84810ce245f23db4b",
            "name": "Movie about something",
            "description": "Nothing happened",
            "year": 2222,
            "actors": [
              {
                "name": "Actor A",
                "age": 25
              },
              {
                "name": "Actor B",
                "age": 30
              },
              {
                "name": "Actor C",
                "age": 35
              }
            ]
          }
        }
      }
    }
</details>