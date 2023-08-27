using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SoldBehavior : MonoBehaviour
{
    private GameObject point;
    private NavMeshAgent agent;
    private Animator anim;
    public float lookThreshold = 0.5f; // Ângulo de limiar para considerar que o personagem está olhando
    public bool isStartedFollow = false;
    [SerializeField] private float stoppingDistance = 8f;
    [SerializeField] private float timeToStartingFollow = 5f;
    [SerializeField] private float minValue = 10f; // Valor mínimo do intervalo (inclusive)
    [SerializeField] private float maxValue = 30f; // Valor máximo do intervalo (exclusive)
    [SerializeField] private GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        timeToStartingFollow = Random.Range(minValue, maxValue);
        print("TEmpo inicial: "+ timeToStartingFollow);
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.stoppingDistance = stoppingDistance;

        point = GameObject.FindGameObjectWithTag("Player");
        Invoke(nameof(DelayedSetDestinationMethod), timeToStartingFollow);
    }
    private void DelayedSetDestinationMethod()
    {
        // Define a posição de destino após o atraso
        agent.SetDestination(point.transform.position);
        isStartedFollow = true;
        weapon.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (isStartedFollow)
        {
            agent.SetDestination(point.transform.position);      
        }
        ChangeAnimation();
    }
    public void ChangeAnimation()
    {
        Vector2 direction = agent.velocity.normalized;

        if (direction != Vector2.zero)
        {
            anim.SetBool("IsMoving", true);
            anim.SetFloat("Horizontal", direction.x);
            anim.SetFloat("Vertical", direction.y);
        }
        else
        {
            if (agent.remainingDistance <= stoppingDistance)
            {
                anim.SetBool("IsMoving", false);
            }
        }
    }
}
