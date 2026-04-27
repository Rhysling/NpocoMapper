# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What This Project Does

NpocoMapper is a C# code generation tool that reads a database schema (MS SQL Server or SQLite) and generates:
- **POCO classes** (ReadWrite for tables with PKs, ReadOnly for views/tables without PKs)
- **Repository classes** with NPoco-based CRUD operations
- **Enum classes** for lookup tables (tables whose names end in "Enum" or are in `ForceEnumList`)

The generated code is intended to drop into an application that uses the [NPoco](https://github.com/schotime/NPoco) micro-ORM.

## Solution Structure

- `NpocoMapper/` — the generator tool (.NET 10)
- `NpocoMapper.Demo/` — example project showing generated output (.NET 9)

## Build & Run

```bash
# Build
dotnet build NpocoMapper.sln

# Run the generator
dotnet run --project NpocoMapper/NpocoMapper.csproj
```

There are no automated tests in this repo.

## Architecture & Execution Flow

**Entry: `Program.cs`** — creates a `Settings` object and runs `Runner`. Currently hardcoded to a preset (`SettingsFromPresetMsSql` or `SettingsFromPresetSqlite`); command-line arg parsing via `BuildSettings` is implemented but commented out.

**`Runner.cs`** orchestrates:
1. `IDbOps.LoadColumns()` — queries DB schema into `Column` records
2. `Mapper.MapColumnsToPocos()` — transforms `Column` list into `Poco`/`PocoProp` objects with C# type mappings and class-type classification
3. `Output.Generate()` — drives file generation for enums, POCOs, and repos

**Database abstraction (`Ops/IDbOps.cs`)** — two implementations:
- `MsSqlDbOps` — T-SQL joins against `sys.*` and `INFORMATION_SCHEMA`
- `SqliteDbOps` — `sqlite_schema` + `PRAGMA table_info`; autoincrement detection via regex on the `CREATE TABLE` SQL

**Code generation (`Ops/Writer.cs`)** — static methods using `StringBuilder` to produce raw C# source. `Output.cs` coordinates which writers are called and routes to `FileOps.SaveFile`.

## Key Models

| Model | Role |
|-------|------|
| `Settings` | All configuration: paths, namespaces, DB connection, generation/overwrite flags |
| `Column` | Raw DB schema row (table name, column name, SQL type, PK/identity/computed flags) |
| `Poco` | A C# class to generate — holds `ClassType` (Rw/Ro/Enum), primary keys, and a list of `PocoProp` |
| `PocoProp` | One property: C# type, nullability, identity, sequence |
| `EnumPoco` / `EnumPocoProp` | Enum definition and its values loaded from DB |
| `EntityType` | Enum classifying output artifacts: `Enum`, `PocoRw`, `PocoRo`, `RepoRw`, `RepoRo`, `RepoBase` |

## ClassType Determination (Mapper.cs)

- EntityName ends with `"Enum"` → `ClassType = "Enum"`
- Table with at least one PK → `ClassType = "Rw"` (read-write)
- Table without PK, or any view → `ClassType = "Ro"` (read-only)

## Output Directory Layout

```
basePath\Models\Generated\
    Enums\
    PocosRw\
    PocosRo\

basePath\Repos\Generated\
    Core\          ← RepositoryBase.cs (generated once)
    Rw\
    Ro\
```

The `.csproj` files in the Demo project exclude `Generated/` folders from compilation by default so regenerated files don't conflict with manual edits.

## Settings Flags

| Flag | Default | Effect |
|------|---------|--------|
| `GenerateEnums/Pocos/Repos` | `true` | Toggle generation of each artifact type |
| `OverwriteEnums` | `true` | Enums are always regenerated |
| `OverwritePocos` | `false` | Prevents clobbering manually edited POCOs |
| `OverwriteRepos` | `false` | Prevents clobbering manually edited repos |
| `IgnoreTableNames[]` | — | Tables to skip entirely |
| `ForceEnumList[]` | — | Force specific tables to generate as enums |
| `IncludeTsModelAttribute` | — | Adds `[TypeScriptModel]` attribute to POCOs |

## Generated Repo Behavior

- Repos extend `RepositoryBase` which wraps NPoco's `Database`
- `Delete()` performs a soft delete (sets `IsDeleted = true`) if the POCO has an `IsDeleted` column; otherwise hard deletes
- `FilteredList` and `PagedFilteredList` are placeholder stubs that need project-specific customization after generation
