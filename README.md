# Library Management System

Это приложение для управления библиотекой с использованием WPF и Entity Framework. Оно позволяет добавлять, редактировать и удалять авторов и жанры книг, а также просматривать информацию о книгах в библиотеке.

## Зависимости

1. **.NET 8.0**  
   Приложение построено на .NET 8.0. Убедитесь, что у вас установлена эта версия SDK.
   - Для установки .NET SDK, посетите [официальный сайт](https://dotnet.microsoft.com/download).

2. **Microsoft.EntityFrameworkCore**  
   Для работы с базой данных используется Entity Framework Core, который обеспечивает взаимодействие с SQL Server.
   - Для установки используйте команду:
     ```bash
     Install-Package Microsoft.EntityFrameworkCore

     ```

3. **Microsoft.EntityFrameworkCore.SqlServer**  
   Для работы с SQL Server используем этот пакет.
   - Установка:
     ```bash
     Install-Package Microsoft.EntityFrameworkCore.SqlServer
     ```

4. **Microsoft.Extensions.DependencyInjection**  
   Этот пакет используется для внедрения зависимостей в проект.
   - Установка:
     ```bash
     Install-Package Microsoft.Extensions.DependencyInjection
     ```

5. **Microsoft.EntityFrameworkCore.Tools**  
   Этот пакет необходим для использования команд в консоли для работы с миграциями.
   - Установка:
     ```bash
     Install-Package Microsoft.EntityFrameworkCore.Tools
     ```
   **Выполняем миграции**  

     ```bash
     Add-Migration InitialCreate
     ```
     
     ```bash
     Update-Database
     ```
## Установка зависимостей

1. Склонируйте репозиторий на вашу локальную машину:
   ```bash
   git clone https://github.com/1vanch0s/Csharp-Books-Library
   cd WpfApp1
