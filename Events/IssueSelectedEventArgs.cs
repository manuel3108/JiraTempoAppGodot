using System;

namespace JiraTempoAppGodot.Events;

public class IssueSelectedEventArgs : EventArgs
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Title { get; set; }
}