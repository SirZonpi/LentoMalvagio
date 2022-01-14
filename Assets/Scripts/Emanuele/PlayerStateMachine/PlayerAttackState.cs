using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class PlayerAttackState : PlayerBaseState
{
    public Player playerScript;

    public int cambia ;
    public int vaAdAttacco2 = 0;
    public Collider spadaCollider;

    public GameObject textprefab;
    public string textToDisplay;

    public CinemachineVirtualCamera vcam;
    public float startOrtho;

    public GameObject scintille1;

    public Rigidbody rb;
    public float attForce;
    public float attDistance;
    public float frenataAtt;

    public override void EnterState(PlayerStateManager player)
    {
        if (playerScript.powerUpSpada == false)
        {
            playerScript.attaccoFisico = playerScript.attaccoFisicoDefault;

        }
        else { playerScript.attaccoFisico = playerScript.attaccoSpadaPotenziato; }

        cambia = 1;
        vaAdAttacco2 = 0;

        Animator anim = player.GetComponent<Animator>();

        PlayerMove movement = player.GetComponent<PlayerMove>(); //
        movement.enabled = true;

        anim.SetBool("idle", false);
        anim.SetBool("cammina", false);
        anim.SetBool("attacca2", false); //
        anim.SetBool("attacca", true);
        anim.SetBool("castaspell", false);
        anim.SetBool("damage", false);

        startOrtho = vcam.m_Lens.OrthographicSize;


        StartCoroutine(AttDash());

    }

    public override void onCollisionEnter(PlayerStateManager player)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator AttDash() //quando il giocatore attacca fà uno scattino in avanti: vieni applicata una forza in avanti e poi una forza minore nella parte opposta
    {
        rb.velocity = new Vector3(0,0,0); //aggiunta mia
        rb.AddForce(transform.forward * attForce, ForceMode.Impulse);
        yield return new WaitForSeconds(attDistance);
        rb.AddForce(-transform.forward * frenataAtt, ForceMode.Impulse);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (vcam.m_Lens.OrthographicSize != startOrtho)
        {
            vcam.m_Lens.OrthographicSize = Mathf.MoveTowards(vcam.m_Lens.OrthographicSize, startOrtho, 10 * Time.deltaTime);

        }

        Debug.Log("ATTACCO 1");
        Debug.Log("CAMBIALO " + cambia);

        Debug.Log("vaadttacco2  " + vaAdAttacco2);

        PlayerMove playerMove = GetComponent<PlayerMove>();

        Animator anim = player.GetComponent<Animator>();

        if (Input.GetMouseButtonDown(0) && anim.GetBool("attacca")==true && cambia == 1)
        {
            Quaternion rotazione = new Quaternion (0, 45, 0, 90);

            //GameObject testo = Instantiate(textprefab, transform.position, rotazione);
           // testo.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(textToDisplay);

             Debug.Log("CAMBIALO " + cambia);    
           // player.SwitchState(player.attack2State);


         //   Debug.Log("LOSTATOCORRENTE " + player.attack2State);

        }

        if (Input.GetMouseButtonDown(0) && vaAdAttacco2 == 1)
        {
            GameManager.instance.audioManager.PlaySound("colpospada2");

            player.SwitchState(player.attack2State);
        }
       

        if (Input.GetMouseButtonDown(0) && vaAdAttacco2 == 0)
        {
            player.SwitchState(player.attackState);
        }


        if (cambia == 0 )
        {
            player.SwitchState(player.idleState);

        }

        if (Input.GetMouseButtonDown(1) )
        {
            player.SwitchState(player.castState);
        }

         


        /*
        if (playerMove.siMuove == true) //TOLTO DESSO
        {
            player.SwitchState(player.walkState);
        }
        */

    }

    public void Cambia1(int _cambia) //da cambiare con una stringa, è un animaton event
    {
        cambia = _cambia;

       // Debug.Log("attacco cambia " + cambia);
    }



    public void VaAdAttacco2(int _vaAdAttacco2)
    {
        vaAdAttacco2 = _vaAdAttacco2;
    }
    

    public void AttivaSpada()
    {
        spadaCollider.enabled = true;
       // scintille1.SetActive(true);
        
    }

    public void DisattivaSpada()
    {
        spadaCollider.enabled = false;
        //scintille1.SetActive(false);
    }



}
