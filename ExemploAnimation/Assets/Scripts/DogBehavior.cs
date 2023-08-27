using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogBehavior : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent agent;
    private Animator anim;
    [SerializeField] private float minDistance = 5f;
    [SerializeField] private DialogBehaviour dialog;
    private string[] sentecesToDialog;
    private string characterName;
    private bool dialogOpened = false, canFollow = false;
    [SerializeField] private Sprite spriteCharacter;
    void Start()
    {
        characterName = "Caramelo";
        sentecesToDialog = new string[] { "Oi, meu nome é "+ characterName + "!",
                                          "Estou aqui para te ajudar na sua jornada!",
                                          "Quando alguma ameaça se aproximar, te avisarei para que você esteja preparado.",
                                          "Serei seu fiel amigo! :) " };
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CanFollow();
        if (canFollow)
        {
            if (!dialogOpened)
            {

                dialog.OpenDialog(sentecesToDialog, characterName, spriteCharacter);
                dialogOpened = true;
            }
            print("Folowing...");
            agent.SetDestination(player.transform.position);
            agent.stoppingDistance = 3;
            ChangeAnimation();
        }

    }
    public void CanFollow()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < minDistance)
        {
            canFollow = true;
        }

    }
    public void PauseMenu()
    {
        //Se o valor de Time.timeScale for == 1, ele altera o seu valor para 0, e para a rotina do jogo
        // Se for 0, ele recebe 1 e retoma a rotina do jogo
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
    }

    public void ChangeAnimation()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (direction != Vector2.zero)
        {
            anim.SetBool("IsMoving", true);
            anim.SetFloat("Horizontal", direction.x);
            anim.SetFloat("Vertical", direction.y);
        }
        else
        {
            if (agent.remainingDistance <= 3)
            {
                anim.SetBool("IsMoving", false);
            }
        }
    }
}

