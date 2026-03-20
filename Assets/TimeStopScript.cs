using UnityEngine;

public class TimeStopScript : MonoBehaviour
{
    public float speed = 8.0f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= -4.6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ControllerScript controller = Object.FindFirstObjectByType<ControllerScript>();
            if (controller != null)
            {
                controller.AtivarTimeStop();
            }
            Destroy(gameObject);
        }
    }
}