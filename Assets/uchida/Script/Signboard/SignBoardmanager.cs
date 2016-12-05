using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SignBoardmanager : MonoBehaviour
{
    [SerializeField]
    private PlayerStatusManager playerStatus = null;

    void Start()
    {
        StartCoroutine(UpdateSignBoard());
    }

    private IEnumerator UpdateSignBoard()
    {
        while (true)
        {
            int oneDayVisitors = (int)playerStatus.OneDayVisitors;

            var visiNumText = GetComponent<Text>();
            if (oneDayVisitors < 1000)
                visiNumText.text = oneDayVisitors.ToString();
            else if (oneDayVisitors >= 10000 && oneDayVisitors < 100000000)
                visiNumText.text = (oneDayVisitors / 10000) + "万"
                    + (oneDayVisitors - (oneDayVisitors / 10000 * 10000));
            else
                visiNumText.text = (oneDayVisitors / 100000000) + "億"
                    + ((oneDayVisitors / 10000) - (oneDayVisitors / 100000000 * 100000000)) + "万"
                    + (oneDayVisitors - (oneDayVisitors / 100000000 * 100000000) - (oneDayVisitors / 10000 * 10000));

            yield return null;
        }
    }
}
