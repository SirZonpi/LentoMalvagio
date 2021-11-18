using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiudiPorta : MonoBehaviour
{
    public GameObject porta;
    public Animator anim;

    public Attivatore att;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            att.openDoor = false;
            anim.SetTrigger("trigger");
        }
    }

   
}
