using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2State : PlayerBaseState
{
    public int cambia;
   // public Rigidbody checkerRb;

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("SUPERMEGAPORCODIO");

        cambia = 1;

        Animator anim = player.GetComponent<Animator>();

        anim.SetBool("attacca", true);
        anim.SetBool("attacca2", true);
        anim.SetBool("idle", false);
        anim.SetBool("cammina", false);
      
       
    }

    public override void onCollisionEnter(PlayerStateManager player)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        Debug.Log("ATTACCO 2");
        Debug.Log("CAMBIALO2 " + cambia);

        //Debug.Log("rb " + checkerRb.velocity.magnitude);

        Animator anim = player.GetComponent<Animator>();
        if (Input.GetMouseButtonDown(0) /* && anim.GetBool("attacca") == true && anim.GetBool("attacca2") == true*/)
        {
            // anim.SetBool("attacca2", true);
            player.SwitchState(player.attack3State);
        }

        if (cambia == 0 /*|| checkerRb.velocity.magnitude != 0*/)
        {
            player.SwitchState(player.idleState);

        }

        if (anim.GetBool("cammina"))
        {
            player.SwitchState(player.walkState);
        }
    }

    public void Cambia2(int _cambia) //da cambiare con una stringa, è un animaton event
    {
        cambia = _cambia;
  
    }

}
