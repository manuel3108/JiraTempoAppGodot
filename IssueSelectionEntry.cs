using System;
using Godot;
using JiraTempoAppGodot.Events;

namespace JiraTempoAppGodot;

public partial class IssueSelectionEntry : HBoxContainer
{
    private int _issueId;
    private string _key;
    private string _title;

    [Export] public NodePath SelectButtonNodePath;

    public event EventHandler<IssueSelectedEventArgs> IssueSelectedEvent;

    public override void _Ready()
    {
        GetNode<Button>(SelectButtonNodePath).Pressed += OnSelected;
    }

    public void SetData(string key, string title, int issueId)
    {
        _key = key;
        _title = title;
        _issueId = issueId;
    }

    private void OnSelected()
    {
        GD.Print(_key, _title);
        if (IssueSelectedEvent != null)
        {
            var eventArgs = new IssueSelectedEventArgs
            {
                Key = _key,
                Title = _title,
                Id = _issueId
            };
            IssueSelectedEvent(this, eventArgs);
        }
    }
}