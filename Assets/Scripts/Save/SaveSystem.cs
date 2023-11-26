using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveProgress(bool watched){
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/data.save";

        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData save = new SaveData(watched);

        formatter.Serialize(stream, save);

        stream.Close();
    }

    public static bool LoadProgress(){
        string path = Application.persistentDataPath + "/data.save";

        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            string w = formatter.Deserialize(stream) as string;

            bool watched = false;

            if (w != null){
                watched = bool.Parse(w);
            }
            
            stream.Close();

            return watched;
        }
        else {
            Debug.Log("Save File not found in: " + path);
            return false;
        }
    }
}
