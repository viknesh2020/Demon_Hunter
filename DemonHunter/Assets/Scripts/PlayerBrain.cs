using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBrain : MonoBehaviour
{

    public float playerHealth;
    public float playerStartHealth;
    public Image healthBar;
    public bool playerIsAlive;

    public float levelOneDamage;
    public float levelTwoDamage;
    public float levelThreeDamage;

    void Start()
    {
        playerIsAlive = true;
        playerHealth = playerStartHealth;
    }

    void Update()
    {
        healthBar.fillAmount = playerHealth / playerStartHealth;
    }

    public void LevelOneDamage() {

        playerHealth -= levelOneDamage;       

    }

    public void LevelTwoDamage()
    {
        playerHealth -= levelTwoDamage;

    }

    //public void LevelThreeDamage()
    //{

    //    playerHealth -= levelThreeDamage;
    //}
}
