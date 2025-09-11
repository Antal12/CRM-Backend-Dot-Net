using CRM.API.Filters;
using CRM.Application.Dtos.Auth;
using CRM.Application.Interfaces;
using CRM.Application.Mappings;
using CRM.Application.Services.Implementations;
using CRM.Application.Services.Interfaces;
using CRM.Application.Services.Services;
using CRM.Application.Validators;
using CRM.Infrastructure.Persistence.Repositories;
using CRM.Infrastructure.Repositories;
using CRMBackend.Infrastructure.Data;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ✅ 1. Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddAppDatabase(connectionString);

// ✅ 2. AutoMapper
builder.Services.AddAutoMapper(
    typeof(UserProfile),
    typeof(AuthProfile),
    typeof(RoleProfile),
    typeof(UserRoleProfile),
    typeof(CustomerMappingProfile),
    typeof(OpportunityMappingProfile),
    typeof(QuoteMappingProfile),
    typeof(InvoiceMappingProfile),
    typeof(LeadMappingProfile),
    typeof(AuditLogMappingProfile),
    typeof(NotificationMappingProfile),
    typeof(ReportMappingProfile)
);

// ✅ 3. Repositories
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOpportunityRepository, OpportunityRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IQuoteRepository, QuoteRepository>();
builder.Services.AddScoped<ILeadRepository, LeadRepository>();

// ✅ 4. Services
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOpportunityService, OpportunityService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IQuoteService, QuoteService>();
builder.Services.AddScoped<ILeadService, LeadService>();

// ✅ 5. JWT Settings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
var key = Encoding.UTF8.GetBytes(jwtSettings.Key);

// ✅ 6. Authentication & Authorization
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();

// ✅ 7. Controllers & Validation
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>(); // global validation filter
})
.AddFluentValidation(fv =>
{
    // 👇 Register ALL validators from Application layer
    fv.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<RoleDtoValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<UserRoleDtoValidator>()
    .RegisterValidatorsFromAssemblyContaining<CustomerDtoValidator>(); ;
    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;

});

// ✅ 8. Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CRM API",
        Version = "v1"
    });

    // 🔑 Enable JWT in Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by your JWT token.\nExample: Bearer eyJhbGciOiJIUzI1..."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// ✅ 9. Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // must come before authorization
app.UseAuthorization();

app.MapControllers();

app.Run();
