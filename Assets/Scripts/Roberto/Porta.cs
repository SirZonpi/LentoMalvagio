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
    public Animator door;
    private void Update()
    {
        
         if (attDaAttivare.openDoor == true) //e sono dentro isInRange e ho preso la chiave assegnata.
         {
            attivatore.GetComponent<MeshRenderer>().material = attivatoreAttivo;
            door.SetBool("apriPorta", true);
         }
        else
            door.SetBool("apriPorta", false);



    }

}
