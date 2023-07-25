using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourScreen : MonoBehaviour
{
    [SerializeField] private RectTransform menu;
    [SerializeField] private RectTransform startedGroup;
    [SerializeField] private RectTransform blackBackground;
    [SerializeField] private RectTransform menuQuitGame;

    private void Start()
    {
        LeanTween.moveY(menu,0,1.5f).setDelay(1.5f).setEase(LeanTweenType.easeOutElastic).setOnComplete(ReduceAlpha);
    }

    private void ReduceAlpha()
    {
        LeanTween.alpha(startedGroup, 0f, 1f).setDelay(0.5f);
        startedGroup.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OpenMenuQuit() {
        LeanTween.scale(menuQuitGame, new Vector3(1, 1, 1), 0.5f)
            .setScale(0.5f).setEase(LeanTweenType.easeOutBack);
        LeanTween.alpha(blackBackground, 0.5f, 1f);
    }

    public void RemoveMenuQuit()
    {
        LeanTween.scale(menuQuitGame, new Vector3(0, 0, 0), 0.5f);
        LeanTween.alpha(blackBackground, 0f, 0.5f);
    }
}