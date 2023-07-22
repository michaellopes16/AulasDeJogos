using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround3D : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGrounded = false;

    private void OnTriggerEnter(Collider other)
    {

        // Verifica se a colis�o ocorreu com o ch�o
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Tocando o ch�o");
            // Outras a��es quando estiver tocando o ch�o
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto n�o est� mais tocando o ch�o
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("N�o est� tocando o ch�o");
            // Outras a��es quando n�o estiver tocando o ch�o
        }
    }
}
