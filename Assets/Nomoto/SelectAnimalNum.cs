using UnityEngine;
using System.Collections;

public class SelectAnimalNum : MonoBehaviour
{
    static GameObject _instance = null;

    private int selectNum;

    public int SelectNum
    {
        set { selectNum = value; }
        get { return selectNum; }
    }

    void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
