using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogBehaviour2 : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] sentences;
    public Image characterImage;
    public Text characterName;
    public Text dialogText;
    public int indexController;
    void Start()
    {
        indexController = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OpenDialog()
    {
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 2f).setScale(0.5f).setEase(LeanTweenType.easeInBack);
    }
    public void CloseDialog()
    {
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 2f).setScale(0.5f).setEase(LeanTweenType.easeInBack);
    }
    public void SetInformations(string characterName, string [] sentences, Sprite characterImage) {
        this.sentences = sentences;
        this.characterImage.sprite = characterImage;
        this.characterName.text = characterName;
        CallNextSentence();
    }

    public void CallNextSentence()
    {
        if (indexController < sentences.Length) { 
            dialogText.text = sentences[indexController]; indexController++;
        }
        else
        {
            CloseDialog();
        }
    }
}
