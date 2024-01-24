using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField] private CharacterData character;

    private GameObject skin;
    private GameObject handgunWeapon;
    private GameObject meeleWeapon;

    private void Start()
    {
        skin = character._skin;
        handgunWeapon = character._handgunWeapon;
        meeleWeapon = character._meeleWeapon;

        Instantiate(skin);
    }
}
