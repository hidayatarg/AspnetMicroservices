# AspnetMicroservices

It is written using .net  core 7.0

### Mongo

- `docker pull mongo` to pull the mongo image
- `docker run -d -p 27017:27017 --name shopping-mongo mongo` to run the mongo image
- `docker logs -f shopping-mongo` to see the logs of the mongo image
- `docker exec -it shopping-mongo bin/bash` to enter the mongo image

### Mongosh

- `mongosh` to enter the mongo shell
- `show dbs` to show the databases
- `use CatalogDb` to use the CatalogDb database and creating if not available
- `show databases` to show the databases
- `show collections` to show the collections
- `db.createCollection('Products')` to create the Products collection
- `db.insertOne({name: 'Test', description: 'Test'})` to insert a document into the Products collection
- `db.Products.find({})` to find all documents in the Products collection
- `db.Products.find({}).pretty()` to find all documents in the Products collection in a pretty format
- `db.Products.find({name: 'Test'}).pretty()` to find all documents in the Products collection with name equal to Test in a pretty format
- `db.Products.find({name: 'Test', description: 'Test'}).pretty()` to find all documents in the Products collection with name equal to Test and description equal to Test in a pretty format
- `db.Products.find({name: 'Test', description: 'Test'}).count()` to find the count of all documents in the Products collection with name equal to Test and description equal to Test
- `db.Products.insetMany([{name: 'Test1', description: 'Test1'}, {name: 'Test2', description: 'Test2'}])` to insert many documents into the Products collection
- `db.Products.remove({})` to remove all documents in the Products collection
- `db.Products.drop()` to drop the Products collection
- `db.dropDatabase()` to drop the CatalogDb database

### Redis

- `docker pull redis` to pull the redis image
- `docker run -d -p 6379:6379 --name aspnetrun-redis redis` to run the redis image
- `docker logs -f aspnetrun-redis` to see the logs of the redis image
- `docker exec -it aspnetrun-redis redis-cli` to enter the redis image
- `docker exec -it aspnetrun-redis bin/bash` to enter the redis image

## Catalog REST APIs

| Method | Request URI                                    | Use Case                        |
| ------ | ---------------------------------------------- | ------------------------------- |
| GET    | api/v1/Catalog                                 | Listing Products and Categories |
| GET    | api/v1/Catalog/{id}                            | Get Product with ProductId      |
| GET    | api/v1/Catalog/GetProductByCategory/{category} | Get Products with Category      |
| POST   | api/v1/Catalog                                 | Create new Product              |
| PUT    | api/v1/Catalog                                 | Update Product                  |
| DELETE | api/v1/Catalog/{id}                            | Delete Product                  |

## Basket REST APIs

| Method | Request URI            | Use Case                                            |
| ------ | ---------------------- | --------------------------------------------------- |
| GET    | api/v1/Basket          | Get Basket and Items with username                  |
| POST   | api/v1/Basket          | Update Basket and Items (Add remove item to basket) |
| DELETE | api/v1/Basket/{id}     | Delete Basket                                       |
| POST   | api/v1/Basket/Checkout | Checkout Basket                                     |

## Catalog/Basket Architecture

Tradition n-tier architecture:

User -> Presentation Layer (UI Component => Presentation Layer) -> Business Logic Layer (Service Layer => Business Logic Layer) -> Data Access Layer -> Database (Data Source)

- Data Access Layer: Only database operations are performed here, Add, Update, Delete, Get data from database.
- Business Logic Layer: Only business logic is implemented here, It will process data taken from the Data Access Layer and return it to the Presentation Layer. We dont use this layer directly, the data comes from user to the Presentation Layer and then to the Business Logic Layer, processed and send to data access layer and then to the database.
- Presentation Layer: This is the layer where the user interact. It can be a web application or API. The main purpose of this layer to show the data to the user and take the data from the user and send it to the Business Logic Layer.

## Simple Data-Driven CRUD Microservice Architecture

API/Application Layer -> Domain Model Layer -> Infrastructure Layer

- API/Application Layer: Entry point into the service. Exposes endpoints and enforces validations. It will be controller classes.

- Domain Model Layer: Contains business rules and logic. Business operations are implemented here

- Infrastructure Layer: Provides infrustructure plumbing. Primary responsibility is to presistance of business state.

## Repository Design Pattern

It follows solid patterns. I has two purpose it is an abstration of data layer and it is a way to centralize handling the domain object. It is like a middle layer between the application and data access logic. It makes code easy to maintain and test.
