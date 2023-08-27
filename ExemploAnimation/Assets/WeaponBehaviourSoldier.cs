using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviourSoldier : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform soldier;
    [SerializeField] private float offset;
    private GameObject target;
    // Start is called before the first frame update
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        soldier = transform.parent;
    }
    void Update()
    {
        HandleAiming();
    }
    private void HandleAiming()
    {
        //Rotação
        Vector2 directionToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        //POsição
        Vector3 playerToMouseDir = target.transform.position - soldier.position;
        playerToMouseDir.z = 0;
        transform.position = soldier.position + (offset * playerToMouseDir.normalized);

        //Girar a arma
        Vector3 localScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }
        transform.localScale = localScale;
    }
}
