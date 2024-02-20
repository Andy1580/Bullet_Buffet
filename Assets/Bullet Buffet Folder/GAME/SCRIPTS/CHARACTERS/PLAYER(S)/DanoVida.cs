using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoVida : MonoBehaviour
{
  public int damage;
    public float invulnerabilityDuration = 1.5f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vida vida = other.GetComponent<Vida>();
            if (vida != null && !vida.isInvulnerable) 
            {
                vida.salud -= damage;
                vida.StartCoroutine(ActivateInvulnerability(vida)); 
                gameObject.SetActive(false);
            }
        }
    }

    IEnumerator ActivateInvulnerability(Vida vida)
    {
        vida.isInvulnerable = true; 
        yield return new WaitForSeconds(invulnerabilityDuration);
        vida.isInvulnerable = false; 
    }
}
