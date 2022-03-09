using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadCharacterPreferences : MonoBehaviour
{
    private CharacterPreferences charPrefs;

    // Start is called before the first frame update
    void Start()
    {
        LoadFile();
    }

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/charprefs.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        charPrefs = (CharacterPreferences)bf.Deserialize(file);
        file.Close();

        Debug.Log(charPrefs.hairModel);
        Debug.Log(charPrefs.HairColor());
    }
}
