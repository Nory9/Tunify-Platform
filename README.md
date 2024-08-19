# Tunify Platform

Tunify Platform is a music streaming application built using ASP.NET Core and Entity Framework Core. This project includes various functionalities such as user management, playlist creation, and music catalog management. The database schema includes users, subscriptions, songs, playlists, artists, albums, and a many-to-many relationship between playlists and songs.

## Overview

- **Program.cs**: Entry point of the application. It configures the services and the application pipeline.
- **AppDbContext.cs**: Defines the database context and the entity sets. It also includes seed data for initial setup.

## Project Structure

### Program.cs

- Entry point of the application.
- Configures the services and the application pipeline.

### AppDbContext.cs

- Defines the database context and the entity sets.
- Includes seed data for initial setup.

### Controllers

- Organizes all controller classes.
- Controllers generated for:
    - Users
    - Playlists
    - Songs
    - Artists

### Repositories

- Organizes repository interfaces and implementations.
    - **Interfaces**
        - Contains repository interfaces.
        - Each interface declares necessary methods for the respective entity:
            - Users
            - Playlists
            - Songs
            - Artists
    - **Services**
        - Contains service classes implementing the repository interfaces.
        - Each service class provides implementations for methods defined in the interfaces.
        - Ensures necessary CRUD operations and additional business logic are correctly implemented.
## Database Schema

The database schema is represented in the provided ER diagram. The schema includes the following entities:

![ERD](https://github.com/Nory9/Tunify-Platform/blob/Tunify-Platform/Tunify%20Platform/Tunify.png?raw=true)

1. **Users**: Stores user information.
2. **Subscriptions**: Stores subscription types and prices.
3. **Songs**: Stores song details including title, artist, album, duration, and genre.
4. **Playlists**: Stores playlist details including user ID, playlist name, and created date.
5. **Artists**: Stores artist details.
6. **Albums**: Stores album details including album name, release date, and artist ID.
7. **PlaylistSongs**: Represents the many-to-many relationship between playlists and songs.

# 

---

## Database Context

The `AppDbContext` class defines the entity sets for the application:

- Users
- Subscriptions
- Songs
- Playlists
- Artists
- Albums
- PlaylistSongs

## Repository Pattern Implementation

### Changes

- Implemented the Repository Pattern.
- Ensured all tables from the previous lab reflect the ERD with all needed migrations.

### Structure

### Controllers Folder

- Created a new folder named **Controllers** to organize all controller classes.
- Generated controllers for:
    - Users
    - Playlists
    - Songs
    - Artists
- Ensured that controllers are ready to be refactored to use repositories.
- Verified that no controllers from Lab 11 are duplicated.

### Repositories Folder

- Created a new folder named **Repositories** with two subfolders:
    - **Interfaces**: Holds repository interfaces.
    - **Services**: Holds repository implementations (service classes).

### Interfaces

- Defined interfaces for each entity in the **Repositories/Interfaces** folder.
    - Each interface declares methods specific to the entity, including CRUD operations and any additional methods relevant to the entity’s functionality.

### Services

- Implemented service classes in the **Repositories/Services** folder.
    - Each service class implements its respective interface.
    - Provides implementations for methods defined in the interface.
    - Ensures all necessary CRUD operations and additional business logic are correctly implemented.

### Refactoring Controllers

- Refactored controllers to use the repository pattern.
    - Replaced direct `DbContext` calls with calls to the repository methods.
    - Ensured each controller receives its repository through constructor injection.
    - Allowed controllers to interact with the data access layer via the repository.
  


## Swagger UI Integration

To enhance the development experience and provide an easy way to explore and test the API endpoints, Swagger UI has been integrated into the Tunify Platform. Swagger UI offers a visual representation of the available endpoints, their request methods, parameters, and response models, making it easier for developers to understand and interact with the API.

### How to Access Swagger UI

Swagger UI is automatically configured and available as part of the development environment. To access the Swagger UI:

1. **Run the Application**: Start the application by running it through your preferred method (e.g., Visual Studio, `dotnet run`, or using Docker).
2. **Navigate to the Swagger UI URL**: Open your web browser and go to the following URL:
    
    ```bash
    
    http://localhost:{port}/swagger
    
    ```
    
    Replace `{port}` with the port number on which your application is running. By default, this is usually `5000` or `5001` for HTTPS.
    
3. **Explore the API Endpoints**: Once on the Swagger UI page, you'll see a list of all the available API endpoints organized by controller. You can click on each endpoint to view more details, including the request methods (GET, POST, PUT, DELETE), parameters, and expected responses.

### Using Swagger UI

Swagger UI allows you to:

- **View API Documentation**: Detailed information about each API endpoint is available, including the route, request parameters, response types, and example responses.
- **Test Endpoints**: Directly interact with the API by sending requests and viewing responses. You can input parameters and execute API calls to see the real-time output.
- **Download API Documentation**: The API documentation in Swagger UI can be downloaded in JSON or YAML format, which can be used for further integration or documentation purposes.

### Benefits of Swagger UI

- **Interactive Documentation**: Swagger UI provides an interactive way to explore the API, reducing the learning curve for new developers.
- **Ease of Testing**: Quickly test and validate API endpoints without the need for external tools like Postman.
- **Automatic Updates**: As the API evolves, the Swagger documentation automatically updates to reflect changes, ensuring it is always up-to-date.
## License

This project is licensed under the MIT License.