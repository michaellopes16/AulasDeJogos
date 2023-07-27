using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourMenuGame : MonoBehaviour
{
    [SerializeField] private RectTransform blackBackground;
    [SerializeField] private RectTransform menuQuitGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenMenuQuit()
    {
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
