using Godot;

public partial class Main : CenterContainer
{
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        // GD.Print(Engine.GetFramesDrawn());
    }

    public override void _Notification(int what)
    {
        if (what == MainLoop.NotificationApplicationFocusOut) GD.Print("Save stuff.");
    }
}