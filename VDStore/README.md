# Pi Store Management System

## Overview
The Pi Store Management System is a comprehensive Windows Forms application built with C# and SQL Server. It provides a complete solution for managing a retail store, with features for managing employees, clients, products, orders, and bills.

## Features
- **User Authentication**: Secure login system with role-based access control
- **Employee Management**: Add, edit, view, and delete employee information
- **Client Management**: Maintain a database of clients with their contact details
- **Product Management**: Track product inventory with descriptions, prices, and quantities
- **Order Processing**: Create orders for clients, add products to orders, and track order status
- **Billing System**: Generate bills for orders and maintain billing records
- **Search Functionality**: Search for employees, clients, products, orders, or bills

## System Requirements
- Windows 7 or higher
- .NET Framework 4.7.2 or higher
- SQL Server 2014 or higher
- Visual Studio 2019 or higher (for development)

## Setup Instructions

### 1. Database Setup
1. Open SQL Server Management Studio (SSMS)
2. Connect to your SQL Server instance
3. In SSMS, open the SQL script file: `VDStore/DAL/DatabaseScript.sql`
4. Execute the script to create the database, tables, stored procedures, and default admin user

### 2. Configure the Connection String
1. Open the `App.config` file in the project root
2. Locate the connection string section:
   ```xml
   <connectionStrings>
     <add name="PiStoreConnection" connectionString="Data Source=.;Initial Catalog=PiStoreDB;Integrated Security=True" providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```
3. Modify the connection string if needed:
   - `Data Source=.` refers to the local SQL Server instance. Change it to your server name if different.
   - `Integrated Security=True` uses Windows Authentication. If you use SQL Server Authentication, replace with `User ID=your_username;Password=your_password;`

### 3. Build and Run the Application
1. Open the solution file (`VDStore.sln`) in Visual Studio
2. Build the solution (Press F6 or use Build > Build Solution)
3. Run the application (Press F5 or use Debug > Start Debugging)

### 4. Login to the Application
- Use the default admin credentials:
  - Username: `admin`
  - Password: `admin123`

## Usage Guide

### Main Menu
The main menu provides access to all system functions:
- **Manage Employees**: Add, edit, and delete employee records
- **Manage Clients**: Maintain client information
- **Manage Products**: Track inventory and product details
- **Orders Menu**:
  - Place Order: Create new orders for clients
  - Manage Orders: View and manage existing orders
- **Bills Menu**:
  - Generate Bill: Create bills from orders
  - View Bills: Access billing history

### Employee Management
1. Click "Manage Employees" in the main menu
2. Use the form to add new employees or edit existing ones
3. Fill in the required fields (Name, Email, etc.)
4. Click "Save" to create/update the employee record
5. Use the search function to find specific employees

### Client Management
Similar to employee management, this form allows you to maintain client records.

### Product Management
Manage your inventory with this module:
- Add new products with details like name, description, price, and quantity
- Update existing product information
- Track product quantities

### Order Processing
1. Select "Place Order" from the Orders menu
2. Choose a client from the dropdown
3. Add products to the order with quantities
4. Submit the order

### Generating Bills
1. Select "Generate Bill" from the Bills menu
2. Choose an existing order
3. Click "Generate" to create a bill

## Troubleshooting

### Database Connection Issues
- Verify SQL Server is running
- Check connection string in App.config
- Ensure you have proper SQL Server permissions

### Login Problems
- Default admin credentials are username: `admin`, password: `admin123`
- If forgotten, you can reset in SQL Server with:
  ```sql
  UPDATE [User] SET Password = 'admin123' WHERE Username = 'admin'
  ```

## Project Structure
- **Models**: Contains entity classes representing database tables
- **DAL (Data Access Layer)**: Handles database operations
- **Forms**: Contains the user interface forms

## Database Schema
- **Employee**: ID, Name, Email, Phone, Address, Salary, HireDate
- **Client**: ID, Name, Email, Phone, Address
- **Product**: ID, Name, Description, Price, Quantity
- **Order**: ID, ClientID, EmployeeID, OrderDate, TotalPrice
- **OrderItem**: ID, OrderID, ProductID, Quantity, UnitPrice
- **Bill**: ID, OrderID, ClientID, EmployeeID, BillDate, TotalPrice
- **User**: ID, Username, Password, Role, EmployeeID

## Security Notice
This application uses basic authentication for demonstration purposes. In a production environment, passwords should be hashed and additional security measures implemented. 