using Godot;

namespace JiraTempoAppGodot;

public partial class OpenSettingsButton : Button
{
    private PanelContainer _settingsNode;
    [Export] public NodePath SettingsNodePath;

    public override void _Ready()
    {
        _settingsNode = GetNode<PanelContainer>(SettingsNodePath);
    }

    public override void _Pressed()
    {
        _settingsNode.Show();
    }
}