using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer3D : MonoBehaviour
{
    public Transform target; // Refer�ncia ao objeto jogador
    public float smoothSpeed = 0.125f; // Velocidade de suaviza��o do movimento da c�mera
    public Vector3 offset; // Deslocamento da c�mera em rela��o ao jogador

    void LateUpdate()
    {
        // Calcula a posi��o desejada da c�mera com base na posi��o do jogador e no deslocamento definido
        Vector3 desiredPosition = target.position + offset;
        // Utiliza a fun��o SmoothDamp para suavizar o movimento da c�mera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Atualiza a posi��o da c�mera
        transform.position = smoothedPosition;

        // Faz com que a c�mera sempre olhe para o jogador
        transform.LookAt(target);
    }
}
