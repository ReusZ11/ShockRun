
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Transform playerPos;
    public GameObject player;
    public float radius;
    private float Timer = 2;

    [SerializeField] private GameObject waveParticleObject;
    [SerializeField] private GameObject waveParticleCollision;
    [SerializeField] private GameObject waveParticleForObstacle;



    private GameObject newInstance;
    private GameObject newInstanceCollision;
    private GameObject newInstanceForObstacle;

    private Animator anim;

    private bool AttackAnim = false;


    void Start()
    {

        anim = GetComponent<Animator>();
    }




    void FixedUpdate()
    {
        Timer -= 1 * Time.deltaTime;
        if (Timer <= 0)
        {
            Attack();
            Timer = 7;


        }
        else
            AttackAnim = false;




        if (AttackAnim == false)
        {
            AttackAnim = false;
            anim.SetBool("isAttack", false);
            anim.SetBool("Idle", true);
        }





    }


    private void Attack()
    {
        anim.SetBool("isAttack", true);

        anim.SetBool("Idle", false);

        ShockWaveExplosion();
        AttackAnim = true;
    }


    public void Death()
    {

        waveParticleObject.SetActive(false);
        waveParticleCollision.SetActive(false);
        waveParticleForObstacle.SetActive(false);
        anim.SetBool("isDie", true);
        anim.SetBool("Idle", false);
        anim.SetBool("isAttack", false);


    }



    private void ShockWaveExplosion()
    {
        newInstance = Instantiate(waveParticleObject, transform.position, transform.rotation); //collision
        newInstanceCollision = Instantiate(waveParticleCollision, transform.position, transform.rotation); // NotColission
        newInstanceForObstacle = Instantiate(waveParticleForObstacle, transform.position, transform.rotation); // NotColission

        Destroy(newInstance,6f);
        Destroy(newInstanceCollision,6f);
        Destroy(newInstanceForObstacle, 6f);

    }



}
