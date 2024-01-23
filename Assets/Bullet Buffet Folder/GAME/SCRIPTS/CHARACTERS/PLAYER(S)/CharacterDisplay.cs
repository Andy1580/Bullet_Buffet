using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
    public Character character;

    private GameObject skin;
    public GameObject handgunWeapon;
    public GameObject meeleWeapon;

    private void Start()
    {
        skin = character._skin;
        handgunWeapon = character._handgunWeapon;
        meeleWeapon = character._meeleWeapon;

        Instantiate(skin);
    }
}
