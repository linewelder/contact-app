using System.ComponentModel.DataAnnotations;
using DataLayer.Data;
using DataLayer.Model;
using InfrastructureLayer.Email;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.CampaignServices.Dtos;

namespace ServiceLayer.CampaignServices.Concrete;

/// <summary>
/// Service responsible for creating a new marketing campaign
/// </summary>
public class NewCampaignService(AppDbContext context, ISendEmailService sendEmailService) : INewCampaignService
{
    public async Task<List<string>> GetAvailableGroups() =>
        await context.ContactGroups.Select(group => group.Name).ToListAsync();

    public async Task<int> GetContactCountInGroup(string groupName) =>
        await context.ContactGroups
            .Where(group => group.Name == groupName)
            .Select(group => group.Contacts.Count)
            .FirstOrDefaultAsync();

    public IEnumerable<ValidationResult> Errors { get; private set; } = [];

    public async Task<Campaign?> BroadcastCampaign(NewCampaignDto dto)
    {
        var targetGroup = await FindWithContactsByName(dto.TargetGroup);
        if (targetGroup is null)
        {
            Errors = [new ValidationResult("Target group not found", [nameof(dto.TargetGroup)])];
            return null;
        }

        var campaign = new Campaign
        {
            Subject = dto.Subject,
            Contents = dto.Contents,
            Date = DateTime.UtcNow,
            TargetGroup = targetGroup,
            NumberContactsTargeted = targetGroup.Contacts.Count,
        };
        context.Add(campaign);

        Errors = await context.SaveChangesWithValidationAsync();
        await SendEmailToContacts(targetGroup.Contacts, dto);

        return Errors.Any() ? null : campaign;
    }

    private async Task<ContactGroup?> FindWithContactsByName(string groupName) =>
        await context.ContactGroups
            .Include(group => group.Contacts)
            .SingleOrDefaultAsync(group => group.Name == groupName);

    private async Task SendEmailToContacts(IEnumerable<Contact> contacts, NewCampaignDto dto)
    {
        foreach (var contact in contacts)
        {
            await sendEmailService.Send(contact.MailAddress, dto.Subject, dto.Contents);
        }
    }
}
