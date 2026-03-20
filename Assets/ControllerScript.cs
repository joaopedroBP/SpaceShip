using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // NECESSÁRIO para mudar de cena

public class ControllerScript : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject asteroidPequenoPrefab;
    public GameObject asteroidGrandePrefab;
    public GameObject timeStopPrefab;

    [Header("Interface")]
    public TextMeshProUGUI textoPontuacao;
    private int pontuacaoTotal = 0;

    [Header("Configurações de Tempo")]
    private float cronometroDeJogo = 0f;
    private bool playerVenceu = false;
    private bool parouSpawn = false;

    [Header("Time Stop Settings")]
    public bool isTimeStopped = false;
    public float timeStopDuration = 5.0f;
    private float timeStopTimer = 0f;

    private float timerPequeno;
    private float timerGrande;
    private float timerTimeStop;

    [Header("Limites de Spawn (Y)")]
    public float limiteY_Cima = 1.5f;
    public float limiteY_Baixo = -1.5f;

    void Start()
    {
        AtualizarTexto();
    }

    void Update()
    {
        cronometroDeJogo += Time.deltaTime;

        if (cronometroDeJogo >= 60f && !parouSpawn)
        {
            parouSpawn = true;
            Debug.Log("Sobreviveu! Parando spawns...");
        }

        if (parouSpawn && cronometroDeJogo >= 70f && !playerVenceu)
        {
            playerVenceu = true;
            SceneManager.LoadScene("Victory");
        }

        if (GameObject.FindGameObjectWithTag("Player") == null && !playerVenceu)
        {
            SceneManager.LoadScene("Defeat");
        }

        if (!parouSpawn)
        {
            GerenciarSpawns();
        }

        if (isTimeStopped)
        {
            timeStopTimer -= Time.deltaTime;
            if (timeStopTimer <= 0) isTimeStopped = false;
        }
    }

    void GerenciarSpawns()
    {
        timerPequeno += Time.deltaTime;
        if (timerPequeno >= 1.0f)
        {
            SpawnAsteroid(asteroidPequenoPrefab, 2, 30);
            timerPequeno = 0;
        }

        timerGrande += Time.deltaTime;
        if (timerGrande >= 5.0f)
        {
            SpawnAsteroid(asteroidGrandePrefab, 3, 60);
            timerGrande = 0;
        }

        timerTimeStop += Time.deltaTime;
        if (timerTimeStop >= 10.0f)
        {
            SpawnTimeStop();
            timerTimeStop = 0;
        }
    }

    void SpawnAsteroid(GameObject prefab, int vidaInicial, int pontos)
    {
        float spawnY = Random.Range(limiteY_Baixo, limiteY_Cima);
        GameObject novo = Instantiate(prefab, new Vector2(4.6f, spawnY), Quaternion.identity);
        AsteroidScript script = novo.GetComponent<AsteroidScript>();
        if (script != null) { script.hp = vidaInicial; script.pontosAoMorrer = pontos; }
    }

    void SpawnTimeStop()
    {
        float spawnY = Random.Range(limiteY_Baixo, limiteY_Cima);
        Instantiate(timeStopPrefab, new Vector2(4.6f, spawnY), Quaternion.identity);
    }

    public void AtivarTimeStop() { isTimeStopped = true; timeStopTimer = timeStopDuration; }
    public void AdicionarPontos(int valor) { pontuacaoTotal += valor; AtualizarTexto(); }
    void AtualizarTexto() { if (textoPontuacao != null) textoPontuacao.text = "Pontos: " + pontuacaoTotal.ToString(); }
}