using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UI/DisableSwitchAnimation")]
public class DisableSwitchAnimation : AbstractSwitchAnimation
{
    public bool resetPosition;

    public override void SwitchStateAnimation(State previousState, State newState)
    {
        LeanTween.cancel(previousState.gameObject);
        LeanTween.cancel(newState.gameObject);

        if (resetPosition)
        {
            previousState.RectTransform.anchoredPosition = Vector2.zero;
            newState.RectTransform.anchoredPosition = Vector2.zero;
        }

        previousState.gameObject.SetActive(false);
        newState.gameObject.SetActive(true);

        OnCompleteHandel();
    }
}
