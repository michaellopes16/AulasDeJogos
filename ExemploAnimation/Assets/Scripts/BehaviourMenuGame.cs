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
            .setScale(0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(PauseMenu);
        LeanTween.alpha(blackBackground, 0.5f, 1f);

    }
    public void PauseMenu()
    {
        //Se o valor de Time.timeScale for == 1, ele altera o seu valor para 0, e para a rotina do jogo
        // Se for 0, ele recebe 1 e retoma a rotina do jogo
        Time.timeScale = Time.timeScale == 1 ? 0: 1;      
    }
    public void RemoveMenuQuit()
    {
        LeanTween.scale(menuQuitGame, new Vector3(0, 0, 0), 0.5f).setOnStart(PauseMenu);
        LeanTween.alpha(blackBackground, 0f, 0.5f);
    }
}
