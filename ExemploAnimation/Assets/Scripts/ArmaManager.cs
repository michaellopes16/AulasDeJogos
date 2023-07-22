using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaManager : MonoBehaviour
{
    private Vector2 direction;
    private SpriteRenderer spriteRender;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(direction.x > 0)
        {
            //Valores ideais para posição da arma do personagem. Colocar isso em variáveis
            transform.localRotation = Quaternion.Euler(0f, 0f, -27.18f);
            transform.localPosition = new Vector2(0.7f, -0.504f);

        }
        else if (direction.x < 0) {
            //Valores ideais para posição da arma do personagem. Colocar isso em variáveis
            transform.localRotation = Quaternion.Euler(0f, 180f, -27.18f);
            transform.localPosition = new Vector2(-0.7f, -0.504f) ;
        }
        else if(direction.y < 0)
        {
            spriteRender.sortingOrder = 5;
            //Valores ideais para posição da arma do personagem. Colocar isso em variáveis
            //transform.localPosition = new Vector2(0.42f, -0.471f);
        }
        else if (direction.y >0) {
            spriteRender.sortingOrder = 3;
            //Valores ideais para posição da arma do personagem. Colocar isso em variáveis
            //transform.localPosition = new Vector2(0.42f, -0.471f);
        }

    }
}
