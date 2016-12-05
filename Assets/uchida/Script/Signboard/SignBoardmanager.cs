using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SignBoardmanager : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;

    private void LoadStatus()
    {
        // 仮置き
        var zooName = this.gameObject.transform.FindChild("ZooName").gameObject;
        zooName.GetComponent<Text>().text = "***" + "動物園";
    }


    void Start()
    {
        if (player == null)
            Debug.Log("player is empty!");

        LoadStatus();

        StartCoroutine(UpdateSignBoard());
    }

    private IEnumerator UpdateSignBoard()
    {
        while (true)
        {
            var playerStatus = player.GetComponent<PlayerStatusManager>();
            int oneDayVisitors = (int)playerStatus.OneDayVisitors;

            var visitorsNum = this.gameObject.transform.FindChild("VisitorsNum").gameObject;
            var visiNumText = visitorsNum.GetComponent<Text>();
            if (oneDayVisitors < 1000)
                visiNumText.text = oneDayVisitors + "人";
            else if (oneDayVisitors >= 10000 && oneDayVisitors < 100000000)
                visiNumText.text = (oneDayVisitors / 10000) + "万"
                    + (oneDayVisitors - (oneDayVisitors / 10000 * 10000)) + "人";
            else
                visiNumText.text = (oneDayVisitors / 100000000) + "億"
                    + ((oneDayVisitors / 10000) - (oneDayVisitors / 100000000 * 100000000)) + "万"
                    + (oneDayVisitors - (oneDayVisitors / 100000000 * 100000000) - (oneDayVisitors / 10000 * 10000)) + "人";

            yield return null;
        }
    }
}
