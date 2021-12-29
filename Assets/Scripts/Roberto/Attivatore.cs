using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attivatore : MonoBehaviour
{
    //Roberto
    public bool openDoor;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpadaPlayer") || other.CompareTag("SpellPlayer")) //se sono nel cerchio CanTakeTheKey e premo E
        {
            openDoor = true; //setto KeyTaken a true
            GameManager.instance.audioManager.PlaySound("interruttore");
        }
    }

    private void Update()
    {
        if (GameManager.instance.player.isDead == true)
        {
            openDoor = false;
        }
    }

}
