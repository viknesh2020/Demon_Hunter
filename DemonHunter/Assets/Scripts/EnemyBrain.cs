using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class EnemyBrain : MonoBehaviour
{

    [Header("General Settings")]

    public float enemySpeed;
    public float enemyHealth;
    public Transform Player;
    public bool enemyIsAlive;

    [Header("Attack Range Settings")]
    public float stage1Distance;
    public float stage2Distance;
    public float stage3Distance;
    public float currentDistance;

    [Header("Damage Settings")]
    public GameObject damageEffect1;
    public GameObject damageEffect2;
    public PlayerBrain playerBrain;

    [Header("UI Settings")]

    [Header("Audio Settings")]
    public AudioSource enemyAudioSource;
    public AudioClip[] enemyAudioClips;
    
   // [Header("Enemy Organs")]

   [HideInInspector]
    public Animator enemyAnimator;
    public Transform enemyTransform;

    public void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyTransform = this.gameObject.transform;
        enemyIsAlive = true;
    }

    public void Update()
    {

        currentDistance = Vector3.Distance(enemyTransform.position, Player.position);
        Debug.Log("Distance between Enemy and Player:" + currentDistance);

        if (currentDistance <= stage3Distance) {

           // playerBrain.LevelThreeDamage();
        }
        else if (currentDistance <= stage2Distance && currentDistance > stage3Distance) {

            playerBrain.LevelTwoDamage();
        }
        else if (currentDistance <= stage1Distance && currentDistance > stage2Distance) {

            playerBrain.LevelOneDamage();
        }
        else {

            EnemyCalmMode();
        }
    }

    public void EnemyCalmMode() {



    }
}
