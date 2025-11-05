# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY mini_blog/*.csproj ./mini_blog/
RUN dotnet restore mini_blog/mini_blog.csproj

# Copy everything else and build
COPY . .
WORKDIR /src/mini_blog
RUN dotnet publish -c Release -o /app/out

# Stage 2: Run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "mini_blog.dll"]

