using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerIdleState : PlayerBaseState
{
    public CinemachineVirtualCamera vcam;
    public float startOrtho;

    public Player playerScript;

    public Collider spadaCollider;

    public GameObject scintille1;



    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("CIAO A TUTTI DALLO STATE INIZIALE!");

        spadaCollider.enabled = false;

        Animator anim = player.GetComponent<Animator>();
        anim.SetBool("idle", true);
        anim.SetBool("cammina", false);
        anim.SetBool("attacca", false); 
        anim.SetBool("attacca2", false);
        anim.SetBool("attacca3", false);
        anim.SetBool("damage", false);

        startOrtho = vcam.m_Lens.OrthographicSize;


    }

    public override void onCollisionEnter(PlayerStateManager player)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        /*
        if(vcam.m_Lens.OrthographicSize < 12)
            vcam.m_Lens.OrthographicSize = Mathf.MoveTowards(vcam.m_Lens.OrthographicSize, 12, 10 * Time.deltaTime);
        */

        //scintille1.SetActive(false) ;

        if(vcam.m_Lens.OrthographicSize != 8 )
        {
            vcam.m_Lens.OrthographicSize = Mathf.MoveTowards(vcam.m_Lens.OrthographicSize, 8, 10 * Time.deltaTime);
            
        }

        Animator anim = player.GetComponent<Animator>();
        anim.SetBool("idle", true);
        anim.SetBool("cammina", false);
        anim.SetBool("attacca", false);
        anim.SetBool("attacca2", false);
        anim.SetBool("attacca3", false);
        anim.SetBool("castaspell", false);
        anim.SetBool("damage", false);

        PlayerMove playerMove = GetComponent<PlayerMove>();

        if (Input.GetMouseButtonDown(1))
        {
            player.SwitchState(player.castState);
        }

        if (Input.GetMouseButtonDown(0) && anim.GetBool("attacca") == false)
        {
            GameManager.instance.audioManager.PlaySound("colpospada1");

            player.SwitchState(player.attackState);
        }
        
        
        if (playerMove.siMuove == true)
        {
            player.SwitchState(player.walkState);
        }

        if (playerScript.colpito == true)
        {
            GameManager.instance.audioManager.PlaySound("playerhit");
            player.SwitchState(player.takeDamage);
        }

    }

   

}
