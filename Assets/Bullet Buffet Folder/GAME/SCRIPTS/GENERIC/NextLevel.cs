using System.Collections;
using TMPro;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private GameObject playerReference1;
    private GameObject playerReference2;
    [SerializeField] private GameObject map1;
    [SerializeField] private GameObject map2;

    public float tiempoInicial = 4f;
    public float tiempoActual;
    [SerializeField] private float multiplicador;

    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;

    [SerializeField] private Canvas panelPantallaDeCarga;

    [SerializeField] private Transform spawn1;
    [SerializeField] private Transform spawn2;

    CapsuleCollider col1;
    PlayerController plaC1;

    CapsuleCollider col2;
    PlayerController plaC2;

    private bool player1InArea = false;
    private bool player2InArea = false;

    private void Start()
    {
        playerReference1 = GameObject.FindGameObjectWithTag("Player1");
        playerReference2 = GameObject.FindGameObjectWithTag("Player2");

        col1 = playerReference1.GetComponent<CapsuleCollider>();
        plaC1 = playerReference1.GetComponent<PlayerController>();

        col2 = playerReference2.GetComponent<CapsuleCollider>();
        plaC2 = playerReference2.GetComponent<PlayerController>();

        tiempoActual = tiempoInicial;

    }

    private void Update()
    {
        CheckArea();
        CheckTime();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerReference1.tag == "Player1")
        {
            player1InArea = true;
        }

        else if (playerReference2.tag == "Player2")
        {
            player2InArea = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (playerReference1.tag == "Player1")
        {
            if (player1InArea)
            {
                player1InArea = false;
                tiempoActual = tiempoInicial;
                text1.enabled = false;
            }
        }

        else if (playerReference2.tag == "Player2")
        {
            if (player2InArea)
            {
                player2InArea = false;
                tiempoActual = tiempoInicial;
                text2.enabled = false;
            }
        }

    }

    void CheckArea()
    {
        if (player1InArea && !player2InArea)
        {
            ReducirTiempo();
        }

        else if (!player1InArea && player2InArea)
        {
            ReducirTiempo();
        }
        else
        {
            return;
        }
    }

    void CheckTime()
    {
        if (tiempoActual <= 0)
        {
            StartCoroutine(nextLevelCoroutine());
        }
    }

    void ReducirTiempo()
    {
        if (player1InArea)
        {
            text1.enabled = true;
            text1.text = tiempoActual.ToString();
            tiempoActual -= Time.deltaTime * multiplicador;
        }

        else if (player2InArea) //Testiar haber si no ocaciona problemas con el prendido y apagado de la vaiable text1 y text2, si si los ocaciona, cambiar el "else if" por un "if" y debajo del mismo, agregarle el else con su respectiva linea de codigo para apagar las variables text1 y 2.
        {
            text2.enabled = true;
            text2.text = tiempoActual.ToString();
            tiempoActual -= Time.deltaTime * multiplicador;
        }
        else
        {
            text1.enabled = false;
            text2.enabled = false;
        }
    }

    void TrasladarPlayer()
    {
        Instantiate(playerReference1, spawn1.transform.position, Quaternion.identity);
        Instantiate(playerReference2, spawn2.transform.position, Quaternion.identity);
    }

    IEnumerator nextLevelCoroutine()
    {
        panelPantallaDeCarga.enabled = true;
        col1.enabled = false; col2.enabled = false;
        plaC1.enabled = false; plaC2.enabled = false;
        map1.SetActive(false); map2.SetActive(true);
        TrasladarPlayer();
        yield return new WaitForSeconds(5f);
        panelPantallaDeCarga.enabled = false;
        tiempoActual = tiempoInicial;
        col1.enabled = true; col2.enabled = true;
        yield return new WaitForSeconds(2f);
        plaC1.enabled = true; plaC2.enabled = true;
        yield return new WaitForSeconds(0.5f);
    }


}
