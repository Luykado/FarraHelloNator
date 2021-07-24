using System;
using FluentValidation;
using Booking.Web.ViewModels.Record.Requests;
using Booking.Core.Enums;


namespace Booking.Web.Extensions.Validators
{
    public class CreateRecordValidator : AbstractValidator<RequestRecordCreate>
    {
        public CreateRecordValidator()
        {
            //NotNull() will take both true and false as valid properties.
            RuleFor(record => record.Deleted)
                .NotNull().WithMessage("({PropertyName}) is required.");

            RuleFor(record => record.Status)
                .IsInEnum().WithMessage("({PropertyName}) is required.");

            RuleFor(record => record.CreatedDate)
                .NotNull().WithMessage("({PropertyName}) is required.");

            RuleFor(record => record.LastModifiedDate)
                .NotNull().WithMessage("({PropertyName}) is required.");

            RuleFor(record => record)
                .Must(record => record.LastModifiedDate >= record.CreatedDate)
                .WithMessage("({PropertyName}) must be more then Created Date.");

            RuleFor(record => record.Date)
                .NotEmpty().WithMessage("({PropertyName}) is required.")
                .Must(date => date >= DateTime.Now).WithMessage("({PropertyName}) must be more then now");
        }
    }
}
