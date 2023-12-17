using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Player Movement")]
    [SerializeField]
    [Range(3.0f, 10.0f)]
    private float velocidade = 5f;
    private Vector2 direction;

    [Header("GUI components")]
    [SerializeField] private Text textCountCoin;
    [SerializeField] private Text textCountLifes;
    [SerializeField] private Text textCountFlor;
    public HealthBar healthBar;
    public GameObject keyImage;


    [Header("Count Variables")]
    public int countCoins = 0;
    public int countHelth = 100;
    public int countLifes = 3;
    public int countFlorMandacaru =0;
    [SerializeField] private int maxFruit = 2;

    [Header("Player body")]
    [SerializeField]
    Rigidbody2D rig;
    public Animator anim;
    public Renderer wareponSR;

    //[SerializeField]
    //private PlayerController playerController;
    [Header("Mobile elements")]
    public GameObject fixedJoystick, fixedJoustick2;
    public GameObject shotButton;

    [Header("Audio")]
    [SerializeField] private AudioClip opemDorEffect;
    [SerializeField] private AudioSource AudioSource;

    [Header("PowerUps")]
    public GameObject weapon;
    [SerializeField] private GameObject keyPowerUp;
    public bool hasKey=false;
    public bool showKey = false;
    public BehaviourMenuGame menuGame;
    void Start()
    {
        if (Application.isMobilePlatform)
        {
            fixedJoystick.SetActive(true);
        }
        else { shotButton.SetActive(false); fixedJoystick.SetActive(false); }
        //menuGame = GameObject.FindGameObjectWithTag("Manager").GetComponent<BehaviourMenuGame>();
        healthBar.SetMaxHealth(countHelth);
    }

    // Update is called once per frame
    void Update()
    {
        textCountCoin.text = countCoins.ToString();
        ManageNextLevel();
        if (Application.isMobilePlatform)
        {
            if (weapon.activeSelf)
            {
                fixedJoustick2.SetActive(true);
                shotButton.SetActive(true);
            }
            else
            {
                fixedJoustick2.SetActive(false);
                shotButton.SetActive(false);
            }
            GetJoystickMoviments();
            // Faça algo específico para dispositivos móveis aqui.
        }
        else
        {
            shotButton.SetActive(false);
            fixedJoustick2.SetActive(false);
            GetKeyboardInput();
        }

        //GetMouseInput();
    }

    public void GetJoystickMoviments()
    {
        FixedJoystick _fixedJoystick = fixedJoystick.GetComponent<FixedJoystick>();
        direction = new Vector2(_fixedJoystick.Horizontal, _fixedJoystick.Vertical);

        anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("Velocity", direction.sqrMagnitude);
        if (direction.y > 0)
        {
            wareponSR.sortingOrder = 3;
        }
        else if (direction.y < 0)
        {
            wareponSR.sortingOrder = 5;
        }
        if (direction != Vector2.zero)
        {
            anim.SetFloat("HorizontalIdle", direction.x);
            anim.SetFloat("VerticalIdle", direction.y);
        }
    }
    private void GetMouseInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        if (dir.x > 0)
        {
            anim.SetFloat("Horizontal", 1);
            anim.SetFloat("HorizontalIdle", 1);
        }
        else if (dir.x < 0)
        {
            anim.SetFloat("Horizontal", -1);
            anim.SetFloat("HorizontalIdle", -1);
        }
        if (direction.y > 0)
        {
            wareponSR.sortingOrder = -1;
        }
        else
        {
            wareponSR.sortingOrder = 5;
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
            wareponSR.sortingOrder = 3;
        }
        else if (direction.y < 0)
        {
            wareponSR.sortingOrder = 5;
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
        if (countLifes > 0)
        {
            countHelth = 100;
            healthBar.SetHealth(countHelth);
        }
        else
        {
            menuGame.OpenMenuLoss();
        }
        textCountLifes.text = countLifes.ToString();

    }

    public void GetKey()
    {
        hasKey = true;
        LeanTween.scale(keyImage.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 1f).setEaseInBounce();
    }
    public void ManageNextLevel()
    {
        if (countFlorMandacaru>=maxFruit && !showKey) {
            showKey = true;
            AudioSource.PlayOneShot(opemDorEffect);
            keyPowerUp.SetActive(true);
        }
    }
    public void UpFlorMandacaru()
    {
        countFlorMandacaru++;
        textCountFlor.text = countFlorMandacaru.ToString();
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
