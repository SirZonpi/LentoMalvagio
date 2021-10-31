using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attivatore : MonoBehaviour
{
    //Roberto
    public bool openDoor;



    private void Start()
    {

    }

    void Update()
    {
            
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E)) //se sono nel cerchio CanTakeTheKey e premo E
        {
            openDoor = true; //setto KeyTaken a true
        }
    }
}
