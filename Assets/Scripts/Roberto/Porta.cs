using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    //Roberto Niciforo
    public Attivatore attDaAttivare;
    public GameObject porta;
    public GameObject attivatore;
    public Material attivatoreAttivo;
    public Material attivatoreDisattivato;
    public Animator door;


    void SuonoPorta()
    {
        GameManager.instance.audioManager.PlaySound("porta");
    }
    private void Update()
    {
        
         if (attDaAttivare.openDoor == true) //e sono dentro isInRange e ho preso la chiave assegnata.
         {
            attivatore.GetComponent<MeshRenderer>().material = attivatoreAttivo;
            door.SetBool("apriPorta", true);
            door.SetBool("chiudi", false);
            Invoke("SuonoPorta", 1f);
         }

         else if(attDaAttivare.openDoor == false)
         {
            door.SetBool("apriPorta", false);
            door.SetBool("chiudi", true);
            attivatore.GetComponent<MeshRenderer>().material = attivatoreDisattivato;
         }
            




    }

}
