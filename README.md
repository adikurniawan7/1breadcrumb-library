# 1breadcrumb-library

This is an API and web app quickly put together to as a prototype for company-wide Crumb-to-Crumb book lending library (the Library).

1breadcrumb library API contains 5 endpoints
1. `GET /book/books`
<br/>get all books.
2. `GET /book/{id}`
<br/>get a book by id 
3. `DELETE /book/{id}`
<br/> delete a book by id
4. `PUT /book/{id}`
<br/> update a book by id
5. `POST /book`
<br/> remove a book by id

1breadcrumb library app features:
1. List all books
2. Search book by title and owner
3. Delete book

## Requirements

.NET Core 9.0, Visual Studio 2022 (Recommended)

## How do I get started?

1. Download this project from GitHub 
   https://github.com/adikurniawan7/1breadcrumb-library
2. Open project in Visual Studio
3. Run (F5) and check the output window or console for listening port.
   In `launchSettings.json` it's currently set as `https://localhost:7220`
4. To test each endpoints, run swagger `https://localhost:7220/swagger/index.html`
5. Install library app under `library-app` folder by running `yarn`
6. Build app by running `yarn build`
7. Run app by running `yarn dev` then open `https://localhost:5173`
8. `books.json` is created as a 'database' under api/OneBreadcrumbLibrary folder. `books.backup.json` is a backup file to reset database.

## Considerations

Due to limited time constraints, a JSON file is created as a database as it would take a bit more time to setup a SQL database.
But this choice comes with limitation, e.g., not able to have a correct relational database. Owner of a book should be a separate table.
Book should be it's own table, and there should be a reference table with FK between book and owner.

## Future improvements

1. Unit Test!
2. Add features on front-end to update availability, add new book, etc.
3. Improve design
4. Integrate API to 1Breadcrumb API library

## How do I test this project?

Unfortunately Unit Test has not been created for this project due to time constraint. 
Future release will see Unit Test added to test each API endpoint.

## Support

Please contact Adi Kurniawan at 7adikurniawan@gmail.com for any issues.
<br/>Thank you for the opportunity. This has been really fun.
