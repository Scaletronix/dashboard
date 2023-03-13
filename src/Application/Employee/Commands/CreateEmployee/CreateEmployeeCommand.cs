using MediatR;

namespace Application.Employee.Commands.CreateEmployee;

public sealed class CreateEmployeeCommand : IRequest<Unit>
{
    public string Id { get; set; }

    public string Name { get; set; }
}