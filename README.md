DevcomTestTask

Цей проект є ASP.NET MVC додатком, побудованим з використанням принципів Clean Architecture. Він використовує Entity Framework для доступу до бази даних та Google Identity Authentication для автентифікації користувачів.

Вимоги:
.NET 8.0 або новіша версія
SQL Server або інша підтримувана база даних
Google OAuth Client ID та Client Secret для автентифікації
Покрокова інструкція по налаштуванню проекту:
Клонуйте репозиторій: Використовуйте Git, щоб клонувати репозиторій:

bash
git clone https://github.com/Omega3D/DevcomTestTask.git
Налаштування з’єднання з базою даних: У файлі appsettings.json налаштуйте строку з’єднання до вашої бази даних:

json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=<your_server>;Database=<your_database>;User Id=<your_user>;Password=<your_password>;"
  }
}
Введення ключів для Google Identity: У файлі appsettings.json введіть ваші ключі Google Identity:

json
{
  "GoogleAuth": {
    "ClientId": "<Your_Google_Client_Id>",
    "ClientSecret": "<Your_Google_Client_Secret>"
  }
}
Створення міграцій для бази даних: Після налаштування проекту застосуйте міграції для створення таблиць у базі даних.

Створіть міграцію:
csharp
dotnet ef migrations add InitialCreate
Застосуйте міграцію до бази даних:
sql
Копіювати код
dotnet ef database update
Додавання SQL Stored Procedures: Додайте в базу даних наступні Stored Procedures. Код для кожної процедури збережіть у папці Stored Procedures:

spDeleteAnnouncement
spCreateAnnouncement
spGetAllAnnouncements
spGetAnnouncementById
spUpdateAnnouncement
Запуск проекту: Щоб запустити проект, використовуйте команду:

arduino
dotnet run
Проект буде доступний за адресою: https://localhost:5001.
