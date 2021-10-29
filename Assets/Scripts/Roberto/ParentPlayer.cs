using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) //Se il giocatore sale su una piattaforma semovente, viene imparentato alla piattaforma così viene trasportato.
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
        
    }
    private void OnTriggerExit(Collider collision)//appena scende viene sparentato
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
       

    }
}
