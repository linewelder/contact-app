# Contact App

## Running

Required `appsettings.Production.json`:

```json
{
  "ConnectionStrings": {
    "Default": "{Database connection string}"
  },
  "Smtp": {
    "Host": "{SMTP server hostname}",
    "Username": "{SMTP server username}",
    "Password": "{SMTP server password}",
    "SelfMailAddress": "{E-mail address used when sending mail}",
    "SelfMailDisplayName": "{Display name used when sending mail}"
  }
}
```
