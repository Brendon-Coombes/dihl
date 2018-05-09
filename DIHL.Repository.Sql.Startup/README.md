# Entity Framework Guidance

## To add a data model
 1. Create Data Model in Repository project
 1. Register data model with DBContext
    - Add DbSet Property
    - Define modelbuilder behaviour
 1. Run Add Migration -see below
 1. Run Update Migration

## Entity Framework commands
>  run from within .Sql project 

### To add a migration
`
dotnet ef --startup-project ..\DIHL.Repository.Sql.Startup\ migrations add "InitialMigration"
`

### To update the database
`
dotnet ef --startup-project ..\DIHL.Repository.Sql.Startup\ database update
`

### To remove a migration

First you must update the database to the migration you'd like to roll back to:

`
 dotnet ef --startup-project ..\Intergen.Xamarin.Repository.Sql.Startup\ database update <previous-migration>
`

Then remove the most recent migration:

`
dotnet ef --startup-project ..\Intergen.Xamarin.Repository.Sql.Startup\ migrations remove
`

### To generate an idempotent script for updating databases. 

`
dotnet ef --startup-project ..\Intergen.Xamarin.Repository.Sql.Startup\ migrations script 0  -i -o "update-database.sql"
`

> Replace "0" with the migration name from the destination database. 0 represents the initial migration.  
> You can also specify a target migration by adding the migration name after the source migration name.  
> The -i flag means that the script can be run on any version of the database.
> [See the docs](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet)