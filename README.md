# DevcomTestTask

## Опис
Цей проект є ASP.NET MVC додатком, побудованим з використанням принципів **Clean Architecture**. Він використовує **Entity Framework** для доступу до бази даних та **Google Identity Authentication** для автентифікації користувачів.

## Вимоги
- .NET 8.0 або новіша версія
- SQL Server або інша підтримувана база даних
- Google OAuth Client ID та Client Secret для автентифікації

### 1. Клонування репозиторію
### 2. У файлі appsettings.json налаштуйте строку з’єднання до бази даних
### 3. У appsettings.json ввести свої ключі до Google Identity (ClientId, ClientSecret)

Після налаштування проекту, вам потрібно застосувати міграції для створення таблиць в базі даних.

Відкрийте термінал у корені вашого проекту.
Виконайте команду для створення міграції:
##bash
##Копіювати код
## dotnet ef migrations add InitialCreate
Застосуйте міграцію до бази даних:
## bash
Копіювати код
## dotnet ef database update

Потрібно добавити в sql Stored Procedures та вставити код до них з файлу у папці Stored Procedures
Назви процедур:
spDeleteAnnouncement
spCreateAnnouncement
spGetAllAnnouncements
spGetAnnouncementById
spUpdateAnnouncement

dotnet run

Проект буде доступний за адресою: https://localhost:5001.

