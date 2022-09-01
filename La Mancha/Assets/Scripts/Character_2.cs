using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_2 : MonoBehaviour
{
    public string nameCharacter;

    public int velocity;
    public int life;
    public int force;
    public int defense;




    public enum ATTACK_TYPE { NONE, PHYSIC };

    public string nameAttack;
    public string description;
    public ATTACK_TYPE type = ATTACK_TYPE.NONE;
    public int damage;





}