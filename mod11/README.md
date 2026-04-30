# mod11

## publish Android
### key.keystore

```bash

keytool -genkey -v -keystore key.keystore -alias MauiAlias -keyalg RSA -keysize 2048 -validity 10000

```

### publish

```bash

dotnet publish mod11.csproj -c Release -f:net9.0-android

```

### install

```bash

adb install com.uuu.maui-Signed.apk

```

## publish Window

### setting

```csproj
<WindowsPackageType>MSIX</WindowsPackageType>
```

### publish

1. publish
2. 產生憑證
3. 詳細資料->安裝憑證->受信任根憑證
4. 設定profile
5. 安裝位置

## notification

## 本機通知
https://learn.microsoft.com/zh-tw/dotnet/maui/platform-integration/local-notifications?view=net-maui-10.0&pivots=devices-android

## 推撥
https://learn.microsoft.com/zh-tw/dotnet/maui/data-cloud/push-notifications?view=net-maui-10.0