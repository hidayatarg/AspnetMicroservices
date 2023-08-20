# AspnetMicroservices

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

## Catalog REST APIs

| Method | Request URI                                    | Use Case                        |
| ------ | ---------------------------------------------- | ------------------------------- |
| GET    | api/v1/Catalog                                 | Listing Products and Categories |
| GET    | api/v1/Catalog/{id}                            | Get Product with ProductId      |
| GET    | api/v1/Catalog/GetProductByCategory/{category} | Get Products with Category      |
| POST   | api/v1/Catalog                                 | Create new Product              |
| PUT    | api/v1/Catalog                                 | Update Product                  |
| DELETE | api/v1/Catalog/{id}                            | Delete Product                  |
