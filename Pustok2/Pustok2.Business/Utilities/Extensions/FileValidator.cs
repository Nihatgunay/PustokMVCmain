using Microsoft.AspNetCore.Http;
using Pustok2.Business.Utilities.Enums;

namespace Pustok2.Business.Utilities.Extensions
{
	public static class FileValidator
	{
		
		public static string CreateFileAsync(this IFormFile file, string rootpath, string foldername)
		{
            string filename = file.FileName;

            filename = filename.Length > 64 ? filename.Substring(filename.Length - 64, 64) : filename;

            filename = Guid.NewGuid().ToString() + filename;

            string path = Path.Combine(rootpath, foldername, filename);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return filename;
        }

		
	}
}
