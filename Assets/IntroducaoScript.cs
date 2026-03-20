using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroducaoScript : MonoBehaviour
{
    public KeyCode reTry = KeyCode.Space;

    string final1 = "Você decidiu comer a nova febre culinária da galáxia, bolinhas de núcleo estelar...";
    string final2 = "Mas foi uma péssima ideia! Você começa a sentir uma baita dor de barriga, e o banheiro mais próximo é passando pelo campo de asteroides...";
    string final3 = "Pra piorar os asteroides são atraidos pelo núcleo estelar na sua barriga, deixando sua vida bem mais complicada";
    string final4 = "Você tem que passar pelo campo de asteroides antes que o pior aconteça!";
    string final5 = "Boa sorte";
    string startPrompt = "Aperte espaço para jogar";

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

        yield return StartCoroutine(TypeTextCO(final4, 0.05f));
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
