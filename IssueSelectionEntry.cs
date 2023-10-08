using System;
using Godot;

namespace JiraTempoAppGodot;

public partial class IssueSelectionEntry : HBoxContainer
{
    private string _key;
    private string _title;

    [Export] public NodePath SelectButtonNodePath;

    public event EventHandler MyEvent;

    public override void _Ready()
    {
        GetNode<Button>(SelectButtonNodePath).Pressed += OnSelected;
    }

    public void SetData(string key, string title)
    {
        _key = key;
        _title = title;
    }

    private void OnSelected()
    {
        GD.Print(_key, _title);
        if (MyEvent != null) MyEvent(this, EventArgs.Empty);
    }
}