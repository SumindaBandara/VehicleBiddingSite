# Online Auction System Documentation

This documentation provides a comprehensive guide to setting up, running, and testing the online auction system built using .NET 8 and MySQL. It includes information on package dependencies, environment setup, database configuration, application execution, and API testing.

## Package Dependencies

The online auction system relies on several NuGet packages. Below is a summary of each package, its purpose, and the version used:

| Package Name                          | Version  | Description                                                                                     |
|---------------------------------------|----------|-------------------------------------------------------------------------------------------------|
| `Microsoft.EntityFrameworkCore`       | 8.0.8   | The core library for Entity Framework, enabling data access and manipulation in .NET applications. |
| `Microsoft.EntityFrameworkCore.Design`| 8.0.8   | Contains design-time tools for Entity Framework, including migrations and scaffolding.         |
| `Pomelo.EntityFrameworkCore.MySql`   | 8.0.2   | A MySQL database provider for Entity Framework Core, allowing interaction with MySQL databases. |
| `BCrypt.Net`                          | 0.1.0   | A library for hashing passwords using the BCrypt algorithm, enhancing security for user data.  |


### Installation

To install these packages, you can use the following command in your project directory:

```bash
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.8
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.8
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.2
dotnet add package BCrypt.Net --version 0.1.0
```

## 1. Set Up the Environment

Ensure you have the following installed:

- **.NET 8 SDK**: Download from the official [.NET website](https://dotnet.microsoft.com/download).
- **MySQL Server**: Install MySQL and create a database for your application.
- **Visual Studio or Visual Studio Code**: Use either IDE for development.

## 2. Configure Database Connection

Check and Update your `appsettings.json` to include your MySQL connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=BidNest-V1;User=root;Password=;"
  }
}
```

Replace `localhost`, `BidNest-V1`, and `root` and `password` with your actual MySQL server details.

## 3. Run Database Migrations

Run the following commands in your project directory to apply the database migrations:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

This will create the necessary tables in your MySQL database.

## 4. Run the Application

Execute the following command to start your application:

```bash
dotnet run
```

Your API will start, typically on `https://localhost:5170` or `http://localhost:5170`.

## 5. Testing the API Endpoints

### Using Swagger UI

1. **Open Swagger**: Once your application is running, open your browser and navigate to `https://localhost:5170/swagger` (or `http://localhost:5170/swagger`).
   
2. **Test Endpoints**: Swagger provides an interface to test your API endpoints directly in the browser. You'll see all the controllers and their respective actions.

### Using Postman

If you prefer Postman for testing, follow these steps:

1. **Create a New Request**: Open Postman and create a new request.
   
2. **Test User Registration**:
   - **Endpoint**: `POST https://localhost:5170/api/users/register`
   - **Body**: Choose `raw` and set it to JSON, then add:
     ```json
     {
       "UserName": "testuser",
       "Email": "testuser@example.com",
       "Password": "Test@123",
       "Role": "Seller"
     }
     ```
   - **Send the Request** and check the response.

3. **Test Login**:
   - **Endpoint**: `POST https://localhost:5170/api/users/login`
   - **Body**: 
     ```json
     {
       "Email": "testuser@example.com",
       "Password": "Test@123"
     }
     ```
   - **Send the Request** and verify the user details.

4. **Test Item Creation**:
   - **Endpoint**: `POST https://localhost:5170/api/items`
   - **Body**:
     ```json
     {
       "Title": "Test Item",
       "Description": "This is a test item.",
       "StartingPrice": 100.00,
       "EndTime": "2024-12-31T23:59:59",
       "SellerId": 1
     }
     ```
   - **Send the Request** and check if the item is created.

5. **Test Bidding**:
   - **Endpoint**: `POST https://localhost:5170/api/items/{itemId}/bids`
   - **Body**:
     ```json
     {
       "Amount": 150.00,
       "BidderId": 2
     }
     ```
   - **Send the Request** and check the bid status.

6. **Check Item Status**:
   - **Endpoint**: `GET https://localhost:5170/api/items/{itemId}`
   - **Check**: View the item details and current bids.

## 6. Simulate Auction Flow

You can simulate the entire auction flow by:

1. **Registering Users**: Create multiple users (both sellers and buyers).
2. **Listing Items**: Have sellers list items for auction.
3. **Placing Bids**: Have buyers place bids on items.
4. **Ending Auctions**: Use a service or manually update auction end times in the database to simulate auction completion.
5. **Processing Payments**: Implement and test the payment processing logic.
6. **Giving Feedback**: After auctions, users can leave feedback and ratings.


This documentation should help you ensure that your auction system works as intended and is ready for deployment.