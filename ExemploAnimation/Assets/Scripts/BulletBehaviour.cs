using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] private float bulletSpeed;
    public GameObject PikupEffect;
    public Color corGizmo = Color.red; // Cor do gizmo a ser desenhado

    private void OnDrawGizmos()
    {
        // Define a cor do gizmo
        Gizmos.color = corGizmo;

        // Desenha o collider do objeto
        Collider2D collider2D = GetComponent<Collider2D>();
        if (collider2D != null)
        {
            // Verifica o tipo de collider e desenha o gizmo apropriado
            if (collider2D is BoxCollider2D)
            {
                BoxCollider2D boxCollider = (BoxCollider2D)collider2D;
                Gizmos.DrawWireCube(transform.position + (Vector3)boxCollider.offset, boxCollider.size);
            }
            else if (collider2D is CircleCollider2D)
            {
                CircleCollider2D circleCollider = (CircleCollider2D)collider2D;
                Gizmos.DrawWireSphere(transform.position + (Vector3)circleCollider.offset, circleCollider.radius);
            }
            // Você pode adicionar mais lógica aqui para outros tipos de colliders, como PolygonCollider2D, etc.
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Ta entrando no método pelo menos000");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Tá colidindo com a bala");
            //Add a death effect when the collision ocour
            GameObject particula = Instantiate(PikupEffect, transform.position, transform.rotation);
            //Distroy the enemy and the effect generated with death
            float tempoDeVidaParticula = particula.GetComponent<ParticleSystem>().main.duration;
            Destroy(particula, tempoDeVidaParticula);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
