using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveCharacterPreferences : MonoBehaviour
{
    private CharacterPreferences charPrefs;

    public void SaveFile()
    {
        string destination = Application.persistentDataPath + "/charprefs.dat";
        FileStream file;

        file = File.Exists(destination) ? File.OpenWrite(destination) : File.Create(destination);

        Color exampleColor = new Color(1, 1, 1, 1);

        CharacterPreferences charPrefs = new CharacterPreferences(
            1, exampleColor,
            2, exampleColor,
            3, exampleColor,
            4, exampleColor,
            5, exampleColor,
            6, exampleColor,
            7, exampleColor,
            8, exampleColor
        );
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, charPrefs);
        file.Close();

        SceneManager.LoadScene("LoadCharPrefs");
    }
}
