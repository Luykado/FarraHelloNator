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
                .NotNull().WithMessage("is required.");

            RuleFor(record => record.Status)
                .IsInEnum().WithMessage("is required.");

            RuleFor(record => record.CreatedDate)
                .NotNull().WithMessage("is required.");

            RuleFor(record => record.LastModifiedDate)
                .NotNull().WithMessage("is required.");

            RuleFor(record => record.Date)
                .NotEmpty().WithMessage("is required.")
                .Must(date => date >= DateTime.Now).WithMessage("must be more then now.");
        }
    }
}
