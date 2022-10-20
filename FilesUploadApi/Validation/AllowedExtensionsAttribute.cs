using System.ComponentModel.DataAnnotations;

namespace FilesUploadApi.Validation
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _allowedExtensions;

        public AllowedExtensionsAttribute(string[] allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IEnumerable<IFormFile> filesList)
            {
                foreach (var file in filesList)
                {
                    var extension = Path.GetExtension(file.FileName);
                    if (!_allowedExtensions.Contains(extension.ToLower()))
                    {
                        return new ValidationResult("Foto type is not supported");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
