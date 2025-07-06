using CloudinaryDotNet.Actions;
using EcoGuardian_Backend.Shared.Application.Internal.CloudinaryStorage;
using EcoGuardian_Backend.Shared.Infrastructure.Cloudinary.Helper;

namespace EcoGuardian_Backend.Shared.Infrastructure.Cloudinary;

public class CloudinaryStorage(IConfiguration configuration, CloudinaryHelper helper) : ICloudinaryStorage
{
    public async Task UploadImage(ImageUploadParams imageUploadParams)
    {
        await helper.Cloudinary.UploadAsync(imageUploadParams);
    }

    public async Task<string?> GetImage(string publicId)
    {
        var resource = await helper.Cloudinary.GetResourceAsync(new GetResourceParams(publicId));
        return resource?.SecureUrl;
    }
}