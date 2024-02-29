using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject panelInicio;
    [SerializeField] private GameObject panelModos;
    [SerializeField] private GameObject panelSetings;

    private void Start()
    {
        panelInicio.SetActive(true);
        panelModos.SetActive(false);
        panelSetings.SetActive(false);
    }

    public void GoToModos()
    {
        panelModos.SetActive(true);
        panelSetings.SetActive(false);
        panelInicio.SetActive(false);
    }

    public void GoToInicio()
    {
        panelInicio.SetActive(true);
        panelModos.SetActive(false);
        panelSetings.SetActive(false);
    }

    public void GoToSetings()
    {
        panelSetings.SetActive(true);
        panelModos.SetActive(false);
        panelInicio.SetActive(false);
    }

    public void ModoEnfrentamiento()
    {
        SceneManager.LoadScene("ANDY");
    }


}
