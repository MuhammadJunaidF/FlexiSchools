using System.ComponentModel.DataAnnotations;

namespace FlexiSchools.Application.Common.Filters
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ValidateLengthAttribute : ValidationAttribute
    {
        private readonly int _allowedLength;

        public ValidateLengthAttribute(int allowedLength)
        {
            _allowedLength = allowedLength;
        }
        public override bool IsValid(object? value)
        {
            if (value == null) return true;

            var maxResultCount = int.Parse(value.ToString());

            return maxResultCount <= this._allowedLength;
        }
    }
}
