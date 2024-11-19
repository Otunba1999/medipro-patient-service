using System.Security.Claims;
using System.Text.Json.Serialization;
using Keycloak.AuthServices.Authorization;
using medipro_patient_service.Api.Middleware;
using medipro_patient_service.Application.Middleware;
using Medipro_Patient_Service.Infrastructure.HttpService;
using medipro_patient_service.Persistence.Repositories;
using medipro_patient_service.Persistence.Repositories.Configs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "SparkVerify Service", Version = "v1" });
    c.UseDateOnlyTimeOnlyStringConverters();
    c.AddSecurityDefinition("Keycloak", new OpenApiSecurityScheme()
    {
        // In = ParameterLocation.Header,
        Description = "Please provide the bearer token here",
        Name = "Authorization",
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows()
        {
            Implicit = new OpenApiOAuthFlow()
            {
                AuthorizationUrl = new Uri(builder.Configuration["Keycloak:AuthorizationUrl"]!),
                Scopes = new Dictionary<string, string>
                {
                    { "openid", "openid" },
                    { "profile", "profile" }
                }
            }
        }
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Keycloak"
                },
                In = ParameterLocation.Header,
                Name = "Bearer",
                Scheme = "Bearer"
            },
            Array.Empty<string>()
        }
    });
    // var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    // c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver()
    {
        NamingStrategy = new CamelCaseNamingStrategy()
    };
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.Audience = builder.Configuration["Authentication:Audience"];
        o.MetadataAddress = builder.Configuration["Authentication:MetadataAddress"]!;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Authentication:ValidIssuer"],
            RoleClaimType = "realm_access.roles"
        };
        // o.Events = new JwtBearerEvents()
        // {
        //     OnTokenValidated = ctx =>
        //     {
        //         List<AuthenticationToken> tokens = ctx.Properties!.GetTokens().ToList();
        //         ClaimsIdentity claimsIdentity = (ClaimsIdentity)ctx.Principal!.Identity;
        //         var realm_access = claimsIdentity.FindFirst((claim) => claim.Type == "realm_access")?.Value;
        //         JObject obj = JObject.Parse(realm_access);
        //         var roleAccess = obj.GetValue("roles");
        //         foreach (JToken role in roleAccess!)
        //         {
        //             claimsIdentity.AddClaim(new Claim("role", role.ToString()));
        //         }
        //         return Task.CompletedTask;
        //     }
        // };
    });
// builder.Services.AddAuthorization(o =>
//     {
//         o.AddPolicy("RequirePatientRead",
//             b =>
//             {
//                 b.RequireRealmRoles("PATIENT_READ");
//                 b.RequireRole("PATIENT_READ");
//             });
//     }).AddKeycloakAuthorization(builder.Configuration)
//     .AddAuthorizationServer(builder.Configuration);
//
// builder.Services.AddKeycloakWebApiAuthentication(builder.Configuration);
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("RequirePatientRead", policy => 
        policy.RequireRealmRoles("PATIENT_READ"))
    .AddPolicy("RequirePatientWrite", policy => 
        policy.RequireRole("PATIENT_WRITE"));
builder.Services.AddDatabaseService(builder.Configuration);
builder.Services.AddRepositoriesAndServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddFluentValidationService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseUserMiddleware();
app.MapGet("user", (ClaimsPrincipal claims) =>
{
    // return claims.Identities;
    var claim = claims.Claims.ToDictionary(c => c.Type, c => c.Value);
    return claim/*["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"]*/;
}).RequireAuthorization();

app.MapControllers();
// app.UseEndpoints(options => options.MapControllers());

app.Run();

/*
 * {
     "exp": "1729766368",
     "iat": "1729765468",
     "auth_time": "1729761663",
     "jti": "38bcfb77-b685-4afc-84ea-c4c409548743",
     "iss": "http://localhost:9090/realms/medipro",
     "aud": "account",
     "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier": "053385d8-01fb-46ff-8ddf-5984f76e1e04",
     "typ": "Bearer",
     "azp": "medipro",
     "session_state": "11a78b0c-77e5-4f6a-969c-a0b282bd1cf9",
     "http://schemas.microsoft.com/claims/authnclassreference": "0",
     "allowed-origins": "http://localhost:5111",
     "realm_access": "{\"roles\":[\"default-roles-medipro\",\"offline_access\",\"uma_authorization\"]}",
     "resource_access": "{\"account\":{\"roles\":[\"manage-account\",\"manage-account-links\",\"view-profile\"]}}",
     "scope": "openid profile email",
     "sid": "11a78b0c-77e5-4f6a-969c-a0b282bd1cf9",
     "email_verified": "true",
     "name": "test test",
     "preferred_username": "otunba@gmail.com",
     "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname": "test",
     "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname": "test",
     "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress": "otunba@gmail.com"
   }
 */
// realm_access.roles realm_access.roles