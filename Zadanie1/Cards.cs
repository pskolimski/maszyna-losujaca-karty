using System.IO;
using System.Windows;
using Newtonsoft.Json;

namespace Zadanie1;

public static class Cards
{
    public static List<string> CardsList { get; set; } = new List<string>();

    static Cards()
    {
        LoadFromDirectory();
    }

    public static void LoadFromJson()
    {
        string jsonPath = "cards.json";

        if (File.Exists(jsonPath))
        {
            string json = File.ReadAllText(jsonPath);
            CardsList = JsonConvert.DeserializeObject<List<string>>(json);
        }
        else
        {
            MessageBox.Show("File not found");
        }
    }

    public static void LoadFromDirectory()
    {
        string directoryPath = "images/cards";

        if (Directory.Exists(directoryPath))
        {
            CardsList = Directory.GetFiles(directoryPath, "*.png").ToList();
        }
        else
        {
            MessageBox.Show("Directory not found");
        }
    }
}