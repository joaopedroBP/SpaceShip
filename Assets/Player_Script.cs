using UnityEngine;

public class Player_Script : MonoBehaviour
{
    [Header("Teclas de Comando")]
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode shootBolt = KeyCode.Space;

    private Rigidbody2D rb2d; 

    public float shootCooldown = 0.5f;
    private float nextShootTime = 0f;

    public GameObject bolt_prefab;

    [Header("Configurações")]
    public float speed = 5.0f; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 inputDirecao = Vector2.zero;

        if (Input.GetKey(moveLeft))  inputDirecao.x -= 1;
        if (Input.GetKey(moveRight)) inputDirecao.x += 1;
        if (Input.GetKey(moveUp))    inputDirecao.y += 1;
        if (Input.GetKey(moveDown))  inputDirecao.y -= 1;

        if (inputDirecao.magnitude > 1)
        {
            inputDirecao.Normalize();
        }

        // Aplica o movimento
        rb2d.linearVelocity = inputDirecao * speed;

        shoot();
    }

    void shoot(){
        if(Input.GetKey(shootBolt) && Time.time >= nextShootTime){

            Vector2 boltPosition = new Vector2(transform.position.x + 0.5f , transform.position.y);
            Instantiate(bolt_prefab, boltPosition, Quaternion.identity);

            nextShootTime = Time.time + shootCooldown;
        }
    }
}