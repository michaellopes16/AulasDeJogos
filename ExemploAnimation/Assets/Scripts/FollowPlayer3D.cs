using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer3D : MonoBehaviour
{
    public Transform target; // Referência ao objeto jogador
    public float smoothSpeed = 0.125f; // Velocidade de suavização do movimento da câmera
    public Vector3 offset; // Deslocamento da câmera em relação ao jogador

    void LateUpdate()
    {
        // Calcula a posição desejada da câmera com base na posição do jogador e no deslocamento definido
        Vector3 desiredPosition = target.position + offset;
        // Utiliza a função SmoothDamp para suavizar o movimento da câmera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Atualiza a posição da câmera
        transform.position = smoothedPosition;

        // Faz com que a câmera sempre olhe para o jogador
        transform.LookAt(target);
    }
}
