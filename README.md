
# Task Management API

This is a simple Task Management API built with ASP.NET Core and Entity Framework Core using SQL Server Express as the database.

---

## 🚀 Getting Started

These instructions will help you set up and run the project locally on your machine.

---

## 🛠 Prerequisites

- [.NET SDK 7.0+](https://dotnet.microsoft.com/download)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup) *(optional, for DB access)*
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) or any code editor

---

## ⚙️ Configuration

1. **Clone the Repository**
   ```bash
   git clone https://github.com/yourusername/TaskManagementAPI.git
   cd TaskManagementAPI
   ```

2. **Configure the Connection String**

   Edit `appsettings.json` and update the `DefaultConnection` to your local SQL Server instance:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=TaskDb;Trusted_Connection=True;"
   }
   ```

3. **Apply Database Migrations**

   Run the following commands in the terminal (or Package Manager Console):

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

   This will create the `TaskDb` database and apply the schema.

---

## ▶️ Running the API

Start the API server:

```bash
dotnet run
```

Once running, navigate to:

```
https://localhost:7208/swagger
```

```
docker build -t taskmanagement-api .
```

```
docker run -d -p 8080:5270 --name task-api taskmanagement-api
```

```
http://localhost:8080/swagger
```


This opens the Swagger UI where you can explore and test the API endpoints.

---

## 📁 Project Structure

```
TaskManagementAPI/
├── Controllers/
│   └── TasksController.cs
├── Models/
│   └── TaskItem.cs
├── Data/
│   └── AppDbContext.cs
├── appsettings.json
├── Program.cs
├── TaskManagementAPI.csproj
└── README.md
```

---

## ✅ Endpoints Overview

- `GET /api/tasks` — Get all tasks
- `GET /api/tasks/{id}` — Get task by ID
- `POST /api/tasks` — Create new task
- `PUT /api/tasks/{id}` — Update task
- `DELETE /api/tasks/{id}` — Delete task

---

## 📬 Contact

For issues or contributions, feel free to connect me.

Gowtham Rajasekaran
mail.gowtham.raja2002@gmail.com

---
