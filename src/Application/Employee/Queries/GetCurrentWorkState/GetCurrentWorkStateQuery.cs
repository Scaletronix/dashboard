using Domain.Employee.Enums;
using MediatR;

namespace Application.Employee.Queries.GetCurrentWorkState;

public sealed class GetCurrentWorkStateQuery : IRequest<WorkStateEnum>
{
    public string Id { get; set; }
}