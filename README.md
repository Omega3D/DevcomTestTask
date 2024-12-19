# DevcomTestTask

## Опис
Цей проект є ASP.NET MVC додатком, побудованим з використанням принципів **Clean Architecture**. Він використовує **Entity Framework** для доступу до бази даних та **Google Identity Authentication** для автентифікації користувачів.

## Вимоги
- **.NET 8.0** або новіша версія
- **SQL Server** або інша підтримувана база даних
- **Google OAuth Client ID та Client Secret** для автентифікації

## Покрокова інструкція по налаштуванню проекту

### 1. Клонування репозиторію
Клонуйте репозиторій за допомогою Git:
```bash
git clone https://github.com/Omega3D/DevcomTestTask.git
2. Налаштування з’єднання з базою даних
У файлі appsettings.json налаштуйте строку з’єднання до вашої бази даних:

json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=<your_server>;Database=<your_database>;User Id=<your_user>;Password=<your_password>;"
  }
}
3. Введення ключів для Google Identity
У файлі appsettings.json введіть ваші ключі Google Identity:

json
{
  "GoogleAuth": {
    "ClientId": "<Your_Google_Client_Id>",
    "ClientSecret": "<Your_Google_Client_Secret>"
  }
}
4. Створення міграцій для бази даних
Після налаштування проекту, потрібно застосувати міграції для створення таблиць в базі даних.

Створення міграції
Відкрийте термінал у корені вашого проекту та виконайте команду:

bash
dotnet ef migrations add InitialCreate
Застосування міграції
Застосуйте міграцію до бази даних:

bash
dotnet ef database update
5. Додавання SQL Stored Procedures
Додайте в базу даних наступні Stored Procedures. Код для кожної процедури збережіть в окремих файлах у папці Stored Procedures.

spDeleteAnnouncement
spCreateAnnouncement
spGetAllAnnouncements
spGetAnnouncementById
spUpdateAnnouncement
6. Запуск проекту
Щоб запустити проект, використовуйте команду:
dotnet run
Проект буде доступний за адресою: https://localhost:5001.

