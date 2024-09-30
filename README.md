# RestaurantBooking

## Table of Content
- [Functionality](#functionality)
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

## Using Endpoints
### Customers endpoint
- GET - /api/Customers
- GET - /api/Customers/customer/{id}
- POST - /api/Customers/createCustomer
- PUT - /api/Customers/updateCustomer/{id}
- DELETE - /api/Customers/deleteCustomer{id}

### Menu Items endpoint
- GET - /api/MenuItems
- GET - /api/MenuItems/menuItem/{id}
- POST - /api/MenuItems/createMenuItem
- PUT - /api/MenuItems/updateMenuItem/{id}
- DELETE - /api/MenuItems/deleteMenuItem/{id}

### Reservations endpoint
- GET - /api/Reservations
- GET - /api/Reservations/reservation/{id}
- POST - /api/Reservations/createReservation
- PUT - /api/Reservations/updateReservation/{id}
- DELETE - /api/Reservations/deleteReservation/{id}

### Tables endpoint
- GET - /api/Tables
- GET - /api/Tables/reservation/{id}
- POST - /api/Tables/createTable/
- PUT - /api/Tables/updateTable/{id}
- DELETE - /api/Tables/deleteTable/{id}

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
