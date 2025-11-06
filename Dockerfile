FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["mini_blog/mini_blog.csproj", "mini_blog/"]
RUN dotnet restore "mini_blog/mini_blog.csproj"
COPY . .
WORKDIR "/src/mini_blog"
RUN dotnet publish -c Release -o /app/out

FROM base AS final
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "mini_blog.dll"]

