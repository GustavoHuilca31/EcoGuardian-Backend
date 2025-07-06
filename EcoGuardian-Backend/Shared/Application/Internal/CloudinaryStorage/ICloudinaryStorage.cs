using CloudinaryDotNet.Actions;

namespace EcoGuardian_Backend.Shared.Application.Internal.CloudinaryStorage;

public interface ICloudinaryStorage
{
    Task UploadImage(ImageUploadParams imageUploadParams);
    Task<string?> GetImage(string publicId);
}