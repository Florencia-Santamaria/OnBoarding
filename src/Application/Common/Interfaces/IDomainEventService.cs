using onboardingback.Domain.Common;
using System.Threading.Tasks;

namespace onboardingback.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
