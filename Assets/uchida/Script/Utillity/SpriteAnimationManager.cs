using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpriteAnimationManager : MonoBehaviour
{
    public List<AnimationManager.AnimationData> animationDataList = new List<AnimationManager.AnimationData>();

    private SpriteRenderer nowSprite = null;

    [SerializeField]
    public AnimationManager.AnimationType animationType = AnimationManager.AnimationType.LOOP;
    public AnimationManager.AnimationType prevAnimationType;

    public int nowAnimationIndex = 0;
    public float playingTime = 0.0f;
    public bool IsPlay { get; set; }
    public bool dataOnly = false;

    void Start()
    {
        IsPlay = true;
        nowSprite = GetComponent<SpriteRenderer>();

        if (dataOnly)
            return;

        StartCoroutine(UpdateAnimation());
    }

    void Init()
    {
        if (animationDataList.Count <= 0)
            return;

        nowAnimationIndex = 0;
        nowSprite.sprite = animationDataList[nowAnimationIndex].sprite;
        playingTime = 0.0f;
        IsPlay = true;
        prevAnimationType = animationType;
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
                        case AnimationManager.AnimationType.LOOP:
                            break;

                        case AnimationManager.AnimationType.ONE_TIME:
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

    private void LoopAnimation()
    {
        playingTime += Time.deltaTime;
        if (playingTime >= animationDataList[nowAnimationIndex].animationTime)
            return;

        playingTime = 0.0f;
        nowAnimationIndex = (nowAnimationIndex + 1) % animationDataList.Count;
        nowSprite.sprite = animationDataList[nowAnimationIndex].sprite;
    }

    private void OneTimeAnimation()
    {
        if (playingTime >= animationDataList[nowAnimationIndex].animationTime)
            return;

        IsPlay = false;
    }
}
