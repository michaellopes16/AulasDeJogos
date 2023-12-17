using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BehaviourMenuGame : MonoBehaviour
{
    [SerializeField] private RectTransform blackBackground;
    [SerializeField] private RectTransform menuQuitGame, popUpLoss, popUpWin;
    [Header("AudioEffects")]
    [SerializeField] private AudioClip winEffect, lossEffect, winMusic,lossMusic;
    [Header("AudioResources")]
    [SerializeField] private AudioSource audioSourceEffect, audioSourceMusic;
    [SerializeField] private Button botaoUI;
    private bool inPause = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        // Verifique se o botão "Start" do joystick foi pressionado
        if (Input.GetButtonDown("StartButton")) // Substitua "StartButton" pelo nome correto do botão de start do seu joystick
        {
            if (!inPause)
            {
                botaoUI.onClick.Invoke();
            }
            else
            {
                RemoveMenuQuit();
            }
            // Execute o evento OnClick do botão UI
            
        }
    }
    public void OpenMenuQuit()
    {
        LeanTween.scale(menuQuitGame, new Vector3(1, 1, 1), 0.5f)
            .setScale(0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(PauseMenu);
        LeanTween.alpha(blackBackground, 0.5f, 1f);
    }
    public void OpenMenuLoss()
    {
        audioSourceEffect.PlayOneShot(lossEffect);
        audioSourceMusic.clip = lossMusic;
        audioSourceMusic.Play();
        LeanTween.scale(popUpLoss, new Vector3(1, 1, 1), 0.5f)
            .setScale(0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(PauseMenu);
        LeanTween.alpha(blackBackground, 0.5f, 1f);
    }

    public void OpenMenuWinn()
    {
        audioSourceEffect.PlayOneShot(winEffect);
        audioSourceMusic.clip = winMusic;
        audioSourceMusic.Play();
        LeanTween.scale(popUpWin, new Vector3(1, 1, 1), 0.5f)
            .setScale(0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(PauseMenu);
        LeanTween.alpha(blackBackground, 0.5f, 1f);
    }
    public void RestartGame()
    {
        // Carrega a cena atual novamente para reiniciar o jogo.
        PauseMenu();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void CallNextLevel(string nextLevelName)
    {
        // Carrega a cena atual novamente para reiniciar o jogo.
        SceneManager.LoadScene(nextLevelName);
    }
    public void PauseMenu()
    {
        //Se o valor de Time.timeScale for == 1, ele altera o seu valor para 0, e para a rotina do jogo
        // Se for 0, ele recebe 1 e retoma a rotina do jogo
        inPause = !inPause;
        Time.timeScale = Time.timeScale == 1 ? 0: 1;      
    }
    public void RemoveMenuQuit()
    {
        
        LeanTween.scale(menuQuitGame, new Vector3(0, 0, 0), 0.5f).setOnStart(PauseMenu);
        LeanTween.alpha(blackBackground, 0f, 0.5f);
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
