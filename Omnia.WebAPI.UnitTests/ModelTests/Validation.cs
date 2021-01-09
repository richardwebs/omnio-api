using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Omnia.WebAPI.UnitTests.ModelTests
{
    public interface IValidation
    {
        bool IsModelValid(object model);
        List<ValidationResult> GetValidationResults(object model);
    }

    public class Validation : IValidation
    {
        public List<ValidationResult> GetValidationResults(object model)
        {
            var context = new ValidationContext(model);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, validationResults, true);
            return validationResults;
        }

        public bool IsModelValid(object model)
        {
            var context = new ValidationContext(model);
            var validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(model, context, validationResults, true);
        }
    }
}
