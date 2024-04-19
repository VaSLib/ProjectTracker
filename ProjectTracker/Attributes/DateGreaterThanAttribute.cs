using System;
using System.ComponentModel.DataAnnotations;


// Attribute to validate if one date property is greater than another date property.
[AttributeUsage(AttributeTargets.Property)]
public class DateGreaterThanAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;

    public DateGreaterThanAttribute(string comparisonProperty)
    {
        _comparisonProperty = comparisonProperty;
    }

    // Overrides the IsValid method to perform custom validation logic.
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var propertyInfo = validationContext.ObjectType.GetProperty(_comparisonProperty);
        if (propertyInfo == null)
        {
            return new ValidationResult($"Unknown property {_comparisonProperty}");
        }

        var comparisonValue = (DateTime?)propertyInfo.GetValue(validationContext.ObjectInstance);
        var currentValue = (DateTime?)value;

        if (currentValue <= comparisonValue)
        {
            return new ValidationResult($"The {_comparisonProperty} must be less than {_comparisonProperty}");
        }

        return ValidationResult.Success;
    }
}
