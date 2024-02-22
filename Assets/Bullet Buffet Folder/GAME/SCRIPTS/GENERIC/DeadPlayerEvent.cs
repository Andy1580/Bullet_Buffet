using System.Collections;
using UnityEngine;

public class DeadPlayerEvent : MonoBehaviour
{
    private GameObject playerReference1;
    private GameObject playerReference2;

    [SerializeField] private Transform spawn1;
    [SerializeField] private Transform spawn2;

    private GameObject playerATrasladar;

    private Vida vida1;
    private Vida vida2;

    PlayerController pla1;
    PlayerController pla2;

    private void Start()
    {
        playerReference1 = GameObject.FindGameObjectWithTag("Player1");
        playerReference2 = GameObject.FindGameObjectWithTag("Player2");

        vida1 = playerReference1.GetComponent<Vida>();
        vida2 = playerReference2.GetComponent<Vida>();

        pla1 = playerReference1.GetComponent<PlayerController>();
        pla2 = playerReference2.GetComponent<PlayerController>();
    }

    private void Update()
    {
        CheckVida();
    }

    void CheckVida()
    {
        if (vida1 != null && vida2 != null)
        {
            if (vida1.salud <= 0)
            {
                playerATrasladar = playerReference1;
                StartCoroutine(PlayerTranslation());
            }

            else if (vida2.salud <= 0)
            {
                playerATrasladar = playerReference2;
                StartCoroutine(PlayerTranslation());
            }
        }
    }

    void TrasladarPlayer()
    {
        if (playerATrasladar = playerReference1)
        {
            pla1.enabled = false;
            playerReference1.SetActive(false);
            Instantiate(playerATrasladar, spawn1.transform.position, Quaternion.identity);
        }

        else if (playerATrasladar = playerReference2)
        {
            pla2.enabled = false;
            playerReference2.SetActive(false);
            Instantiate(playerATrasladar, spawn2.transform.position, Quaternion.identity);
        }
    }

    IEnumerator PlayerTranslation()
    {
        TrasladarPlayer();
        vida1.salud = 100;
        vida2.salud = 100;
        yield return new WaitForSeconds(3f);
    }
}
