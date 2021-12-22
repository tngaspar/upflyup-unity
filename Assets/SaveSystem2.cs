using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem2
{
    public static void SaveChar(CharClass charclass)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/char.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        CharData data = new CharData(charclass);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CharData LoadChar()
    {
        string path = Application.persistentDataPath + "/char.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CharData data = formatter.Deserialize(stream) as CharData;

            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

    public static void DeleteFile()
    {
        string path = Application.persistentDataPath + "/char.save";
        try
        {
            File.Delete(path);
        }
        catch
        {
            Debug.Log("Error deleting");
        }

    }

}
