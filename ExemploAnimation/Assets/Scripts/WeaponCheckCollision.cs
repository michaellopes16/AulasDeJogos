using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCheckCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject weapon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Está colidindo com a arma");
            weapon.SetActive(true);
            Destroy(gameObject);
        }
    }
}
