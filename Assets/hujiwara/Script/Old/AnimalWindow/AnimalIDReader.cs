using UnityEngine;
using System.Collections;
using System.IO;

public class AnimalIDReader : MonoBehaviour
{
    int ID;

    string directory;
    string path;

    public GameObject animalIDSetter;
    AnimalIDSetter setter = null;

    AnimalIDWriter writer = null;

    void Start()
    {
        directory = Application.dataPath + "/" + "hujiwara" + "/";
        path = "AnimalIDSave.txt";

        setter = new AnimalIDSetter();
        setter = animalIDSetter.GetComponent<AnimalIDSetter>();

        writer = new AnimalIDWriter();
        writer = gameObject.GetComponent<AnimalIDWriter>();
    }

    public void IDReader()
    {
        if(File.Exists(directory+path))
        {
            using (var stream = new FileStream(directory + path, FileMode.Open))
            {
                using (var reader = new StreamReader(stream))
                {
                    string data = reader.ReadLine();
                    ID = int.Parse(data);

                    Debug.Log("readAnimalID=" + ID);
                }
            }
        }
        else
        {
            writer.IDWriter();
        }

        setter.SetID(ID);
    }
}