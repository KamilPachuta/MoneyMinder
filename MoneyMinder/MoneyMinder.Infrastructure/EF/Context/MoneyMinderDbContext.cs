using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Domain.SavingsAccounts;
using MoneyMinder.Domain.Shared.Abstractions;
using MoneyMinder.Domain.Shared.Primitives;

namespace MoneyMinder.Infrastructure.EF.Context;

internal sealed class MoneyMinderDbContext : DbContext
{
    private readonly IPublisher _publisher;
    
    public DbSet<Account> Accounts { get; set; }
    public DbSet<CurrencyAccount> CurrencyAccounts { get; set; }
    public DbSet<SavingsAccount> SavingsAccounts { get; set; }

    public MoneyMinderDbContext(DbContextOptions<MoneyMinderDbContext> options, IPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("MoneyMinder");

        modelBuilder.AddEFConfig();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        
        await PublishDomainEventsAsync(cancellationToken);
        
        return result;
    }

    private async Task PublishDomainEventsAsync(CancellationToken cancellationToken)
    {
        var domainEvent = ChangeTracker
            .Entries<AggregateRoot>()
            .Select(a => a.Entity)
            .SelectMany(a =>
            {
                List<IDomainEvent> domainEvents = a.DomainEvents.ToList();

                a.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();
        
        foreach (var @event in domainEvent)
        {
            await _publisher.Publish(@event, cancellationToken);
        }
    }
}