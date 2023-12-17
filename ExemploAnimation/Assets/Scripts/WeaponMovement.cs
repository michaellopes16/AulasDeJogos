using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offset;
    public GameObject fixedJoystick;
    public string nomeDoEixoHorizontal = "HorizontalDireito";
    public string nomeDoEixoVertical = "VerticalDireito";
    private float sensibilidade = 1.0f; // Ajuste conforme necess�rio

    // Start is called before the first frame update
    private void Start()
    {
        //if (IsMobile())
        //{
        //    fixedJoystick.SetActive(true);
        //}
        //else
        //{
        //    fixedJoystick.SetActive(false);
        //}
    }
    void Update()
    {
        if (IsMobile())
        {
            HandleAimingJoystick();
        }
        else
        {
            HandleAiming();
        }
    }
    public bool IsMobile()
    {
        if (Application.isMobilePlatform)
        {
            return true;
        }
        else { return false; }
    }
    private Vector3 CalcularVetorDirecao()
    {
        float inputHorizontal = Input.GetAxis(nomeDoEixoHorizontal) * sensibilidade;
        float inputVertical = Input.GetAxis(nomeDoEixoVertical) * sensibilidade;

        // Crie um vetor de dire��o usando os valores do anal�gico direito
        Vector3 inputDirection = new Vector3(inputHorizontal, 0.0f, inputVertical);

        // Use o vetor de dire��o para calcular a posi��o na tela
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position + inputDirection);

        // Calcule o vetor de dire��o relativo � posi��o do mouse
        Vector3 dir = Input.mousePosition - screenPosition;

        // Retorne o vetor final
        return dir;
    }
    private bool VerificarControlePlugado()
    {
        string[] nomesControles = Input.GetJoystickNames();

        foreach (string nomeControle in nomesControles)
        {
            // Se algum nome de controle for n�o vazio, significa que um controle est� plugado
            if (!string.IsNullOrEmpty(nomeControle))
            {
                return true;
            }
        }

        return false;
    }
    private void HandleAiming()
    {
        //Rota��o
        if (!VerificarControlePlugado())
        {
            MoveWithMouse();
        }
        else
        {
            MoveWithAnalogStick();
        }

    }

    private void MoveWithAnalogStick()
    {
        // Coleta as entradas do anal�gico direito
        float inputHorizontal = Input.GetAxis("HorizontalDireito");
        float inputVertical = Input.GetAxis("VerticalDireito");
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            // Calcula o �ngulo com base nas entradas do anal�gico direito
            float angle = Mathf.Atan2(inputVertical, inputHorizontal) * Mathf.Rad2Deg;

            // Define a rota��o do objeto
            transform.eulerAngles = new Vector3(0, 0, angle);

            // Calcula a dire��o do objeto com base nas entradas do anal�gico direito
            Vector3 playerToMouseDir = new Vector3(inputHorizontal, inputVertical, 0f).normalized;

            // Move o objeto de acordo com a dire��o
            transform.position = player.position + (offset * playerToMouseDir);

            // Inverte a escala do objeto com base no �ngulo
            Vector3 localScale = Vector3.one;
            localScale.y = (angle > 90 || angle < -90) ? -1f : 1f;
            transform.localScale = localScale;
        }
    }



    private void MoveWithMouse()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        //POsi��o
        Vector3 playerToMouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position;
        playerToMouseDir.z = 0;
        transform.position = player.position + (offset * playerToMouseDir.normalized);

        //Girar a arma
        Vector3 localScale = Vector3.one;
        localScale.y = (angle > 90 || angle < -90) ? -1f : 1f;
        transform.localScale = localScale;
    }

    private void HandleAimingJoystick()
    {
        FixedJoystick _fixedJoystick = fixedJoystick.gameObject.GetComponent<FixedJoystick>();
        var dir = new Vector3(_fixedJoystick.Horizontal, _fixedJoystick.Vertical);
        //Rota��o
        if (dir != Vector3.zero)
        {
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);

            //POsi��o
            print("playerToMouseDir" + dir);

            Vector3 playerToMouseDir = dir.normalized;
            //print("playerToMouseDir" + playerToMouseDir);
            playerToMouseDir.z = 0;
            transform.position = player.position + (offset * dir);

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
}
