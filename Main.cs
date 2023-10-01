using Godot;
using JiraTempoAppGodot.Services;
using HttpClient = System.Net.Http.HttpClient;

namespace JiraTempoAppGodot;

public partial class Main : Node
{
    public Main()
    {
        var httpClient = new HttpClient();

        ServiceCollection.Add(new JiraService(httpClient));
        ServiceCollection.Add(new TempoService(httpClient));
    }

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