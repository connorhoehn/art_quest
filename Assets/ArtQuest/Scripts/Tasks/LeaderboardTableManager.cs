using UnityEngine;
using TMPro;
using System.Collections.Generic;

[System.Serializable]
public class LeaderboardEntry
{
    public string playerName;
    public Category scoreCategory;
}

public enum Category
{
    Scholar,
    Apprentice,
    Artist,
    Teacher,
    Master
}

public class LeaderboardTableManager : MonoBehaviour
{
    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private Transform tableParent;
    private List<LeaderboardEntry> leaderboardEntries = new List<LeaderboardEntry>();

    public void InsertEntry(string playerName, Category scoreCategory)
    {
        LeaderboardEntry newEntry = new LeaderboardEntry { playerName = playerName, scoreCategory = scoreCategory };
        leaderboardEntries.Add(newEntry);
        AddRowToTable(newEntry);
    }

    private void AddRowToTable(LeaderboardEntry entry)
    {
        GameObject newRow = Instantiate(rowPrefab, tableParent);
        TextMeshProUGUI textComponent = newRow.GetComponentInChildren<TextMeshProUGUI>();
        textComponent.text = $"    {entry.playerName} - {entry.scoreCategory.ToString().ToUpper()}";
    }

    private void Start()
    {
        // Example data
        List<string> samplePlayers = new List<string>
        {
            "Giovanni Rossi",
            "Maria Luisa Bianchi",
            "Luca Alessandro Verdi",
            "Francesca D'Angelo",
            "Antonio Carlo Esposito",
            "Elena Sofia Ricci",
            "Marco Antonio Ferrari",
            "Chiara Benedetta Romano",
            "Stefano Lorenzo Galli",
            "Valentina Aurora Conti"
        };

        Category[] categories = (Category[])System.Enum.GetValues(typeof(Category));
        foreach (var playerName in samplePlayers)
        {
            Category randomCategory = categories[Random.Range(0, categories.Length)];
            InsertEntry(playerName, randomCategory);
        }
    }
}
