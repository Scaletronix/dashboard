using FluentValidation;

namespace Application.Employee.Commands.CreateEmployee;

public sealed class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
	public CreateEmployeeCommandValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty()
			.MinimumLength(8)
			.MaximumLength(8);

		RuleFor(x => x.Name)
			.NotEmpty();
	}
}