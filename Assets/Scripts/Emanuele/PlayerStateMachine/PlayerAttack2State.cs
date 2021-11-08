using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2State : PlayerBaseState
{
    public int cambia;
    public int vaAdAttacco3 = 0;
    // public Rigidbody checkerRb;

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("SUPERMEGAPORCODIO");

        cambia = 1;
        vaAdAttacco3 = 0;

        Animator anim = player.GetComponent<Animator>();

        anim.SetBool("attacca", true);
        anim.SetBool("attacca2", true);
        anim.SetBool("idle", false);
        anim.SetBool("cammina", false);
        anim.SetBool("castaspell", false);



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

        PlayerMove playerMove = GetComponent<PlayerMove>();

        Animator anim = player.GetComponent<Animator>();

        /*
        if (Input.GetMouseButtonDown(0)   && anim.GetBool("attacca") == true && anim.GetBool("attacca2") == true )
        {
            // anim.SetBool("attacca2", true);
            player.SwitchState(player.attack3State);
        }
        */

        if (cambia == 0 /*|| checkerRb.velocity.magnitude != 0*/)
        {
            player.SwitchState(player.idleState);

        }


        if (Input.GetMouseButtonDown(0) && vaAdAttacco3 == 1)
        {
            player.SwitchState(player.attack3State);
        }

        if (playerMove.siMuove == true)
        {
            player.SwitchState(player.walkState);
        }
    }

    public void Cambia2(int _cambia) //da cambiare con una stringa, è un animaton event
    {
        cambia = _cambia;
  
    }

    public void VaAdAttacco3(int _vaAdAttacco3)
    {
        vaAdAttacco3 = _vaAdAttacco3;
    }

}
