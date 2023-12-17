using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorNextLevelCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public BehaviourMenuGame menuGame;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            menuGame.OpenMenuWinn();
        }
    }
}
