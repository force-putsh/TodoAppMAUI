# Todo Maui App

This is a simple todo app built with Maui. This application allows users to add, update, and delete tasks using http requests.

## Features

- Add new tasks
- Update tasks
- Delete tasks
- View all tasks
- Swipe actions for completing and deleting tasks

## Getting Started

### Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/fr/vs/) with the following .NET MAUI workloads:
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)


### Running the app

1. Clone the repository

```bash
git clone git@github.com:force-putsh/TodoAppMAUI.git
```

2. Open the project in Visual Studio 2022

- select the `TodoApp` project as the startup project
- select the target platform (iOS, Android, Windows, MacCatalyst)
- run the project (F5)

## Project Structure

The project is structured as follows:

- `TodoAppMAUI` - .NET MAUI project
- `TodoAppMAUI.Services` - Contains the services for the application. This includes the `ITodoService` interface and the `TodoService` class that implements the interface. The `TodoService` class is responsible for making http requests to the API.
- `TodoAppMAUI.Models` - Contains the models for the application. This includes the `Todo` class.
- `TodoAppMAUI.ViewModels` - Contains the view models for the application. This includes the `MainViewModel` class.
- `TodoAppMAUI.Converters` - Contains the converters for the application. This includes the `BoolToStringConverter` class.

## MainPage.xaml Overview

The `MainPage.xaml` file defines the layout and bindings for the main page of the application. Key components include:

- **Entry**: For entering new tasks.
- **Button**: To add the entered task.
- **CollectionView**: To display the list of tasks with swipe actions for completing and deleting tasks.
- **SwipeView**: Provides swipe actions for each task item.


## Commands

- **CreateTodoCommand**: Adds a new task.
- **DeleteTodoCommand**: Deletes a task.
- **UpdateTodoCommand**: Marks a task as complete.

## Value Converters

- **BooleanToStringConverter**: Converts a boolean value to a string for UI binding.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

this project is licensed under the MIT License