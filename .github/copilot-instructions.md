# Copilot Instructions for MAUI

## 📚 Learning Project Overview

.NET MAUI learning project — 12 chapters planned (10 implemented, 2 reserved):

- **mod01**: 認識 MAUI
- **mod02**: MAUI 進入點 / XAML
- **mod03**: MAUI Shell 與頁面導覽
- **mod04**: 版面配置
- **mod05**: 常用控制項
- **mod06**: 輸入控制項
- **mod07**: 資料 Binding
- **mod08**: MVVM與資料 Binding
- **mod09**: 注入與MVVMS
- **mod10**: WebAPI 與 EFCore
- **mod11**: 使用 HttpClient 存取 Web API
- **mod12**: 部署

**Stack**: .NET 9.0 (mod10: .NET 8.0), Android/iOS/macOS/Windows, Single Project architecture

## Build and Run Commands

```powershell
# Build
dotnet build .\mod04\mod04.csproj

# Run on Windows
dotnet run --project .\mod04\mod04.csproj -f net9.0-windows10.0.19041.0
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
- Fonts: `Resources/Fonts/*` (register in `MauiProgram.cs`). 注意：部分模組使用 `shared\\Resources\\Fonts\\` 下的字型，透過 csproj 的 Link 引入。
- Images: `Resources/Images/*`（模組可能會從 `shared\\Resources\\Images\\` link 圖片）
- Icons/Splash: `Resources/AppIcon/appicon.svg`, `Resources/Splash/splash.svg`

### .NET 9.0 Features
- `ImplicitUsings` enabled (no common `using` statements needed)
- `Nullable` enabled (use `?` for nullable types)
- File-scoped namespaces preferred
