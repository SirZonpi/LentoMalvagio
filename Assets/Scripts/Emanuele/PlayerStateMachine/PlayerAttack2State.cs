using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerAttack2State : PlayerBaseState
{
    public Player playerScript;

    public int cambia;
    public int vaAdAttacco3 = 0;

    public Collider spadaCollider;

    public CinemachineVirtualCamera vcam;
    public float startOrtho;

    public  PlayerAttackState attacco1;//
    

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("ATTACCO2"); 

        playerScript.attaccoFisico += 2;

        //attacco1.cambia = 0;//

        cambia = 1;
        vaAdAttacco3 = 0;

        Animator anim = player.GetComponent<Animator>();

        anim.SetBool("attacca", true);
        anim.SetBool("attacca2", true);
        anim.SetBool("idle", false);
        anim.SetBool("cammina", false);
        anim.SetBool("castaspell", false);
        anim.SetBool("damage", false);

        startOrtho = vcam.m_Lens.OrthographicSize;

        StartCoroutine(ShowCurrentClipLength(anim)); ///

    }

    public override void onCollisionEnter(PlayerStateManager player)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (vcam.m_Lens.OrthographicSize != startOrtho)
        {
            vcam.m_Lens.OrthographicSize = Mathf.MoveTowards(vcam.m_Lens.OrthographicSize, startOrtho, 10 * Time.deltaTime);

        }

        Debug.Log("ATTACCO 2");
        Debug.Log("CAMBIALO2 " + cambia);

        spadaCollider.enabled = true;

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
            GameManager.instance.audioManager.PlaySound("colpospada3");

            player.SwitchState(player.attack3State);
        }

        if (Input.GetMouseButtonDown(1))
        {
            player.SwitchState(player.castState);
        }


        if (playerMove.siMuove == true)
        {
            attacco1.cambia = 0; ////
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

    IEnumerator ShowCurrentClipLength(Animator anim)
    {
        yield return new WaitForEndOfFrame();
        print("current clip length = " + anim.GetCurrentAnimatorStateInfo(0).length);
    }


}
