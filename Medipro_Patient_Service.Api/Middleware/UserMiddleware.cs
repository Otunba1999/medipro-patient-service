using System.Text.Json;
using medipro_patient_service.Application.DTO;

namespace medipro_patient_service.Api.Middleware;

public class UserMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<UserMiddleware> _logger;

    public UserMiddleware(RequestDelegate next, ILogger<UserMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            var userId = context.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                ?.Value;
            var name = context.User.FindFirst("name")?.Value;
            var email = context.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")
                ?.Value;

            // Deserialize resource_access from the claims
            var resourceAccessJson = context.User.FindFirst("realm_access")?.Value;
            RealmAccess access = null;
            if (!string.IsNullOrEmpty(resourceAccessJson))
            {
                try
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    access = JsonSerializer.Deserialize<RealmAccess>(resourceAccessJson, options)!;
                    if (access == null || access.Roles == null)
                    {
                        _logger.LogWarning("Deserialized access is null or account is null.");
                    }
                    else
                    {
                        _logger.LogInformation("Deserialized Access: {Access}", JsonSerializer.Serialize(access));
                    }
                }
                catch (JsonException ex)
                {
                    _logger.LogError(ex, "Failed to deserialize resource_access JSON: {Json}", resourceAccessJson);
                }
            }
            

            // Store user details in HttpContext.Items
            context.Items["UserDetails"] = new UserDetail(userId, name, email, null);

            // Log the user details for debugging
            _logger.LogInformation($"User ID: {userId}, Name: {name}, Email: {email}");
        }

        // Call the next middleware in the pipeline
        await _next(context);
    }
}



public static class UserMiddlewareExtension
{
    public static IApplicationBuilder UseUserMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<UserMiddleware>();
    }
}

// public record UserDetail(
//     string UserId,
//     string Email,
//     string Name,
//     RealmAccess Access);
//
// public record Role(List<string> Roles);
//
// public record RealmAccess(Role Role);