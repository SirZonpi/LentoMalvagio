using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public int cambia ;
    public Collider spadaCollider;
   // public Rigidbody checkerRb;

    public override void EnterState(PlayerStateManager player)
    {
        cambia = 1;

        Debug.Log("DIOMERDA" + cambia);

        Animator anim = player.GetComponent<Animator>();
        anim.SetBool("idle", false);
        anim.SetBool("cammina", false);
        //anim.SetBool("attacca2", false);
        anim.SetBool("attacca", true);
    }

    public override void onCollisionEnter(PlayerStateManager player)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        Debug.Log("ATTACCO 1");
        Debug.Log("CAMBIALO " + cambia);



        Animator anim = player.GetComponent<Animator>();

        if (Input.GetMouseButtonDown(0) && anim.GetBool("attacca")==true && cambia == 1)
        {

            // anim.SetBool("attacca2", true);
            Debug.Log("CAMBIALO " + cambia);
            player.SwitchState(player.attack2State);


         //   Debug.Log("LOSTATODELLAMERDA " + player.attack2State);

        }

        if (cambia == 0 /*|| checkerRb.velocity.magnitude != 0*/)
        {
            player.SwitchState(player.idleState);

        }

       

    }

    public void Cambia1(int _cambia) //da cambiare con una stringa, è un animaton event
    {
        cambia = _cambia;

       // Debug.Log("attacco cambia " + cambia);
    }
    

    public void AttivaSpada()
    {
        spadaCollider.enabled = true;
        
    }



}
