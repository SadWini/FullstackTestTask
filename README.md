# Order Management Application

This application is designed to manage orders through a web interface, using a React frontend and a .NET C# backend. It includes full CRUD operations for handling orders, with data stored in a PostgreSQL database.

## 🚀 Getting Started

Follow the steps below to set up and run the application on your local environment.

### Prerequisites

- **Node.js** and **npm** (for the frontend)
- **.NET SDK** (for the backend)
- **PostgreSQL** database

---

### 1. Configure the Database Connection

In the root of the backend project, open the `appsettings.json` file:

```json
{
  "ConnectionStrings": {
    "ApiDatabase": "Your_PostgreSQL_Connection_String_Here"
  },
  ...
}
```

Replace `"Your_PostgreSQL_Connection_String_Here"` with the connection string for your PostgreSQL database.

---

### 2. Run the Backend Server

Navigate to the backend server folder, typically named **Web**, and start the server using the following commands:

```bash
cd Web
dotnet run
```

The server should now be running, typically on `http://localhost:7056`. Verify that it’s connected to your PostgreSQL database.

---

### 3. Set Up and Run the Frontend

1. Open a new terminal, navigate to the **Frontend** folder, and install dependencies:

   ```bash
   cd Frontend
   npm install
   ```

2. Build the React app:

   ```bash
   npm run build
   ```

3. Serve the app locally:

   ```bash
   serve -s build
   ```

This will serve the application on `http://localhost:3000`.

> **Note:** If you don’t have the `serve` package installed globally, install it with `npm install -g serve`.

---

### 4. Access the Application

Open your browser and navigate to:

```url
http://localhost:3000/
```

You should now see the Order Management application up and running!

---

## 💻 Project Structure

- **Backend** (C# .NET): Handles the API and database interactions.
- **Frontend** (React): User interface for creating, reading, updating, and deleting orders.


## 🎉 Congratulations!

You have successfully set up and run the Order Management Application. Enjoy managing your orders efficiently!
