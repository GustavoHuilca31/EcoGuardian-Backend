using EcoGuardian_Backend.Shared.Infrastructure.Cloudinary.Helper;

namespace EcoGuardian_Backend.Shared.Application.Internal.CloudinaryStorage.Configuration;
public static class SetUpCloudinary
{
    public static IServiceCollection SetUpStorageService(this IServiceCollection services)
    {
        services.AddScoped<CloudinaryHelper>();
       return services;
    }
}