using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using JiraTempoAppGodot.ApiModels.Tempo;
using JiraTempoAppGodot.Services;

namespace JiraTempoAppGodot;

public partial class Worklog : PanelContainer
{
    private readonly JiraService _jiraService = ServiceCollection.Get<JiraService>();
    private readonly TempoService _tempoService = ServiceCollection.Get<TempoService>();
    private int _selectedIssueId;
    [Export] public NodePath AccountOptionButtonNodePath;
    [Export] public NodePath AddTimeEntryButtonNodePath;
    [Export] public NodePath BookWorklogButtonNodePath;
    [Export] public NodePath DescriptionTextEditNodePath;
    [Export] public NodePath TimeEntriesContainerNodePath;
    [Export] public NodePath TitleLineEditNodePath;

    public override void _Ready()
    {
        var addTimeEntryButton = GetNode<Button>(AddTimeEntryButtonNodePath);
        addTimeEntryButton.Pressed += AddNewTimeEntryRow;

        var bookWorklogButton = GetNode<Button>(BookWorklogButtonNodePath);
        bookWorklogButton.Pressed += BookWorklog;
    }

    private void BookWorklog()
    {
        var accountNode = GetNode<OptionButton>(AccountOptionButtonNodePath);
        var descriptionNode = GetNode<TextEdit>(DescriptionTextEditNodePath);

        var accountResults = _tempoService.GetAccounts();
        var selectedAccountId = accountNode.GetItemId(accountNode.Selected);
        var selectedAccount = accountResults.Results.First(x => x.Id == selectedAccountId);

        var profile = _jiraService.GetProfile();

        var createWorklogRequest = new CreateWorklogRequest
        {
            Description = descriptionNode.Text,
            IssueId = _selectedIssueId,
            BillableSeconds = 300,
            TimeSpentSeconds = 300,
            StartDate = DateTime.Today.ToString("yyyy-MM-dd"),
            StartTime = "08:00:00",
            AuthorAccountId = profile.AccountId,
            Attributes = new List<CreateWorklogRequest.Attribute>
            {
                new() { Key = "_Account_", Value = selectedAccount.Key }
            }
        };
        _tempoService.CreateWorklog(createWorklogRequest);

        GD.Print("Entry booked!");
    }

    private void AddNewTimeEntryRow()
    {
        var container = GetNode<Container>(TimeEntriesContainerNodePath);
        var scene = GD.Load<PackedScene>("res://TimeEntry.tscn");
        var timeEntry = scene.Instantiate();
        container.AddChild(timeEntry);
    }

    public void IssueSelected(int issueId)
    {
        _selectedIssueId = issueId;
        var accountResults = _tempoService.GetAccounts();
        var issueMeta = _jiraService.GetIssueMeta(_selectedIssueId);
        var tempoFieldName = _jiraService.GetTempoFieldName(issueMeta);
        var issueDetails = _jiraService.GetIssueDetails(_selectedIssueId);
        var defaultAccount = _jiraService.GetDefaultAccount(issueDetails, tempoFieldName);

        var accountOptionButton = GetNode<OptionButton>(AccountOptionButtonNodePath);

        var itemCount = accountOptionButton.ItemCount;
        for (var j = 1; j < itemCount; j++)

        {
            // keep first option "please select", remove everything else
            // as the indexes are reduced even during the the loop, it is enough
            // to always remove from index 1
            accountOptionButton.RemoveItem(1);
        }

        var i = 1;
        accountOptionButton.Selected = 0;
        foreach (var account in accountResults.Results)
        {
            accountOptionButton.AddItem(account.Name, account.Id);

            if (account.Name == defaultAccount) accountOptionButton.Selected = i;

            i++;
        }
    }
}