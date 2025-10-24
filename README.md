# JWT Authentication API with Role-Based Access Control

A secure .NET Web API implementing JWT authentication with role-based authorization (Admin and User roles).

## 🚀 Features

- ✅ JWT Token Authentication (Access & Refresh Tokens)
- ✅ Role-Based Authorization (Admin & User)
- ✅ User Registration & Login
- ✅ Password Hashing (BCrypt)
- ✅ Token Refresh Mechanism
- ✅ User Management (Admin only)
- ✅ Change Password
- ✅ Swagger UI with JWT Support
- ✅ PostgreSQL Database

## 📋 Prerequisites

- .NET 8.0 or higher
- PostgreSQL
- Visual Studio Code or Visual Studio

## ⚙️ Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/KaranBastola84/JWT-Role-Based-Auth-CSharp.git
cd JWT-Role-Based-Auth-CSharp
```

### 2. Configure Database Connection

Create `appsettings.Development.json` (not tracked in git):

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=jwt_auth_api_db;Username=YOUR_USERNAME;Password=YOUR_PASSWORD"
  },
  "Jwt": {
    "Key": "your-super-secret-key-at-least-32-characters-long-replace-this",
    "Issuer": "https://localhost:5001",
    "Audience": "https://localhost:5001"
  }
}
```

**Important:** Replace:

- `YOUR_USERNAME` with your PostgreSQL username
- `YOUR_PASSWORD` with your PostgreSQL password
- `Key` with a strong random secret key (minimum 32 characters)

### 3. Update Database

```bash
dotnet ef database update
```

### 4. Run the Application

```bash
dotnet run
```

The API will be available at: `http://localhost:5147`

Swagger UI: `http://localhost:5147/swagger`

## 🔐 API Endpoints

### Authentication

| Method | Endpoint                   | Description          | Access |
| ------ | -------------------------- | -------------------- | ------ |
| POST   | `/api/auth/register`       | Register new user    | Public |
| POST   | `/api/auth/register-admin` | Register admin       | Public |
| POST   | `/api/auth/login`          | Login                | Public |
| POST   | `/api/auth/refresh`        | Refresh access token | Public |
| POST   | `/api/auth/logout`         | Logout               | Public |

### User Management

| Method | Endpoint                                    | Description      | Access        |
| ------ | ------------------------------------------- | ---------------- | ------------- |
| GET    | `/api/usermanagement/profile`               | Get own profile  | Authenticated |
| PUT    | `/api/usermanagement/change-password`       | Change password  | Authenticated |
| GET    | `/api/usermanagement/users`                 | Get all users    | Admin         |
| GET    | `/api/usermanagement/users/{id}`            | Get user by ID   | Admin         |
| PUT    | `/api/usermanagement/users/{id}/role`       | Update user role | Admin         |
| PUT    | `/api/usermanagement/users/{id}/activate`   | Activate user    | Admin         |
| PUT    | `/api/usermanagement/users/{id}/deactivate` | Deactivate user  | Admin         |
| DELETE | `/api/usermanagement/users/{id}`            | Delete user      | Admin         |

## 🧪 Testing with Swagger

1. Navigate to `http://localhost:5147/swagger`
2. Register a user using `/api/auth/register`
3. Login using `/api/auth/login`
4. Copy the `access` token from the response
5. Click the **🔒 Authorize** button at the top right
6. Paste your token (without "Bearer" prefix)
7. Click **Authorize** then **Close**
8. Now you can access protected endpoints!

## 👥 Roles

- **User**: Standard user with limited access
- **Admin**: Full access including user management

## 🔒 Security Features

- Password hashing with BCrypt
- JWT token-based authentication
- Refresh token rotation
- Token expiration (1 hour for access, 7 days for refresh)
- Role-based authorization
- Inactive user checks
- Self-protection for admins

## 📁 Project Structure

```
JWTAuthAPI/
├── Controllers/
│   ├── AuthController.cs
│   └── UserManagementController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Models/
│   ├── ApplicationUser.cs
│   ├── ApiResponse.cs
│   ├── LoginDto.cs
│   ├── RegisterDto.cs
│   ├── RefreshTokenDto.cs
│   ├── ChangePasswordDto.cs
│   ├── UpdateRoleDto.cs
│   └── Roles.cs
├── Services/
│   └── JwtService.cs
├── Migrations/
├── Properties/
│   └── launchSettings.json
├── appsettings.json
└── Program.cs
```

## 🛠️ Technologies Used

- ASP.NET Core 8.0
- Entity Framework Core
- PostgreSQL
- JWT (JSON Web Tokens)
- BCrypt.Net
- Swagger/OpenAPI

## 📝 Environment Variables

For production, use environment variables instead of `appsettings.json`:

```bash
export ConnectionStrings__DefaultConnection="Host=...;Database=...;Username=...;Password=..."
export Jwt__Key="your-production-secret-key"
export Jwt__Issuer="https://your-domain.com"
export Jwt__Audience="https://your-domain.com"
```

## 🚨 Important Security Notes

⚠️ **Never commit these files with real credentials:**

- `appsettings.Development.json` (already in .gitignore)
- `appsettings.Production.json`
- `appsettings.Local.json`

⚠️ **Before deploying to production:**

1. Generate a strong JWT secret key (64+ characters)
2. Use environment variables for sensitive data
3. Enable HTTPS
4. Update CORS policy
5. Restrict `/api/auth/register-admin` endpoint

## 📄 License

MIT License

## 👤 Author

Karan Bastola

- GitHub: [@KaranBastola84](https://github.com/KaranBastola84)

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!