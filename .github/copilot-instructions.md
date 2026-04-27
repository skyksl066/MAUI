# Copilot Instructions for MAUI

## 📚 Learning Project Overview

This is a **learning project** for .NET MAUI. Each module (`mod01`, `mod02`, `mod03`) represents a separate teaching chapter, with each chapter focusing on a specific MAUI topic or feature.

- **mod01**: Assets and documentation
- **mod02**: Core MAUI concepts and basic UI patterns
- **mod03**: Advanced features (navigation, multiple pages, resource organization)

Each module is a standalone MAUI application demonstrating different aspects of cross-platform development.

### Technology Stack

MAUI (.NET Multi-platform App UI) is a cross-platform framework for building native mobile and desktop apps from a single codebase.

- **Target Frameworks**: .NET 9.0 with multi-platform support (Android, iOS, macOS, Windows)
- **Project Type**: Cross-platform mobile/desktop applications
- **Architecture**: Single Project architecture with platform-specific code in `Platforms/` folders

## Build and Run Commands

### Building
```bash
# Build mod02
dotnet build mod02/mod02.csproj

# Build mod03
dotnet build mod03/mod03.csproj

# Build for specific platform
dotnet build mod02/mod02.csproj -f net9.0-windows10.0.19041.0
```

### Running
```bash
# Run mod02 on Windows
dotnet run --project mod02/mod02.csproj -f net9.0-windows10.0.19041.0

# Run mod03 on Windows
dotnet run --project mod03/mod03.csproj -f net9.0-windows10.0.19041.0
```

### Testing
No test projects currently exist in the repository. When tests are needed, they should be added as separate projects with the naming convention `{ProjectName}.Tests`.

## Project Structure & Architecture

### Directory Layout
```
MAUI/
├── mod02/              # MAUI app project
│   ├── MauiProgram.cs  # App initialization & dependency injection
│   ├── App.xaml        # Application-level resources
│   ├── AppShell.xaml   # Shell navigation structure
│   ├── MainPage.xaml   # Entry page
│   ├── Resources/      # Styles, fonts, images, assets
│   ├── Platforms/      # Platform-specific code
│   └── mod02.csproj    # Project configuration
├── mod03/              # Another MAUI app project
│   ├── Pages/          # Organized pages (see below)
│   ├── Platforms/
│   └── [same structure as mod02]
└── mod01/              # Assets/documentation
```

### Page Organization Pattern

**mod02**: Uses flat structure with pages in root directory
- `MainPage.xaml` / `MainPage.xaml.cs`

**mod03**: Uses organized structure with `Pages/` folder
- `ShopPage.xaml` / `ShopPage.xaml.cs`
- `ShopDetails.xaml` / `ShopDetails.xaml.cs`
- `ProfilePage.xaml` / `ProfilePage.xaml.cs`
- `SettingPage.xaml` / `SettingPage.xaml.cs`

**Recommendation**: Use the `Pages/` folder approach for new pages to keep projects organized as they grow.

### App Initialization

Each project follows the standard MAUI pattern:
1. `MauiProgram.cs` configures the app builder with fonts, logging (DEBUG only), and custom styles
2. `App.xaml` merges resource dictionaries for theming and styling
3. `AppShell.xaml` defines navigation routes and shell structure
4. Pages use XAML + code-behind pattern with `partial` classes

## XAML and Code-Behind Conventions

### XAML Styling
- Global styles are defined in `Resources/Styles/` and merged in `App.xaml`
- Custom XAML files (e.g., `Lables.xaml`, `Styles.xaml`) are registered as `MauiXaml` items in `.csproj`
- Static resources referenced with `{StaticResource ResourceName}`

### Code-Behind Pattern
```csharp
namespace mod03.Pages;

public partial class ShopPage : ContentPage
{
    public ShopPage()
    {
        InitializeComponent();
    }
    
    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync(nameof(ShopDetails));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}
```

**Key patterns**:
- Use file-scoped namespaces (`namespace X;` syntax)
- Use `partial` keyword for classes with XAML markup
- Page transitions use `Shell.Current.GoToAsync()`
- Error handling with `try/catch` and `DisplayAlert()` for user feedback
- Async/await for navigation and long operations

### XAML Usage Notes
- Use `VerticalStackLayout` or `StackLayout` for layout management
- Platform-conditional values: `{OnPlatform WinUI='...', iOS='...', Android='...', Default='...'}`
- Device idiom detection: `{OnIdiom Default='...', Tablet='...', Phone='...', Desktop='...', TV='...'}`
- Bindings to system values: `{x:Static Member=System.Environment.MachineName}`

## Resource Management

### Fonts
Custom fonts added in `.csproj`:
```xml
<MauiFont Include="Resources\Fonts\*" />
```
Registered in `MauiProgram.cs`:
```csharp
fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
```

### Images & Assets
- Images: `Resources/Images/*` (auto-resized based on configuration)
- Raw assets: `Resources/Raw/**`
- Icons: `Resources/AppIcon/appicon.svg` + foreground file
- Splash: `Resources/Splash/splash.svg`

## Platform-Specific Code

Platform-specific implementations are in `Platforms/{PlatformName}/` folders:
- `Platforms/Android/`
- `Platforms/iOS/`
- `Platforms/MacCatalyst/`
- `Platforms/Windows/`

Use conditional compilation or dependency injection to access platform-specific APIs.

## .NET 9.0 and ImplicitUsings

Projects have `ImplicitUsings` and `Nullable` enabled:
- `<ImplicitUsings>enable</ImplicitUsings>` - No need to include common `using` statements
- `<Nullable>enable</Nullable>` - Strict null-checking enabled; use `?` for nullable types
- File-scoped namespaces preferred: `namespace ModName;` instead of braces

## Debugging

Add debug logging in `MauiProgram.cs` (already configured):
```csharp
#if DEBUG
    builder.Logging.AddDebug();
#endif
```

On Windows, debug output appears in Visual Studio's Output pane when running.

## Resources Merged from App.xaml

When creating new XAML resource files, register them in the project file:
```xml
<ItemGroup>
  <MauiXaml Update="Resources\Styles\NewFile.xaml">
    <Generator>MSBuild:Compile</Generator>
  </MauiXaml>
</ItemGroup>
```

Then merge in `App.xaml`:
```xml
<ResourceDictionary Source="Resources/Styles/NewFile.xaml" />
```
