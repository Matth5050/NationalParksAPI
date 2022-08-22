# National Parks API

#### By _Matt Herbert_

#### _An API for keeping track of the National Parks and the states they are in._

## Technologies Used

* _C#/.NET_
* _SQL Workbench_
* _MVC_
* _Entity Framework_
* _Identity_
* _JwtBearer_
* _Swagger_

## Description

An API created for use by individuals and organizations list the National Parks and what states they exist in.

## Setup/Installation Requirements
_Requires console application such as Git Bash, Terminal, or PowerShell_

1. Open Git Bash or PowerShell if on Windows and Terminal if on Mac
2. Run the command

    ``git clone https://github.com/Matth5050/NationalParksAPI``

3. Run the command

    ``cd NationalParksAPI``

* You should now have a folder `NationalParksAPI` with the following structure.
    <pre>NatioanlParksAPI
    ├── .gitignore 
    ├── ... 
    └── NationalParks.Solution
    |   ├── Models
    |   ├── ...
    |   ├── README.md
    |   └── Startup.cs
    └── NationalParksClient.Solution
        ├── Models
        ├── ...
        └── Program.cs</pre>

4. Add a file named appsettings.json in the following location, inside NationalParks.Solution folder 

    <pre>NationalParksAPI
    ├── .gitignore 
    ├── ... 
    └── NationalParks.Solution
        ├── Controllers
        ├── Models
        ├── ...
        ├── Startup.cs
        └── <strong>appsettings.json</strong></pre>
      
5. Copy and paste below JSON text in appsettings.json.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=national_parks;uid=root;pwd=[YOUR-PASSWORD-HERE];"
  },
  "JwtConfig": {
    "Secret" : "[YOUR-SECRET-HERE]"
  }
}

```

7. Replace [YOUR-PASSWORD-HERE] with your MySQL password.

8. Replace [YOUR-SECRET-HERE] with your random length 32 string.

9. Run the command

    ```dotnet ef database update```


<strong>To Run</strong>

Navigate to the following directory in the console
    <pre>NationalParksAPI
    └── <strong>NationalParks.Solution</strong></pre>

Run the following command in the console

  ``dotnet build``

Then run the following command in the console

  ``dotnet run``

  <strong>To Run The Client</strong>

Navigate to the following directory in the console
    <pre>NationalParksAPI
    └── <strong>NationalParksClient.Solution</strong></pre>

Run the following command in the console

  ``dotnet build``

Then run the following command in the console

  ``dotnet run``

This program was built using _`Microsoft .NET SDK 6.0`_, and may not be compatible with other versions. Cross-version performance is neither implied nor guaranteed.

## API Documentation
Explore the API endpoints in Postman or a browser. You will not be able to utilize authentication in a browser.

### Using the JSON Web Token
In order to be authorized to use the POST, PUT, DELETE functionality of the API, please authenticate yourself through Postman or through registering an account on the client side.
* Open Postman and create a POST request using the URL: `http://localhost:5000/api/users/authmanagement/register`
* Add the following query to the request as raw data in the Body tab:
```
{
    "name": "Test User",
    "email": "Test@Test.com",
    "password": "Epicodus1!"
}
```
* The token will be generated in the response. Copy and paste it as the Token paramenter in the Authorization tab after selecting "Bearer Token" from the dropdown menu.

###  Swagger Documentation 
To view the Swagger documentation for the NationalParksAPI, launch the project using `dotnet run` using Terminal or Powershell, then input the following URL into your browser: `http://localhost:5000/swagger`

###  Swagger Authorization 
In order to utilize Swagger and interact with the API, you will first need to authenticate yourself through Postman. 
* Once you have completed authorization and have obtained your Bearer Token, navigate back to `http://localhost:5000/swagger` then click on the `authorize` button in the top right corner.
* From there, you must type in `Bearer` followed by your `Token`.
* After you have inputted the necessary `Bearer Token`, click Authorize.
* Once successfully authorized, you will be able to utilize the Swagger docs to interact with the API.

### Parks
Access information on parks currently in the API.

#### HTTP Request Structure
```
GET /api/Parks 
POST /api/Parks
GET /api/Parks/{id}
PUT /api/Parks/{id}
DELETE /api/Parks/{id}
```
### Parks
Access information on regions that parks could belong in.
```
GET /api/Regions 
POST /api/Regions
GET /api/Regions/{id}
PUT /api/Regions/{id}
DELETE /api/Regions/{id}
```

* To utilize the POST request and create a new instance of a park, the following information is required.
```
{
    "parkId": "int",
    "regionId": "int",
    "name": "string",
    "state": "string"
}
```

#### Example Query
```
https://localhost:5000/api/Parks/1
```
#### Sample JSON Response
```
{
    "animalId": 1,
    "RegionId": 1.
    "name": "Yellow Stone",
    "state": "Wyoming"
}
```

## Known Bugs

* _No known issues_

## License

[MIT](/LICENSE)

Copyright (c) 2022 Matt Herbert