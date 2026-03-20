using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    [Header("Status")]
    public int hp;
    public int pontosAoMorrer;

    [Header("Velocidades")]
    private float velocidadeFinal;
    public float velocidadeMin = 1.0f; 
    public float velocidadeMax = 2.0f;
    
    public float distanciaDetectar = 1.5f; 
    private Transform player;
    private ControllerScript controller;

    void Start()
    {
        velocidadeFinal = Random.Range(velocidadeMin, velocidadeMax);
        controller = Object.FindFirstObjectByType<ControllerScript>();
        
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
    }

    void Update()
    {
        // Define a velocidade com base no estado do TimeStop
        float vAtual = velocidadeFinal;
        if (controller != null && controller.isTimeStopped)
        {
            vAtual = 0.4f; // Velocidade reduzida durante o efeito
        }

        if (player != null && Vector2.Distance(transform.position, player.position) < distanciaDetectar)
        {
            Vector2 direcao = (player.position - transform.position).normalized;
            transform.Translate(direcao * vAtual * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * vAtual * Time.deltaTime);
        }

        if (transform.position.x < -6f) Destroy(gameObject);
    }

    public void TomarDano(int dano)
    {
        hp -= dano;
        if (hp <= 0)
        {
            if (controller != null) controller.AdicionarPontos(pontosAoMorrer);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}