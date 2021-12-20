﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class PlayerWalkState : PlayerBaseState
{
    public Player playerScript;

    public CinemachineVirtualCamera vcam;
    public float startOrtho;

    public Collider spadaCollider;

    public override void EnterState(PlayerStateManager player)
    {
        if (playerScript.powerUpSpada == false)
        {
            playerScript.attaccoFisico = playerScript.attaccoFisicoDefault;

        } else { playerScript.attaccoFisico = playerScript.attaccoSpadaPotenziato; }

        Debug.Log("CIAO A TUTTI DALLO STATE INIZIALE!");

        Animator anim = player.GetComponent<Animator>();
        anim.SetBool("cammina", true);
        anim.SetBool("idle", false);
        anim.SetBool("attacca", false);
        anim.SetBool("attacca2", false);
        anim.SetBool("attacca3", false);
        anim.SetBool("damage", false);

        startOrtho = vcam.m_Lens.OrthographicSize;

        //StartCoroutine(ShowCurrentClipLength(anim)); ///

        Debug.Log("tempo2 " + anim.GetCurrentAnimatorStateInfo(0).length);

    }

    public override void onCollisionEnter(PlayerStateManager player)
    {
        throw new System.NotImplementedException();
       

    }

    public override void UpdateState(PlayerStateManager player)
    {
        spadaCollider.enabled = false;

        if (vcam.m_Lens.OrthographicSize != startOrtho)
        {
            vcam.m_Lens.OrthographicSize = Mathf.MoveTowards(vcam.m_Lens.OrthographicSize, startOrtho, 10 * Time.deltaTime);

        }

        if (Input.GetMouseButtonDown(0)) //AGGIUNTO ADESSO
        {
            player.SwitchState(player.attackState); 
        }

        PlayerMove playerMove = GetComponent<PlayerMove>();
        //Debug.Log("ANGIOVI"+Input.GetAxis("Horizontal"));
        if (playerMove.siMuove==false)
        {
            player.SwitchState(player.idleState);
        }


    }

    IEnumerator ShowCurrentClipLength(Animator anim)
    {
        yield return new WaitForEndOfFrame();
        print("current clip length = " + anim.GetCurrentAnimatorStateInfo(0).length);
    }


}
