using System;
using Godot;

namespace JiraTempoAppGodot;

public partial class TimeEntryNowButton : Button
{
    [Export] public NodePath InputFieldNodePath;

    public override void _Pressed()
    {
        var lineEdit = GetNode<LineEdit>(InputFieldNodePath);
        lineEdit.Text = DateTime.Now.ToString("HH:mm");
    }
}