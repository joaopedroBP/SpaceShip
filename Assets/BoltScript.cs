using UnityEngine;

public class BoltScript : MonoBehaviour
{
    public float speed = 8.0f;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2d.linearVelocity = new Vector2(speed, 0);

        if (transform.position.y > 2.9f || transform.position.x > 5f || transform.position.x < -5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se colidiu com algo que tem a Tag Asteroid
        if(collision.CompareTag("Asteroid"))
        {
            // Tenta pegar o script do asteroide para tirar vida
            AsteroidScript scriptAsteroide = collision.GetComponent<AsteroidScript>();

            if(scriptAsteroide != null)
            {
                scriptAsteroide.TomarDano(1); // Tira 1 de vida
            }

            Destroy(gameObject); // O tiro sempre se destrói ao bater
        }
    }
}