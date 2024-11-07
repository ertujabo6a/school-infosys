# Introduction to C# Project 2024: "School Information System"

## Authors

* Aleksandr Dmitriev (240259)
* Andrii Bondarenko (xbonda06)
* Artem Panchenko (xpanch01)
* Nikita Kotvitskiy (xkotvi01)
* Ondrášek Martin (xondra61)

## Project Overview and Minimal Requirements

This project aims to develop a school information system with a focus on usability, flexibility, and code quality. The application should meet all specified requirements, with additional functionality welcome if documented in README.md. For successful evaluation, all project stages must be completed, demonstrating core functionalities during the project defense.

## Key Objectives

    - Usability and Scalability: Create a robust, user-friendly application with extensible functionality that meets assignment specifications.
    - Code Quality: Emphasize clean code, technical precision, and performance. The application should not crash or freeze, with validation messages alerting users to incorrect inputs.
    - Consistency and Collaboration: Implement the project using layered architecture and follow English naming conventions for identifiers and comments. Utilize tools like .editorconfig to enforce coding standards and Azure DevOps for team collaboration, continuous integration, and source control.

## Core Features

    - Data Management: The system manages information for students, subjects, and activities (e.g., exams and exercises) and includes CRUD operations across all data entities.
    - Student Data: Stores student details including name, surname, photo URL, and associated subjects.
    - Activity Data: Logs activity details such as type, start/end times, location, and related subjects or assessments.
    - Subject Data: Manages subject names, abbreviations, related activities, and enrolled students.
    - Assessment Data: Records assessment scores, comments, and linked students and activities.

## Persistence and Synchronization

The application must maintain persistent data storage using SQLite and Entity Framework Core (EF Core) ORM, ensuring data retention across sessions. Changes in one instance of the application must propagate across all running instances, with user-initiated data reloads as necessary.

## Architecture

The project should use a layered architecture to separate application logic:

    - App Layer: Main application functions.
    - BL (Business Logic) Layer: Core business logic and rules.
    - DAL (Data Access Layer): Database interactions with persistent storage.

## Development and Collaboration Guidelines

    - Version Control: Use Git within Azure DevOps to manage code with a clear history of logical commits. Follow Conventional Commits for consistency.
    - Collaborative Review: Perform peer code reviews through pull requests before merging into the main branch.
    - Documentation: Document any custom functionality or additional project features in README.md.

## DevOps and CI/CD

    - Set up automated builds and testing in Azure Pipelines, triggering on push events to any branch.
    - Configure Azure DevOps permissions to grant the teaching account access for project assessment.

## Project Stages

    Stage 1: Data Modeling: Create the data model, ensuring all necessary relationships between entities are represented. Include wireframes for views and an ER diagram in the /docs directory.
    Stage 2: Repositories and Mapping: Implement repositories to manage database entities, and create a facade layer for data access. Ensure functionality with automated tests.
    Stage 3: MAUI Frontend and Data Binding: Build the frontend using MAUI, connecting data models through XAML data binding without code-behind. Implement CRUD operations and additional functionalities such as search and filtering.

## Project Management Recommendations

    - Scrum Methodology: Use Scrum to plan sprints and track tasks through Azure DevOps Boards. Structure work with Product Backlog Items (PBIs), Tasks, and Bugs.
    - Testing and QA: Cover repositories and ViewModels with automated tests to verify functionality and maintain application stability.

# Running the School Information System App (MAUI)

This guide will help you set up and run the app locally on Windows, macOS, Android, or iOS. 

## Prerequisites

### General Requirements

- **.NET SDK 7.0 or higher** with MAUI support: [Download .NET SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- **Git**: For cloning the repository.

### Platform-Specific Requirements

- **Windows**: Visual Studio 2022 with **.NET MAUI** workload installed.
- **macOS**: Visual Studio 2022 for Mac with the **.NET MAUI** workload installed.
- **Android**: Android SDK and emulator (installed with Visual Studio if you select MAUI workload).
- **iOS**: Xcode (for macOS users) with iOS emulator.

> **Note**: MAUI apps require Visual Studio 2022 (Windows or macOS) for proper emulation and deployment.

---

## Clone the Repository

1. Open a terminal and run the following command to clone the repository:

```bash
    git clone https://github.com/ertujabo6a/school-infosys.git
```

2. Change to the project directory

```bash
    cd ./school-infosys
```

## Open the Project in Visual Studio

1. Launch Visual Studio 2022 (Windows) or Visual Studio 2022 for Mac.
2. Go to File > Open and select the ICS.sln solution file from the cloned repository.

## Set Up the Database

This app uses SQLite as its database, and the database will be created automatically using Entity Framework Core migrations when you first run the app. Migrations should apply automatically when you start the app, but if not, run the following commands in the terminal:

```bash
    dotnet ef database update
```

> **Note**: You may need to install the EF Core tools if you haven't already. Run **dotnet tool install --global dotnet-ef** to install.

## Running the Application

You can run the app on Windows, macOS, iOS, or Android. Here’s how to do it for Windows, for other platforms steps are the same. **After running it for the first time, you can then find it in your installed apps as ICS.App** 

    - In Visual Studio, select Debug or Release mode in Solution Configurations on the top panel
    - Select ICS.App as Startup Item 
    - Select Windows Machine (or other device) as the target device.
    - Press F5 or click Run to build and run the app.

## Basic Usage

    - Student and Subject Management: You can add, edit, delete, and view students, subjects, and activities.
    - Filtering and Sorting: The app supports filtering activities by date, type, and subject.
    - Cross-Platform: Data changes are reflected on all platforms upon reload.
