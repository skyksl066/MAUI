# Copilot Instructions for MAUI

## 📚 Learning Project Overview

.NET MAUI learning project with 7 modules:

- **mod01**: 認識 MAUI
- **mod02**: MAUI 進入點 / XAML
- **mod03**: MAUI Shell 與頁面導覽
- **mod04**: 版面配置
- **mod05**: 常用控制項
- **mod06**: 輸入控制項
- **mod07**: 資料 Binding

**Stack**: .NET 9.0, Android/iOS/macOS/Windows, Single Project architecture

## Build and Run Commands

```bash
# Build
dotnet build mod04/mod04.csproj

# Run on Windows
dotnet run --project mod04/mod04.csproj -f net9.0-windows10.0.19041.0
```

## Project Structure

```
mod0X/
├── MauiProgram.cs      # App initialization
├── App.xaml            # App-level resources
├── AppShell.xaml       # Navigation routes
├── Pages/              # Page views (XAML + code-behind)
├── Resources/          # Styles, fonts, images
├── Platforms/          # Platform-specific code
└── mod0X.csproj
```

## Code Conventions

### XAML + Code-Behind
```csharp
namespace mod04.Pages;

public partial class MyPage : ContentPage
{
    public MyPage()
    {
        InitializeComponent();
    }
}
```

- File-scoped namespaces: `namespace X;`
- Use `partial` keyword with XAML
- Navigation: `await Shell.Current.GoToAsync(nameof(TargetPage))`
- Error handling: `await DisplayAlert("Title", "Message", "OK")`

### Styling
- Define in `Resources/Styles/` as XAML files
- Register in `.csproj` as `<MauiXaml>`
- Merge in `App.xaml`: `<ResourceDictionary Source="Resources/Styles/Custom.xaml" />`
- Use: `{StaticResource ResourceName}`

### Layout
- `VerticalStackLayout`, `HorizontalStackLayout`, `Grid`
- Platform-conditional: `{OnPlatform WinUI='...', iOS='...', Android='...', Default='...'}`
- Device idiom: `{OnIdiom Default='...', Tablet='...', Phone='...'}`

### Resources
- Fonts: `Resources/Fonts/*` (register in `MauiProgram.cs`)
- Images: `Resources/Images/*`
- Icons/Splash: `Resources/AppIcon/appicon.svg`, `Resources/Splash/splash.svg`

### .NET 9.0 Features
- `ImplicitUsings` enabled (no common `using` statements needed)
- `Nullable` enabled (use `?` for nullable types)
- File-scoped namespaces preferred
