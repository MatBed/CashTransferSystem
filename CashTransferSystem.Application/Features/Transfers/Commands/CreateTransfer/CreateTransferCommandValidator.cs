using CashTransferSystem.Core.Enums;
using FluentValidation;

namespace CashTransferSystem.Application.Features.Transfers.Commands.CreateTransfer;

public class CreateTransferCommandValidator : AbstractValidator<CreateTransferCommand>
{
    private const int PESEL_LENGTH = 11;
    private const int NIP_LENGTH = 10;
    private const int REGON_LENGTH = 9;

    public CreateTransferCommandValidator()
    {
        RuleFor(x => x.SenderFirstName)
            .NotNull().WithMessage("Sender first name is required.")
            .NotEmpty().WithMessage("Sender first name is required.");

        RuleFor(x => x.SenderLastName)
            .NotNull().WithMessage("Sender last name is required.")
            .NotEmpty().WithMessage("Sender last name is required.");

        RuleFor(x => x.SenderPesel)
            .NotNull().WithMessage("Sender pesel is required.")
            .NotEmpty().WithMessage("Sender pesel is required.")
            .Length(PESEL_LENGTH).WithMessage($"Sender pesel must have {PESEL_LENGTH} digits.")
            .Matches(@"^\d+$").WithMessage("Sender pesel must contain only digits.");

        RuleFor(x => x.ReceiverAccountNumber)
            .NotNull().WithMessage("Receiver account number is required.")
            .NotEmpty().WithMessage("Receiver account number is required.")
            .Length(26).WithMessage("Receiver account number must have exactly 26 digits.")
            .Matches(@"^\d+$").WithMessage("Receiver account number must contain only digits.");

        RuleFor(x => x.ReceiverName)
            .NotNull().WithMessage("Receiver name is required.")
            .NotEmpty().WithMessage("Receiver name is required.");

        RuleFor(x => x.ReceiverNip)
            .NotNull().WithMessage("Receiver NIP is required.")
            .NotEmpty().WithMessage("Receiver NIP is required.")
            .Length(NIP_LENGTH).WithMessage($"Receiver NIP must have {NIP_LENGTH} digits.")
            .Matches(@"^\d+$").WithMessage("Receiver NIP must contain only digits.");

        RuleFor(x => x.ReceiverRegon)
            .NotNull().WithMessage("Receiver REGON is required.")
            .NotEmpty().WithMessage("Receiver REGON is required.")
            .Length(REGON_LENGTH).WithMessage($"Receiver REGON must have {REGON_LENGTH} digits.")
            .Matches(@"^\d+$").WithMessage("Receiver REGON must contain only digits.");

        RuleFor(x => x.ReceiverAddress)
            .NotNull().WithMessage("Receiver address is required.")
            .NotEmpty().WithMessage("Receiver address is required.");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than zero.");

        RuleFor(x => x.TransferTypeId)
            .Must(BeAValidEnumValue)
            .WithMessage("Transfer type must be a valid value from the enumeration.");
    }

    private bool BeAValidEnumValue(int transferTypeId)
    {
        return Enum.IsDefined(typeof(TransferType), transferTypeId);
    }
}
