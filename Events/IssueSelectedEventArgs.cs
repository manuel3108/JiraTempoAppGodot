using System;

namespace JiraTempoAppGodot.Events;

public class IssueSelectedEventArgs : EventArgs
{
    public string Key { get; set; }
    public string Title { get; set; }
}