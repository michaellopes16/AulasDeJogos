using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BehaviourScreen : MonoBehaviour
{
    [SerializeField] private RectTransform menu;
    [SerializeField] private RectTransform startedGroup;
    [SerializeField] private RectTransform blackBackground;
    [SerializeField] private RectTransform menuQuitGame;
    [SerializeField] private RectTransform menuCredits;
    [SerializeField] private GameObject player;

    private void Start()
    {
        LeanTween.moveY(menu, 0, 1.5f).setDelay(1.5f).setEase(LeanTweenType.easeOutElastic).setOnComplete(ReduceAlpha);
    }
    public void CloseMainMenu()
    {
        LeanTween.scale(menu, new Vector3(0, 0, 0), 0.5f)
                    .setScale(0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(OpenMenuCredits);

    }
    public void OpenMenuCredits()
    {
        LeanTween.scale(menuCredits, new Vector3(1, 1, 1), 0.5f)
    .setScale(0.5f).setEase(LeanTweenType.easeOutBack);
    }
    public void BackMainScreen()
    {
        LeanTween.scale(menuCredits, new Vector3(0, 0, 0), 0.5f)
            .setScale(0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(OpenMainMenu);
    }
    public void OpenMainMenu()
    {
        LeanTween.scale(menu, new Vector3(1, 1, 1), 0.5f)
                    .setScale(0.5f).setEase(LeanTweenType.easeOutBack);
    }
    private void ReduceAlpha()
    {
        LeanTween.alpha(startedGroup, 0f, 1f).setDelay(0.5f);
        startedGroup.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void StartNewScene()
    {
        LeanTween.alpha(player, 0f, 1f).setDelay(0.5f);
        LeanTween.alpha(blackBackground, 1f, 1f).setDelay(0.5f).setOnComplete(CallNewScene);
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
    public void CallNewScene()
    {
        SceneManager.LoadScene("PixelScene");
    }
    public void CloseApplication()
    {
#if UNITY_EDITOR
        // No Editor, pare a reprodução
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Em build standalone, feche a aplicação
        Application.Quit();
#endif
    }
}
