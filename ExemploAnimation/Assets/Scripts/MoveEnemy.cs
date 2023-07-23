using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public Transform targetA;
    public Transform targetB;
    public float distanciaMinima = 6f;
    public Transform currentTarget;

    public SpriteRenderer sr;
    public float velocity = 2f;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = targetB;
    }

    // Update is called once per frame
    void Update()
    {
        CheckArrivedInTarget();
        MoveUntilTarget();
        FlipSpriteRender();
    }
    public virtual void CheckArrivedInTarget()
    {
        // Se o ponto que eu quero chegar � o target A e minha posi��o atual � igual ao Target A, o personagem chegou no destino
        if (currentTarget == targetA && transform.position == targetA.position)
        {
            currentTarget = targetB;
        }
        if (currentTarget == targetB && transform.position == targetB.position)
        {
            currentTarget = targetA;
        }
    }
    public void MoveUntilTarget()
    {
        //Isso faz o inimigo ir atr�s do target s� se a dist�ncia for menor que a m�nima
        float distancia = Vector2.Distance(transform.position, currentTarget.position);
        if (distancia <= distanciaMinima)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, velocity * Time.deltaTime);
        }
    }
    public void FlipSpriteRender()
    {
        if (transform.position.x > currentTarget.position.x)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
    }
}
