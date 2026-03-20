using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class DefeatScript : MonoBehaviour
{
    public KeyCode reTry = KeyCode.Space;

    string final1 = "Você não conseguiu passar pelo campo de asteroides e sua nave ficou presa no espaço...";
    string final2 = "Mais e Mais asteroides se algomeram ao seu redor, e você não consegue mais segurar...";
    string final3 = "Você acabas se sujando todo, deixando sua nave com um cheiro horrível... ";
    string final5 = "Você Perdeu!";
    string startPrompt = "Aperte espaço para jogar novamente!";

    TMP_Text introducao;

    void Awake()
    {
        introducao = GetComponent<TMP_Text>();
    }

    void Start()
    {
        StartCoroutine(IntroducaoCompleta());
    }

    void Update(){
        GameStart();
    }

    void GameStart(){
        if(Input.GetKey(reTry)){
             SceneManager.LoadScene("gameplay");
        }
    }

    IEnumerator IntroducaoCompleta()
    {
        yield return StartCoroutine(TypeTextCO(final1, 0.05f));
        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(TypeTextCO(final2, 0.05f));
        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(TypeTextCO(final3, 0.05f));
        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(TypeTextCO(final5, 0.18f));
        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(TypeTextCO(startPrompt, 0f));
    }

    IEnumerator TypeTextCO(string texto, float delay)
    {
        introducao.text = "";

        for (int i = 0; i < texto.Length; i++)
        {
            introducao.text += texto[i];
            yield return new WaitForSeconds(delay);
        }
    }
}
