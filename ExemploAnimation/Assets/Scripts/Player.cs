using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Movimentação do jogador")]
    [SerializeField]
    [Range(3.0f, 10.0f)]
    private float velocidade = 5f;

    private Vector2 direction;


    public Animator anim;

    [Header("Corpo do player")]
    [SerializeField]
    Rigidbody2D rig;

    //[SerializeField]
    //private PlayerController playerController;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("Velocity", direction.sqrMagnitude);

        if (direction != Vector2.zero) {
            anim.SetFloat("HorizontalIdle", direction.x);
            anim.SetFloat("VerticalIdle", direction.y);
        }
        //if (direction.y > 0)
        //{
        //    playerController.PlayAnimation("WalkingBack");
        //}
        //else if (direction.y < 0)
        //{
        //    playerController.PlayAnimation("WalkingFront");
        //}
        //else if (direction.x>0)
        //{
        //    playerController.PlayAnimation("WalkingRight");
        //}
        //else if (direction.x < 0)
        //{
        //    playerController.PlayAnimation("WalkingLeft");
        //}
        //else
        //{
        //    playerController.PlayAnimation("Idle");
        //}
    }

    public void FixedUpdate()
    {
        Move();
    }

    public void Move() {

        rig.velocity = new Vector2(direction.x * velocidade, direction.y * velocidade);

    }
}
