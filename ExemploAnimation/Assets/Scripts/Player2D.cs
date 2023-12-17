using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player2D : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Movimentação do jogador")]
    [SerializeField]
    [Range(2.0f, 10.0f)]
    [Tooltip("Essa é a variável responsável pela velocidade do jogador")]

    private float velocidade;
    [SerializeField]
    bool isJumping;

    [SerializeField]
    [Range(2.0f, 6.0f)]
    float jumpForce = 3.0f;
    Vector2 direction;

    [Header("Corpo do player")]
    [SerializeField]
    Rigidbody2D rig;

    [SerializeField]
    SpriteRenderer sprite;

    public PlayerController playAnim;
    public Animator animator;
    private bool isGrounded = true;

    public RawImage background;
    private float rectMove = 0f;

    public int countCoins = 0;
    public Text textCoin;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        playAnim = GetComponent<PlayerController>();
        background.uvRect = new Rect(rectMove, 0f, 1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCoin();
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (direction.x < 0)
        {
            if (isGrounded)
            {
                playAnim.PlayAnimation("WalkingLeft2D");
            }
            sprite.flipX = false;
        }
        else if (direction.x > 0)
        {
            if (isGrounded)
            {
                playAnim.PlayAnimation("WalkingLeft2D");
            }
            sprite.flipX = true;
        }
        else if(isGrounded && direction.x == 0)
        { 
            playAnim.PlayAnimation("Idle2D");
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        // Verificar animação de pulo
        if (!isGrounded)
        {
            playAnim.PlayAnimation("Jump2D");
        }
        if (direction.x != 0) {
            //MoveBackground(direction.x);
        }

    }

    /// <summary>
    /// Esse é um método que é usado quando a física do jogo é utilizada
    /// </summary>
    void FixedUpdate()
    {
        Move();
        Jump();
        Debug.Log("");
    }

    public void UpdateCoin()
    {
        textCoin.text = countCoins.ToString();
    }
    void Move()
    {
        //Debug.Log(direction);
        rig.velocity = new Vector2(direction.x * velocidade, rig.velocity.y);
    }

    void Jump()
    {
        if (isJumping)
        {
            rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o personagem está no chão para permitir pulos adicionais
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Verifica se o personagem saiu do chão
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            isJumping = true;
        }
    }

    public void MoveBackground(float move)
    {
        background.uvRect =  new Rect(rectMove + move/10000, 0f, 1f, 1f);
        rectMove = background.uvRect.x;
    }
}
