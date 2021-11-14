using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class PlayerCastState : PlayerBaseState
{
    public Player playerScript;
    public PlayerMove playerMove;

    public Collider spadaCollider;

    //per la camera
    public CinemachineVirtualCamera vcam;
    public float startOrtho;

    //variabili per animation events
    public int cambia;
    public int prespell;
    //per caricare il colpo di prespell una sola volta
    bool doOnce;

    public override void EnterState(PlayerStateManager player)
    {
        cambia = 0;
        prespell = 0;
        doOnce = true;

        Animator anim = player.GetComponent<Animator>();

        anim.SetBool("castaspell", true);
        anim.SetBool("idle", false);
        anim.SetBool("cammina", false);
        anim.SetBool("attacca2", false); 
        anim.SetBool("attacca3", false);
        anim.SetBool("attacca", false);
        anim.SetBool("damage", false);

        startOrtho = vcam.m_Lens.OrthographicSize;

    }

    public override void onCollisionEnter(PlayerStateManager player)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (vcam.m_Lens.OrthographicSize != 8)
        {
            vcam.m_Lens.OrthographicSize = Mathf.MoveTowards(vcam.m_Lens.OrthographicSize, 8, 10 * Time.deltaTime);

        }

        spadaCollider.enabled = false;

        if (prespell==1 && doOnce)
        {
            GameObject preSpell = Instantiate(playerScript.preSpellPrefab, playerScript.spellSpawnPoint.transform.position, Quaternion.identity);
            doOnce = false;
        }

        if (cambia==1)
        {
            playerScript.CastSpell();
            player.SwitchState(player.idleState);
        }
       
        

        if (playerMove.siMuove)
        {
            player.SwitchState(player.walkState);
        }

    }

   public void FineAnimazione(int _cambia)
    {
        cambia = _cambia;
    }

    public void PreSpell(int _prespell)
    {
        prespell = _prespell;
    }

}
