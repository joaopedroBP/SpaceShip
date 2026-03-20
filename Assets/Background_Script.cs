using UnityEngine;

public class Background_Script : MonoBehaviour
{
    [Header("Configurações de Velocidade")]
    public float parallaxEffect = 2.0f; // Velocidade normal do fundo

    private float length;
    private ControllerScript controller;

    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        controller = Object.FindFirstObjectByType<ControllerScript>();
    }

    void Update()
    {
        float pAtual = parallaxEffect;

        // Se o Time Stop estiver ativo no Controller, reduz o movimento do fundo
        if (controller != null && controller.isTimeStopped)
        {
            // O fundo fica 85% mais lento (quase parado)
            pAtual = parallaxEffect * 0.15f;
        }

        transform.position += Vector3.left * Time.deltaTime * pAtual;
        if (transform.position.x < -length)
        {
            transform.position = new Vector3(length, transform.position.y, transform.position.z);
        }
    }
}