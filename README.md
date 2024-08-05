# Tunify Platform

## Overview

Tunify Platform is a music streaming application built using ASP.NET Core and Entity Framework Core. This project includes various functionalities such as user management, playlist creation, and music catalog management. The database schema includes users, subscriptions, songs, playlists, artists, albums, and a many-to-many relationship between playlists and songs.

## Project Structure

- **Program.cs**: Entry point of the application. It configures the services and the application pipeline.
- **AppDbContext.cs**: Defines the database context and the entity sets. It also includes seed data for initial setup.

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

### Database Context

The `AppDbContext` class defines the entity sets for the application:

- `Users`
- `Subscriptions`
- `Songs`
- `Playlists`
- `Artists`
- `Albums`
- `PlaylistSongs`

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request for review.

## License

This project is licensed under the MIT License.