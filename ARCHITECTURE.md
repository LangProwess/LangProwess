# Architecture

LangProwess contains backend, frontend, and shared codebases in this monorepo.
The Project utilizes C# as the main programming language, restraining from using others where possible.

## Frontend

```
Framework: Blazor
Component framework: MudBlazor
Languages: C#, HTML5, CSS
```

As for CSS, we are using the isolation method.

```
web
├── pages             - displayable pages
├── shared            - shared components and layouts
```

[Codebase](src/LangProwess.Web/)

## Backend

```
Framework: ASP.NET Core
Database: SQLite
Language: C#
```

```
server
├── data              - EF Core context & entities (models)
├── features          - feature folders (i.e. Login, Users, Preferences), inside controllers, MediatR handlers, feature-specific services, etc.
├── infrastructure    - extension methods, etc.
```

[Codebase](src/LangProwess.Server/)

## Shared

Shared elements between different codebases.

[Codebase](src/LangProwess.Shared/)

## Unit Tests

Unit tests, mainly for the backend.

[Codebase](tests/LangProwess.Server.Tests/)
