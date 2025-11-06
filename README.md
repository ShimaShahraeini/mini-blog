# Mini Blog

This project is a **simplified blogging system**.
It’s built using **ASP.NET Core**, **Entity Framework Core**, **PostgreSQL**, and **Docker** — with separate containers for the app and database.

---

## Features

- Entity Models for:
  - Users (with Admin seeding)
  - Posts
  - Categories
  - Comments
-  Proper relationships (One-to-Many, Many-to-Many)
-  Database migrations using **EF Core**
-  Seeding for:
  - Default Admin user (`shima`)
  - Default Categories (Tech, Travel, Lifestyle)
-  Fully dockerized environment (PostgreSQL + .NET API)
-  Auto-migrate and seed on startup

---

## Technologies Used

- **.NET 8 / ASP.NET Core Web API**
- **Entity Framework Core (Code First)**
- **PostgreSQL**
- **Docker & Docker Compose**

---

## Build and Run

```bash
sudo docker compose up --build
