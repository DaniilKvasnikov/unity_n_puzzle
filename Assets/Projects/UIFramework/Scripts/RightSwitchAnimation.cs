using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UI/RightSwitchAnimation")]
public class RightSwitchAnimation : AbstractSwitchAnimation
{
    public float time;
    public LeanTweenType tweenType = LeanTweenType.easeInElastic;

    public override void SwitchStateAnimation(State previousState, State newState)
    {
        var previousRect = previousState.RectTransform;
        previousRect.gameObject.SetActive(true);
        previousRect.anchoredPosition = Vector2.zero;

        var newRect = newState.RectTransform;
        newState.gameObject.SetActive(true);

        var rectWidth = newRect.rect.width;
        var rightBorder = new Vector2(rectWidth, 0f);
        newRect.anchoredPosition = rightBorder;

        LeanTween.moveLocalX(previousRect.gameObject, -rectWidth, time).setEase(tweenType);
        LeanTween.moveLocalX(newRect.gameObject, 0f, time).setEase(tweenType).setOnComplete(OnCompleteHandel);
    }
}
