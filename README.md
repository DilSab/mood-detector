## Mood Detector

### About

This project uses emotion recognition to give teachers feedback about their lectures by analyzing students' mood.

### Get started

#### Requirements:

* Visual Studio 2019
* .NET 4.7.2
* SQL Server
* NuGet (package management)

#### Dependencies:

* AutoFac (dependency injection)
* Affdex (emotion recognition)
* xUnit (unit testing)

### Database

We use SQL Server.

#### Creating a local database

Go to `SQLServer project -> PublishProfiles` and open `LocalSQLServerDatabase.publish.xml` file. From there press Publish. Your local database can be found in `View -> SQL Server Object Explorer (or shortcut Ctrl+\, Ctrl+S) -> (localdb)\MSSQLLocalDB -> Databases -> MoodDetectorDB`.

#### Creating a new table

Go to `SQLServer project -> dbo -> (Context menu) Add -> Table`.

#### Updating your local database

To update database (e.g. when files inside `SQLServer -> dbo` are changed) you need to open `LocalSQLServerDatabase.publish.xml` and click `Publish` again. This will update changed tables, views to match the ones defined in `dbo` folder files.

### Naming

* `PascalCase` Class name; Constructor name; Method name; Constants name; Properties name; Delegate name; Enum type name
* `camelCase` method arguments; local variables, _field name
* Do prefix Interfaces with letter `I` e.g. `IExample`
* Do prefix field names with underscore e.g. `_fieldName`

### Git workflow

* For task management we use GitHub's inbuilt task board
* We name our branches `Task#<task_number>` e.g. `Task#1`
  - Create a new local branch and go to it using `git checkout -b Task#<task_number>`
* We use `pull requests` for code reviews and, after approval, merge them using `squash merging` option
* When making a pull request make sure your branch is updated to the latest master
  - `git commit` changes made in your branch use `-m` option to add a message with commit e.g. `git commit -m "<changes_made>"`
  - Go to master branch with `git checkout master` and update it using `git pull`
  - Go back to your branch `git checkout Task#<task_number>`
  - Merge master into your branch `git merge master`
  - You might get merge conflicts, resolve them
  - `git add` changed files and `git commit` them
  - `git push` your changes to remote branch
