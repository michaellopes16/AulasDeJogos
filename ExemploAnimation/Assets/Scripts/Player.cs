using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Movimentação do jogador")]
    [SerializeField]
    [Range(3.0f, 10.0f)]
    private float velocidade = 5f;


    [SerializeField] private Text textCountCoin;
    [SerializeField] private Text textCountLifes;

    private Vector2 direction;

    public int countCoins = 0;
    public int countHelth = 100;
    public int countLifes = 3;

    public Animator anim;
    public Renderer warepon;

    [Header("Corpo do player")]
    [SerializeField]
    Rigidbody2D rig;

    //[SerializeField]
    //private PlayerController playerController;
    public HealthBar healthBar;
    void Start()
    {
        healthBar.SetMaxHealth(countHelth);
    }

    // Update is called once per frame
    void Update()
    {
        textCountCoin.text = countCoins.ToString();
        GetKeyboardInput();
        //GetMouseInput();
    }
    private void GetMouseInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        if (dir.x> 0 ) {
            anim.SetFloat("Horizontal", 1);
            anim.SetFloat("HorizontalIdle", 1);
        }else if (dir.x < 0)
        {
            anim.SetFloat("Horizontal", -1);
            anim.SetFloat("HorizontalIdle", -1);
        }
        if (direction.y > 0) {
            warepon.sortingOrder = -1;
        }
        else
        {
            warepon.sortingOrder = 5;
        }

        anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("Velocity", direction.sqrMagnitude);

        if (direction != Vector2.zero)
        {
            anim.SetFloat("HorizontalIdle", direction.x);
            anim.SetFloat("VerticalIdle", direction.y);
        }
    }
    private void GetKeyboardInput()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("Velocity", direction.sqrMagnitude);
        if (direction.y > 0)
        {
            warepon.sortingOrder = -1;
        }
        else if (direction.y < 0)
        {
            warepon.sortingOrder = 5;
        }
        if (direction != Vector2.zero)
        {
            anim.SetFloat("HorizontalIdle", direction.x);
            anim.SetFloat("VerticalIdle", direction.y);
        }
    }

    public void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {

        rig.velocity = new Vector2(direction.x * velocidade, direction.y * velocidade);

    }
    public void LoseLife()
    {
        countLifes -= 1;
        textCountLifes.text = countLifes.ToString();
        if (countLifes > 0)
        {
            countHelth = 100;
            healthBar.SetHealth(countHelth);
        }
        else
        {
            textCountLifes.text = "Lose";
        }
    }
    public void TakeDamage(int damagePlayer)
    {
        countHelth -= damagePlayer;
        healthBar.SetHealth(countHelth);
        if (countHelth <= 0)
        {
            LoseLife();
        }
    }
}
