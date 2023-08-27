using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSoldiers : MonoBehaviour
{
    [SerializeField] GameObject soldier;
    private float minValue = 40f, MaxValue = 80f;
    public int numberOfInstances = 5; // O n�mero de inst�ncias a serem criadas

    // Start is called before the first frame update
    void Start()
    {
        float timeToGenerate = Random.Range(minValue, MaxValue);
        StartCoroutine(InstantiateWithDelayCoroutine(timeToGenerate, soldier));
    }
    private IEnumerator InstantiateWithDelayCoroutine(float timeToGenerate, GameObject soldier)
    {
        for (int i = 0; i < numberOfInstances; i++)
        {
            // Instancia o objeto
            Instantiate(soldier, transform.position, Quaternion.identity);

            // Aguarda o atraso entre inst�ncias
            yield return new WaitForSeconds(timeToGenerate);
        }
    }
}
