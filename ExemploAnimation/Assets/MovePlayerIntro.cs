using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerIntro : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform[] controlPoints; // Array de pontos de controle e pontos finais da curva
    [SerializeField] private float duration = 5f; // Duração da animação em segundos
    [SerializeField] private float speed = 3f;

    private void Start()
    {
        // Verifique se existem pelo menos 4 pontos (dois conjuntos) para criar uma trajetória válida
        if (controlPoints.Length < 4)
        {
            Debug.LogError("É necessário pelo menos quatro pontos (dois conjuntos) para criar uma trajetória válida.");
            return;
        }

        // Duplicar o primeiro e segundo ponto para criar uma trajetória válida com pelo menos quatro pontos
        // Crie o array de trajetória para o LeanTween usando os pontos do array
        Vector3[] path = new Vector3[controlPoints.Length];
        for (int i = 0; i < controlPoints.Length; i++)
        {
            path[i] = controlPoints[i].position;
        }
        // Use o LeanTween.move para mover o objeto ao longo da trajetória
        LeanTween.move(gameObject, path, duration).setSpeed(speed).setEase(LeanTweenType.linear).setOrientToPath(false);
    }
}
