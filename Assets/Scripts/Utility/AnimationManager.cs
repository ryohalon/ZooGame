using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AnimationManager : MonoBehaviour
{
    struct AnimationData
    {
        public float animationTime;
        public Sprite sprite;
    }

    [SerializeField]
    private List<AnimationData> animationDataList = new List<AnimationData>();

    private int nowAnimationIndex = 0;
    private Image nowImage = null;
    private float playingTime = 0.0f;
    public bool IsPlay { get; set; }


    void Start()
    {
        IsPlay = true;
        if (GetComponent<Image>() == null)
            this.gameObject.AddComponent<Image>();
        nowImage = GetComponent<Image>();

        if (animationDataList.Count <= 0)
            Debug.Log("animationDataList is empty");

        Init();

        StartCoroutine(UpdateAnimation());
    }

   public IEnumerator UpdateAnimation()
    {
        while(true)
        {
            playingTime += Time.deltaTime;
            if(playingTime >= animationDataList[nowAnimationIndex].animationTime)
            {
                playingTime = 0.0f;
                nowAnimationIndex = (nowAnimationIndex + 1) % animationDataList.Count;
                nowImage.sprite = animationDataList[nowAnimationIndex].sprite;
            }

            yield return null;
        }
    }

    void Init()
    {
        nowAnimationIndex = 0;
        nowImage.sprite = animationDataList[nowAnimationIndex].sprite;
        playingTime = 0.0f;
        IsPlay = true;
    }
}
