using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TimeZoneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas = null;
    [SerializeField]
    private Timer timer = null;
    [SerializeField]
    private Sprite sun = null;
    [SerializeField]
    private Sprite moon = null;
    [SerializeField]
    private Sprite morningScene = null;
    [SerializeField]
    private Sprite nightScene = null;

    void Awake()
    {

    }

    void Start()
    {
        StartCoroutine(UpdateTimeZone());
    }

    IEnumerator UpdateTimeZone()
    {
        while(true)
        {


            yield return null;
        }
    }
}
