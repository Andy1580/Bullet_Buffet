using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public new string name;

    public int health;

    public float meeleAttack;
    public float handgunAttack;
    public float velocity;
    public float dash;

    public GameObject _skin;
    public GameObject _handgunWeapon;
    public GameObject _meeleWeapon;

    public Transform shieldAbility;

}
