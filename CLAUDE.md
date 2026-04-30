# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

.NET MAUI learning project with 12 chapters (mod01–mod12). Each module is a self-contained MAUI app (or, in the case of mod10, an ASP.NET Core Web API).

| Module | Topic |
|--------|-------|
| mod01 | 認識 MAUI |
| mod02 | MAUI 進入點 / XAML |
| mod03 | MAUI Shell 與頁面導覽 |
| mod04 | 版面配置 |
| mod05 | 常用控制項 |
| mod06 | 輸入控制項 |
| mod07 | 資料 Binding |
| mod08 | MVVM 與資料 Binding |
| mod09 | 依賴注入 + MVVM (CommunityToolkit.Mvvm) |
| mod10 | ASP.NET Core Web API + EF Core (SQL Server) |
| mod11 | 使用 HttpClient 存取 Web API |
| mod12 | 部署 |

## Build and Run

```powershell
# Build a specific module
dotnet build .\mod04\mod04.csproj

# Run on Windows
dotnet run --project .\mod04\mod04.csproj -f net9.0-windows10.0.19041.0

# Run mod10 (Web API)
dotnet run --project .\mod10\mod10.csproj
```

mod01–mod09, mod11, mod12 target `net9.0-android;net9.0-ios;net9.0-maccatalyst` plus `net9.0-windows10.0.19041.0` (Windows only).  
mod10 targets `net8.0` as a standalone ASP.NET Core Web API.

## Architecture

### MAUI Modules (mod01–mod09, mod11, mod12)

Each module is a Single Project MAUI app:

```
mod0X/
├── MauiProgram.cs       # App entry — DI registrations, font config
├── App.xaml / App.xaml.cs
├── AppShell.xaml        # Shell navigation routes
├── Pages/ or Views/     # XAML pages + code-behind
├── ViewModels/          # MVVM ViewModels (mod08+)
├── Models/              # Data models (mod09+)
├── Services/            # Interfaces + implementations (mod09+)
├── Resources/           # Module-local fonts, images, styles
├── Platforms/           # Platform-specific bootstrapping
└── mod0X.csproj
```

**Shared resources** in `shared/Resources/` are linked into each module's `.csproj` via `Link=` on `<MauiImage>`, `<MauiFont>`, `<MauiAsset>` items rather than copied.

### mod10 — Web API

`mod10` is a standalone ASP.NET Core Web API (not a MAUI app):

```
mod10/
├── Program.cs            # Minimal API setup, EF Core + Swagger
├── Controllers/          # PetsController (CRUD), WeatherForecastController
├── Models/               # Pet entity, PetContext (DbContext), DbInitializer
└── mod10.csproj          # SDK: Microsoft.NET.Sdk.Web, net8.0
```

Connection string key is `PetConn` (SQL Server). `DbInitializer.Initialize` seeds data in Development.

### mod11 — MAUI HttpClient Client

mod11 is a MAUI app that consumes the mod10 Web API via `HttpClient`:

- `PetServiceFormWeb` implements `IPetService` using `HttpClient` (replaces the local `PetService` from mod09).
- Base URL switches by platform: `https://10.0.2.2:7046/api/pets/` on Android emulator, `https://localhost:7046/api/pets/` elsewhere.
- `HttpsClientHandlerService` provides a platform-specific `HttpMessageHandler` that trusts the dev localhost certificate on Android, iOS, and Windows.
- Connectivity is checked before each call via `Connectivity.Current.NetworkAccess`.

## Code Conventions

### MVVM (mod08+)

- ViewModels inherit `ViewModelBase : ObservableObject` (CommunityToolkit.Mvvm).
- Use `[ObservableProperty]` on private backing fields; the toolkit generates the public property.
- Use `[RelayCommand]` on methods; the toolkit generates the `ICommand` property.
- Register Views and ViewModels in `MauiProgram.cs` via `builder.Services`.
- Navigation: `await Shell.Current.GoToAsync(nameof(TargetPage))` or `AppShell.Current.GoToAsync(...)` with parameter dictionary for passing data.

### XAML

- File-scoped namespaces: `namespace mod04.Pages;`
- Pages are `partial` classes paired with `.xaml` files.
- Styles defined in `Resources/Styles/` and merged in `App.xaml`.
- Platform-conditional values: `{OnPlatform WinUI='...', iOS='...', Android='...'}`
- Device idiom: `{OnIdiom Default='...', Tablet='...', Phone='...'}`
- Views requiring explicit XAML compilation have `<MauiXaml Update="..."><Generator>MSBuild:Compile</Generator></MauiXaml>` in `.csproj`.

### csproj Resource Linking

When a module needs a shared resource, add it to `.csproj` with a `Link` attribute pointing into `Resources\Images\` or `Resources\Fonts\`:

```xml
<MauiImage Include="..\shared\Resources\Images\cat1.jpg" Link="Resources\Images\cat1.jpg" />
<MauiFont Include="..\shared\Resources\Fonts\OpenSansB\OpenSans-Regular.ttf" Link="Resources\Fonts\OpenSans-Regular.ttf" />
```

Incorrect relative paths or missing `Link` values cause runtime resource-not-found errors.
