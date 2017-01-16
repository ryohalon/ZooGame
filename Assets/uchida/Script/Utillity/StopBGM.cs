using UnityEngine;
using System.Collections;

public class StopBGM : MonoBehaviour {


    public void Stopbgm()
    {
        SoundManager.Instance.StopBGM();
    }
}
