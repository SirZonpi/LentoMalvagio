using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerTakeDamageState : PlayerBaseState
{
    public Player playerScript;

    public Collider spadaCollider;

    public CinemachineVirtualCamera vcam;
    public float startOrtho;


    public override void EnterState(PlayerStateManager player)
    {
        spadaCollider.enabled = false;

        Debug.Log("LAMADONNA");
        Animator anim = player.GetComponent<Animator>();
        anim.SetBool("idle", false);
        anim.SetBool("cammina", false);
        anim.SetBool("attacca", false);
        anim.SetBool("attacca2", false);
        anim.SetBool("attacca3", false);
        anim.SetBool("damage", true);

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

        // transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Lerp(transform.localPosition.z, transform.localPosition.z-1,1));
        playerScript.StartCoroutine(playerScript.PlayerHittedCo());
        playerScript.colpito = false;
        player.SwitchState(player.idleState);

    }


}
