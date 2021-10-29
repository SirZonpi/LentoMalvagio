using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public int cambia ;
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

        Animator anim = player.GetComponent<Animator>();
        if (Input.GetKeyDown(KeyCode.M)  && anim.GetBool("attacca")==true )
        {

            // anim.SetBool("attacca2", true);
            player.SwitchState(player.attack2State);
        }
 
        if (cambia == 0 && anim.GetBool("attacca2") == false)
        {
            

            player.SwitchState(player.idleState);

        }
        
        
    }

    public void Cambia1(int _cambia) //da cambiare con una stringa, è un animaton event
    {
        cambia = _cambia;

       // Debug.Log("attacco cambia " + cambia);
    }
 

}
