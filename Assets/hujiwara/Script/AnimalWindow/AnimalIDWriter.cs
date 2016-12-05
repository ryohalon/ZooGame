using UnityEngine;
using System.Collections;
using System.IO;

public class AnimalIDWriter : MonoBehaviour
{
    public int ID;

    string directory;
    string path;

    void Awake()
    {
        directory = Application.persistentDataPath + "/";
        path = "AnimalIDSave.txt";
    }

    public void IDWriter()
    {
        if(File.Exists(directory+path))
        {
            using (var stream = new FileStream(directory + path, FileMode.Open))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(ID);
                }
            }
        }
        else
        {
            using (var stream = new FileStream(directory + path, FileMode.Create))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(ID);
                }
            }
        }
    }
}