using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimalImageSetter : MonoBehaviour
{
    public GameObject animalIDSetter;
    AnimalIDSetter setter;

    int ID;

    public Texture peacock;
    public Texture monkey;
    public Texture giraffe;
    public Texture elephant;
    public Texture panda;
    public Texture tiger;
    public Texture hawk;
    public Texture blackPanther;

    Image img;

    void Start()
    {
        setter = new AnimalIDSetter();
        setter = animalIDSetter.GetComponent<AnimalIDSetter>();

        img = gameObject.GetComponent<Image>();

        ImageUpdater();
    }

    public void ImageUpdater()
    {
        ID = setter.GetID();

        if(ID == 2)
        {
            img.material.mainTexture = peacock;
        }
        else if(ID == 3)
        {
            img.material.mainTexture = monkey;
        }
        else if(ID == 4)
        {
            img.material.mainTexture = giraffe;
        }
        else if(ID == 5)
        {
            img.material.mainTexture = blackPanther;
        }
        else if(ID == 6)
        {
            img.material.mainTexture = panda;
        }
        else if(ID == 7)
        {
            img.material.mainTexture = hawk;
        }
        else if(ID == 8)
        {
            img.material.mainTexture = tiger;
        }
        else if(ID == 9)
        {
            img.material.mainTexture = elephant;
        }
    }
}