using Godot;
using JiraTempoAppGodot.Services;

namespace JiraTempoAppGodot;

public partial class TempoLoginButton : Button
{
    private readonly TempoService _tempoService = ServiceCollection.Get<TempoService>();

    public override void _Pressed()
    {
        var data = _tempoService.ExecuteLogin();

        var settings = Settings.Load();
        settings.Tempo.AccessToken = data.AccessToken;
        settings.Tempo.RefreshToken = data.RefreshToken;
        settings.Tempo.ExpiresIn = data.ExpiresIn;
        settings.Save();
    }
}