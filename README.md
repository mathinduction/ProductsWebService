# Products Web Service

Product Web Service allows you to work with products in database:
  - Get all products
  - Search product by id
  - Add or Edit product

### How to run project in Visual Studio
  - Open project in VS
  - Make sure that in ProductsWebService project properties you have Target Framework set to .NET Core 2.0.
  - If there is no such option, it means that you need to update Visual Studio
  - Press F5


### Change Database
Currently prject works with MOCK Database. To add real database you need to 
  - Add database context class implemented DbContext
  - Add repository class implemented IProductRepository
  - Replace in Startap.cs (ConfigureServices) line :
```
services.AddScoped<IProductRepository, MockProductRepository>();
```

### How to run Unit Tests in Visual Studio
  - Open project in VS
  - Select Test -> Run -> All Tests
  - You can see result in Test Explorer tab



