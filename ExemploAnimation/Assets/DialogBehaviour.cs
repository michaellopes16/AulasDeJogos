using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textNameCharacter;
    [SerializeField] private TextMeshProUGUI textDialog;
    [SerializeField] private Image imageCharacter;
    [SerializeField] private Sprite testeSprote;
    [SerializeField] private float timeOfType = 0.5f;
    private float speedScale = 1f;
    private string[] currentSentences;
    private int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        textNameCharacter.text = "";
    }

    public void OpenDialog(string [] sentences, string nameCharacter, Sprite sprite) {
        textNameCharacter.text = nameCharacter;
        currentSentences = sentences;
        imageCharacter.sprite = sprite;
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), speedScale).setScale(0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(CallNextDialog);
    }
    public void CloseDialog()
    {
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), speedScale).setScale(0.5f).setEase(LeanTweenType.easeOutBack);
    }
    public void CallNextDialog()
    {
        if (currentIndex < currentSentences.Length)
        {
            StartCoroutine(TypeEacheCharacter());
            currentIndex++;
        }
        else
        {
            CloseDialog();
        }
    }

    IEnumerator TypeEacheCharacter()
    {
        textDialog.text = "";
        foreach (char latter in currentSentences[currentIndex].ToCharArray())
        {
            textDialog.text += latter;
            yield return new WaitForSeconds(timeOfType);
        }
    }
}
