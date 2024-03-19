using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class RespawnSystem : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;

    [SerializeField] private Transform respawnPoint1;
    [SerializeField] private Transform respawnPoint2;

    private Vida vida1;
    private Vida vida2;

    private PlayerController playerController1;
    private PlayerController playerController2;

    private void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");


        if (player1 != null)
        {
            vida1 = player1.GetComponent<Vida>();
            playerController1 = player1.GetComponent<PlayerController>();
        }

        if (player2 != null)
        {
            vida2 = player2.GetComponent<Vida>();
            playerController2 = player2.GetComponent<PlayerController>();
        }
        else
        {
            Debug.LogWarning("No se encontro player2 para RESPAWNSYSTEM");
        }

    }

    private void Update()
    {
        CheckHealthPlayer();
    }

    void CheckHealthPlayer()
    {
        if (vida1.salud <= 0)
        {
            player1.SetActive(false);
            StartCoroutine(RespawnCorutine1());
        }

        else if (vida2.salud <= 0)
        {
            player2.SetActive(false);
            StartCoroutine(RespawnCorutine2());
        }
    }

    IEnumerator RespawnCorutine1()
    {
        playerController1.enabled = false;
        Instantiate(player1, respawnPoint1.position, respawnPoint1.rotation);
        //Translate.Equals(player1.transform.position, respawnPoint1.transform.position.normalized);
        yield return new WaitForSeconds(4f);
        player1.SetActive(true);
        vida1.salud = 100;
        yield return new WaitForSeconds(2f);
        playerController1.enabled = true;
        StopAllCoroutines();
    }

    IEnumerator RespawnCorutine2()
    {
        playerController2.enabled = false;
        Instantiate(player2, respawnPoint2.position, respawnPoint2.rotation);
        //Translate.Equals(player2.transform.position, respawnPoint2.transform.position.normalized);
        yield return new WaitForSeconds(4f);
        player2.SetActive(true);
        vida2.salud = 100;
        yield return new WaitForSeconds(2f);
        playerController2.enabled = true;
        StopAllCoroutines();
    }
}
