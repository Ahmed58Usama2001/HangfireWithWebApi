# Hangfire With Web API

## 📌 Overview
This repository contains a small **.NET Web API** project designed with **Clean Architecture** to demonstrate the usage of **Hangfire** for executing background jobs efficiently.

## 🔥 What is Hangfire?
[Hangfire](https://www.hangfire.io/) is an open-source library that enables background job processing in .NET applications. It allows for:
- Fire-and-forget jobs
- Delayed jobs
- Recurring jobs
- Continuations
- Batch processing

## 🏗️ Project Architecture
The project follows the **Clean Architecture** principles, ensuring:
- Separation of concerns
- High maintainability
- Testability

### Layers
- **API Layer** - Handles HTTP requests and responses.
- **Application Layer** - Contains business logic and application services.
- **Infrastructure Layer** - Implements Hangfire and database interactions.
- **Domain Layer** - Defines core business models and rules.

## 🚀 Features
- **Schedule Background Jobs** using Hangfire
- **Manage Jobs** via Hangfire Dashboard
- **Fire-and-Forget Jobs** for quick execution
- **Recurring Jobs** for scheduled tasks
- **Delayed Jobs** for deferred execution

## 🛠️ Getting Started
### Prerequisites
- .NET SDK (>= .NET 6)
- SQL Server (for Hangfire storage)

### Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/HangfireWithWebApi.git
   ```
2. Navigate to the project folder:
   ```sh
   cd HangfireWithWebApi
   ```
3. Restore dependencies:
   ```sh
   dotnet restore
   ```
4. Update the **appsettings.json** to configure the Hangfire database.

### Running the Application
1. Apply database migrations (if needed):
   ```sh
   dotnet ef database update
   ```
2. Run the API:
   ```sh
   dotnet run
   ```
3. Access the Hangfire Dashboard at:
   ```sh
   http://localhost:5000/hangfire
   ```

## 📜 Usage
### Adding a Background Job
```csharp
BackgroundJob.Enqueue(() => Console.WriteLine("Hello, Hangfire!"));
```
### Scheduling a Recurring Job
```csharp
RecurringJob.AddOrUpdate("my-recurring-job", () => Console.WriteLine("Executing recurring job!"), Cron.Daily);
```

## 🎯 Contribution
Contributions are welcome! Feel free to open issues or submit pull requests.

## 📜 License
This project is licensed under the MIT License.

## 📞 Contact
For any questions, reach out or open an issue in the repository.

Happy Coding! 🚀
