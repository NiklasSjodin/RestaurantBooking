# RestaurantBooking

## Table of Content
- [Functionality](#functionality)
- [ER Diagram](#er-diagram)
- [Using Endpoints](#using-endpoints)
- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Built With](#built-with)
- [Made By](#made-by)
- [Contributions](#contributions)

## Functionality
- **Manage Tables**: Store and manage information about tables, including number of seats and table numbers.
- **Customer management**: Store customer information such as name and contact details.
- **Booking management**: Manage bookings linked to tables and customers, including date, time and number of people.
- **Menu management**: Manage the restaurant's menu with dishes, prices and availability.

## ER Diagram
![Skärmbild 2024-09-30 153213](https://github.com/user-attachments/assets/f1aa4002-22c1-46e7-975e-c30381cdd0a8)

## Using Endpoints
### Customers endpoint
- GET - /api/Customers
```json
    {
    "customerID": 3,
    "firstName": "Linda",
    "lastName": "Ohlsson",
    "phoneNumber": "070xxxxxxxx"
  }
  ```
- GET - /api/Customers/customer/{id}
```json
{
  "customerID": 3,
  "firstName": "Linda",
  "lastName": "Ohlsson",
  "phoneNumber": "070xxxxxxxx"
}
```
- POST - /api/Customers/createCustomer
 ```json
{
  "firstName": "Niklas",
  "lastName": "Sjödin",
  "phoneNumber": "070xxxxxxx"
}
```
- PUT - /api/Customers/updateCustomer/{id}
 ```json
{
  "customerID": 4,
  "firstName": "Niklas",
  "lastName": "Sjödin",
  "phoneNumber": "07xxxxxxxx"
}
```
- DELETE - /api/Customers/deleteCustomer{id}
```json
Customer deleted!
```

### Menu Items endpoint
- GET - /api/MenuItems
 ```json
{
    "itemId": 1,
    "name": "Meat and Fries",
    "price": 30,
    "isAvailable": true
  }
```
- GET - /api/MenuItems/menuItem/{id}
 ```json
{
    "itemId": 1,
    "name": "Meat and Fries",
    "price": 30,
    "isAvailable": true
  }
```
- POST - /api/MenuItems/createMenuItem
 ```json
{
    "name": "Lobster with Rice",
    "price": 40,
    "isAvailable": true
  }
```
- PUT - /api/MenuItems/updateMenuItem/{id}
 ```json
{
    "itemId": 1,
    "name": "Meat and Fries",
    "price": 35,
    "isAvailable": true
  }
```
- DELETE - /api/MenuItems/deleteMenuItem/{id}
```json
Menu Item deleted!
```

### Reservations endpoint
- GET - /api/Reservations
 ```json
  {
    "reservationId": 4,
    "customerID": 3,
    "firstName": "Linda",
    "time": "2024-09-30T13:08:18.942",
    "tableNumber": 0,
    "numberOfGuests": 2
  }
```
- GET - /api/Reservations/reservation/{id}
 ```json
  {
    "reservationId": 4,
    "customerID": 3,
    "firstName": "Linda",
    "time": "2024-09-30T13:08:18.942",
    "tableNumber": 0,
    "numberOfGuests": 2
  }
```
- POST - /api/Reservations/createReservation
```json
 {
  "tableID": 3,
  "customerID": 3,
  "time": "2024-09-30T13:08:18.942Z",
  "numberOfGuests": 2
}
```
- PUT - /api/Reservations/updateReservation/{id}
```json
{
  "reservationId": 4,
  "time": "2024-09-30T13:10:33.942Z",
  "numberOfGuests": 4
}
```
- DELETE - /api/Reservations/deleteReservation/{id}
```json
Reservation deleted!
```

### Tables endpoint
- GET - /api/Tables
```json
   "tableID": 3,
    "tableNumber": 0,
    "numberOfSeats": 0
  }
```
- GET - /api/Tables/reservation/{id}
```json
   "tableID": 3,
    "tableNumber": 0,
    "numberOfSeats": 0
  }
```
- POST - /api/Tables/createTable/
```json
    "tableNumber": 2,
    "numberOfSeats": 4
  }
```
- PUT - /api/Tables/updateTable/{id}
```json
   "tableID": 5,
    "tableNumber": 2,
    "numberOfSeats": 6
  }
```
- DELETE - /api/Tables/deleteTable/{id}
```json
Table deleted!
```

## Getting Started
- **Clone the project from GitHub:**
```git clone https://github.com/NiklasSjodin/RestaurantBooking.git``` 
- **Navigate to the project directory and run the project:**
```cd restaurant booking```
```dotnet run```
- **Set up the database with migrations:**
```dotnet ef database update```

## Prerequisites
Before you begin, make sure you have the following installed:

- **C# - .NET SDK.**
- **Visual Studio Community or other development environment.**
- **Git - Version control.**

## Built with
<div >
  <code><img width="40" src="https://user-images.githubusercontent.com/25181517/121405384-444d7300-c95d-11eb-959f-913020d3bf90.png" alt="C#" title="C#"/></code>
  <code><img width="40" src="https://user-images.githubusercontent.com/25181517/121405754-b4f48f80-c95d-11eb-8893-fc325bde617f.png" alt=".NET Core" title=".NET Core"/></code>
  <code><img width="40" src="https://github.com/marwin1991/profile-technology-icons/assets/19180175/3b371807-db7c-45b4-8720-c0cfc901680a" alt="MSSQL" title="MSSQL"/></code>
	<code><img width="40" src="https://user-images.githubusercontent.com/25181517/192108372-f71d70ac-7ae6-4c0d-8395-51d8870c2ef0.png" alt="Git" title="Git"/></code>
</div>

## Made by
&#9733; Niklas Sjödin´s [GitHub-profil](https://github.com/NiklasSjodin) <br>

## Contributions
Contributions are welcome! Please follow these guidelines when contributing to the project:

- To report bugs, use the [GitHub Issues](https://github.com/NiklasSjodin/RestaurantBooking/issues).
- For suggestions and improvements, feel free to open an issue and start a discussion.
- If you want to contribute code enhancements, fork the repository, create a new branch, and submit a pull request.

Thank you for contributing to this project!
