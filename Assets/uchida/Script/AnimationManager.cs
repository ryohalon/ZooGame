using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AnimationManager : MonoBehaviour
{
    [System.Serializable]
    struct AnimationData
    {
        public float animationTime;
        public Sprite sprite;
    }

    [SerializeField]
    private List<AnimationData> animationDataList = new List<AnimationData>();

    enum AnimationType
    {
        LOOP,
        ONE_TIME,
    }

    [SerializeField]
    private AnimationType animationType = AnimationType.LOOP;
    private AnimationType prevAnimationType;

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

    private IEnumerator UpdateAnimation()
    {
        while (true)
        {
            if (animationDataList.Count > 0)
            {
                if (IsPlay)
                {
                    if (animationType != prevAnimationType)
                        Init();

                    LoopAnimation();

                    switch (animationType)
                    {
                        case AnimationType.LOOP:
                            break;

                        case AnimationType.ONE_TIME:
                            OneTimeAnimation();
                            break;
                        default:
                            break;
                    }
                }

                prevAnimationType = animationType;
            }

            yield return null;
        }
    }

    public void Init()
    {
        if (animationDataList.Count <= 0)
            return;

        nowAnimationIndex = 0;
        nowImage.sprite = animationDataList[nowAnimationIndex].sprite;
        playingTime = 0.0f;
        IsPlay = true;
        prevAnimationType = animationType;
    }

    private void LoopAnimation()
    {
        playingTime += Time.deltaTime;
        if (playingTime >= animationDataList[nowAnimationIndex].animationTime)
            return;

        playingTime = 0.0f;
        nowAnimationIndex = (nowAnimationIndex + 1) % animationDataList.Count;
        nowImage.sprite = animationDataList[nowAnimationIndex].sprite;
    }

    private void OneTimeAnimation()
    {
        if (playingTime >= animationDataList[nowAnimationIndex].animationTime)
            return;

        IsPlay = false;
    }
}
