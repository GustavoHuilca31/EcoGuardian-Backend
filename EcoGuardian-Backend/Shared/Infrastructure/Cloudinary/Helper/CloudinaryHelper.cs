namespace EcoGuardian_Backend.Shared.Infrastructure.Cloudinary.Helper;
using CloudinaryDotNet;
public class CloudinaryHelper
{
     public readonly Cloudinary Cloudinary;
    
    public CloudinaryHelper(IConfiguration configuration)
    {
        Cloudinary = new Cloudinary(configuration["CLOUDINARY_URL"]);
    }
}