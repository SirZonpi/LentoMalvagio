using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2State : PlayerBaseState
{
    public int cambia;
   // public Rigidbody checkerRb;

    public override void EnterState(PlayerStateManager player)
    {
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
        //Debug.Log("rb " + checkerRb.velocity.magnitude);

        Animator anim = player.GetComponent<Animator>();
        if (Input.GetKeyDown(KeyCode.M) /* && anim.GetBool("attacca") == true && anim.GetBool("attacca2") == true*/)
        {
            // anim.SetBool("attacca2", true);
            player.SwitchState(player.attack3State);
        }

        if (cambia == 0 /*|| checkerRb.velocity.magnitude != 0*/)
        {
            player.SwitchState(player.idleState);

        }
    }

    public void Cambia2(int _cambia) //da cambiare con una stringa, è un animaton event
    {
        cambia = _cambia;
  
    }

}
