using Godot;

public partial class Main : CenterContainer
{
    public const string JIRA_CLIENT_ID = "hm9gBmGiHZWc8o2jJL0sstAHmqIaev7C";

    public const string JIRA_CLIENT_SECRET =
        "ATOARcjjOi5Hqj1W5wUl2hP3a3OglOVxUcuaDSEUnyj2GZFxfKfvfMvAdSW9pM8R5iWo6A1A713E";

    public const string JIRA_CLOUD_ID = "a2287409-a192-4405-be5b-b30a3c375bfc";
    public const string JIRA_DOMAIN = "manuel-dev.atlassian.net";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
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