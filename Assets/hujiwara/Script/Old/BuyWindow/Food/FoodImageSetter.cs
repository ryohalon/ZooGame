using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FoodImageSetter : MonoBehaviour
{
    public GameObject foodIDSetter;
    FoodIDSetter setter;

    int ID;

    public Texture meet1;
    public Texture meet2;
    public Texture meet3;
    public Texture vegetables1;
    public Texture vegetables2;
    public Texture vegetables3;

    Image img;

    void Start()
    {
        setter = new FoodIDSetter();
        setter = foodIDSetter.GetComponent<FoodIDSetter>();

        img = gameObject.GetComponent<Image>();

        ImageUpdater();
    }

    public void ImageUpdater()
    {
        ID = setter.GetID();

        if(ID == 0)
        {
            img.material.mainTexture = meet1;
        }
        else if(ID == 1)
        {
            img.material.mainTexture = meet2;
        }
        else if(ID == 2)
        {
            img.material.mainTexture = meet3;
        }
        else if(ID == 3)
        {
            img.material.mainTexture = vegetables1;
        }
        else if(ID == 4)
        {
            img.material.mainTexture = vegetables2;
        }
        else if(ID == 5)
        {
            img.material.mainTexture = vegetables3;
        }
    }
}