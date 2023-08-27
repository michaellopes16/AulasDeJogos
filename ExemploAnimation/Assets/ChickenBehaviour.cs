using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private DialogBehaviour2 dialogBehaviour;
    [SerializeField] private SpriteRenderer sptChicken;
    void Start()
    {
        sptChicken = gameObject.GetComponent<SpriteRenderer>();
        string[] sentences = {"Oi, meu nome é Carijó!","Irei te dar o alimento que precisa.","Gosto muito de milho!" };
        dialogBehaviour.SetInformations("Carijó", sentences, sptChicken.sprite);
        dialogBehaviour.OpenDialog();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
