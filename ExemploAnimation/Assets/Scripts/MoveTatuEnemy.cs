using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTatuEnemy : MoveEnemy
{

    public override void CheckArrivedInTarget()
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
}
