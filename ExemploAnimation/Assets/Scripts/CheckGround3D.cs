using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround3D : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGrounded = false;

    private void OnTriggerEnter(Collider other)
    {

        // Verifica se a colisão ocorreu com o chão
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Tocando o chão");
            // Outras ações quando estiver tocando o chão
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto não está mais tocando o chão
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("Não está tocando o chão");
            // Outras ações quando não estiver tocando o chão
        }
    }
}
