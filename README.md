# WeeekDotNetHelper

1. Создать API токен в ЛК Weeek, вставить в appSettings.json.
2. Запустить метод получения задач, чтобы посмотреть id полей. Вставить их в код.
3. Запустить метод перебора и обновления задач.

Пример `appSetting.json`:

```json
{
  "WeeekApi": {
    "ApiUrl": "https://api.weeek.net/public/v1/",
    "Token": "your-token-here"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
