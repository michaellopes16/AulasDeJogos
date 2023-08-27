using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArmaManagerSoldier : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 direction;
    private SpriteRenderer spriteRender;
    // Start is called before the first frame update

    [SerializeField] private Transform barrel;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject bullet;
    [SerializeField] private NavMeshAgent soldier;
    private GameObject player;
    private float fireTime;
    [SerializeField] private float minRate = 2f;
    [SerializeField] private float MaxRate = 10f;
    [SerializeField] private float distanceToStartShoot = 8.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveWeapon();
        HandleShooting();
    }

    private void HandleShooting()
    {
        //Dessa forma, ele fica atirando direto. Se quiser que o jogador fique clicando, tem que ser o MouseButtonDown
        if (CanShoot())
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        fireRate = Random.Range(minRate, MaxRate);
        fireTime = Time.time + fireRate;

        //Instantiate
        Instantiate(bullet, barrel.position, barrel.rotation);
    }
    private bool CanShoot()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        return Time.time > fireTime && distance < distanceToStartShoot;
    }
    public void MoveWeapon()
    {
        direction = soldier.velocity;
        if (direction.y < 0)
        {
            spriteRender.sortingOrder = 5;
        }
        else if (direction.y > 0)
        {
            spriteRender.sortingOrder = 3;
        }
    }
}
