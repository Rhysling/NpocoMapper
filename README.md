# NPoco Mapper

NpocoMapper is a C# code generation tool that reads a database schema (MS SQL Server or SQLite) and generates classes:
- **POCO classes** (ReadWrite for tables with PKs, ReadOnly for views/tables without PKs)
- **Repository classes** with NPoco-based CRUD operations
- **Enum classes** for lookup tables (tables whose names end in "Enum" or are in `ForceEnumList`)

The generated code is intended to drop into an application that uses the [NPoco](https://github.com/schotime/NPoco) micro-ORM.

## The Application

**Build and run NpocoMapper.exe as a console application.**

Arguments may be supplied inline and in a tab-delimited `settings.txt` file co-located with the exe.
Inline arguments take precedence.

## Argument Structure

### REQUIRED:
		applicationName=MyApp.Namespace
		basePath=D:\path\to\where\files\written
		dbName=TheDbName
		dbType=MsSql|Sqlite
		dbConnStr=TheConnectionString

### OPTIONAL:
		generateEnums=true|false (default true)
		overwriteEnums=true|false (default true)
		generatePocos=true|false (default true)
		overwritePocos=true|false (default false)
		generateRepos=true|false (default true)
		overwriteRepos=true|false (default false)
		includeTsModelAttribute=true|false (not used)

		ignoreTableNames=table1,table2,table3 (default empty)

In a tab-delimited form (`settings.txt`):
	applicationName -tab- MyApp.Namespace
	basePath -tab- D:\path\to\where\files\written
	etc.

## ClassType Determination

- EntityName ends with `"Enum"` → `ClassType = "Enum"`
- Table with at least one PK → `ClassType = "Rw"` (read-write)
- Table without PK, or any view → `ClassType = "Ro"` (read-only)

## Output Directory Layout

```
basePath\Models\Generated\
	Core\      ← NameValueItem.cs and TypeScriptModelAttribute.cs (generated once)
    Enums\
    PocosRw\
    PocosRo\

basePath\Repos\Generated\
    Core\      ← RepositoryBase.cs (generated once)
    Rw\
    Ro\
```
