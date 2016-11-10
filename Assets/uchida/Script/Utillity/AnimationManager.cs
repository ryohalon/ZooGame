using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AnimationManager : MonoBehaviour
{
    public struct AnimationData
    {
        public float animationTime;
        public Sprite sprite;
    }
    public List<AnimationData> animationDataList = new List<AnimationData>();

    public bool dataOnly = false;

    public enum AnimationType
    {
        LOOP,
        ONE_TIME,
    }

    [SerializeField]
    public AnimationType animationType = AnimationType.LOOP;
    public AnimationType prevAnimationType;

    public int nowAnimationIndex = 0;
    public Image nowImage = null;
    public float playingTime = 0.0f;
    public bool IsPlay { get; set; }


    void Start()
    {
        IsPlay = true;
        if (GetComponent<Image>() == null)
            this.gameObject.AddComponent<Image>();
        nowImage = GetComponent<Image>();

        if (animationDataList.Count <= 0)
            Debug.Log("animationDataList is empty");

        if (dataOnly)
            return;

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
