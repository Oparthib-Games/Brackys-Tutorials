using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public static void SaveGame(ScoreSystem passed_scoreSystem)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "ScoreSave.XXX";

        FileStream created_file = new FileStream(path, FileMode.Create);

        SaveData savedData = new SaveData(passed_scoreSystem);

        binaryFormatter.Serialize(created_file, savedData);
        created_file.Close();
    }

    public static SaveData LoadGame()
    {
        string path = Application.persistentDataPath + "ScoreSave.XXX";

        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            FileStream oppened_file = new FileStream(path, FileMode.Open);

            SaveData retreavedData = binaryFormatter.Deserialize(oppened_file) as SaveData;

            oppened_file.Close();

            return retreavedData;
        }
        else
        {
            Debug.Log("File not found in: " + path);
            return null;
        }
    }
}
