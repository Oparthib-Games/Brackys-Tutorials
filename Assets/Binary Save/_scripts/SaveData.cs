using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int HighScore;

    public SaveData(ScoreSystem score_system) // CONSTRUCTOR
    {
        HighScore = score_system.highScore;
    }
}
