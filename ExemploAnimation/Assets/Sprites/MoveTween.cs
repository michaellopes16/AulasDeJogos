using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTween : MonoBehaviour
{
    public Transform[] controlPoints; // Array de pontos de controle e pontos finais da curva
    public float duration = 5f; // Dura��o da anima��o em segundos
    [SerializeField] float speed = 3f;

    private void Start()
    {
        // Verifique se existem pelo menos 4 pontos (dois conjuntos) para criar uma trajet�ria v�lida
        if (controlPoints.Length < 2)
        {
            Debug.LogError("� necess�rio pelo menos quatro pontos (dois conjuntos) para criar uma trajet�ria v�lida.");
            return;
        }

        // Duplicar o primeiro e segundo ponto para criar uma trajet�ria v�lida com pelo menos quatro pontos
        // Crie o array de trajet�ria para o LeanTween usando os pontos do array
        Vector3[] path = new Vector3[controlPoints.Length];
        for (int i = 0; i < controlPoints.Length; i++)
        {
            path[i] = controlPoints[i].position;
            print(path[i]);
        }
        print(path.Length);
        // Use o LeanTween.move para mover o objeto ao longo da trajet�ria
        LeanTween.move(gameObject, path, duration).setSpeed(speed).setEase(LeanTweenType.easeInOutSine).setLoopPingPong().setOrientToPath(false);
    }
}
