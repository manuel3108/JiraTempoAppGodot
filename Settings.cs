using System.IO;
using Newtonsoft.Json;

namespace JiraTempoAppGodot;

public class Settings
{
    private const string FilePath = "settings.json";
    public JiraSettings Jira { get; set; } = new();
    public TempoSettings Tempo { get; set; } = new();

    public static Settings Load()
    {
        if (!File.Exists(FilePath))
            return new Settings();

        var json = File.ReadAllText(FilePath);
        return JsonConvert.DeserializeObject<Settings>(json);
    }

    public void Save()
    {
        var json = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(FilePath, json);
    }

    public class JiraSettings
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string CloudId { get; set; }
        public string Domain { get; set; }
    }

    public class TempoSettings
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}