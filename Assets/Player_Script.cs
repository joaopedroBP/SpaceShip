using UnityEngine;

public class Player_Script : MonoBehaviour
{

    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode shootBolt = KeyCode.Space;

    private Rigidbody2D rb2d; 

    public float speed = 8.0f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var vel = rb2d.linearVelocity;

        if(Input.GetKey(moveLeft)){
            vel.x = -speed;
        }
        else if(Input.GetKey(moveRight)){
            vel.x = speed;
        }
        else if(Input.GetKey(moveUp)){
            vel.y = speed;
        }
        else if(Input.GetKey(moveDown)){
            vel.y = -speed;
        }else{
            vel.x = 0;
            vel.y = 0;
        }


        rb2d.linearVelocity = vel;

    }
}
