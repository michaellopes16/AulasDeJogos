using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exemplo : MonoBehaviour
{
    //[Header("Controle de posição")]
    //[SerializeField]
    //[Range(1.2f, 6.0f)]
    //private float velocidade = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position + new Vector3(velocidade, 0, 0);
        transform.Rotate(0, 0.05f, 0,Space.Self);
    }
}
