# Todo-React-DotNet-Docker

## Requirements
+ .NET 5 (previous version might work too)
+ Docker Compose

## Usage
#### Run the application
Run `docker-compose up`.

#### Access the postgres shell (psql)
To access the postgres shell you need to get the id of the postgres container
```terminal
$ docker ps
CONTAINER ID    IMAGE              ...
c6e480b0f26a    postgres           ...
```
Then run
```terminal
$ docker exec -it <container id> sh

$ su - postgres

$ psql
```