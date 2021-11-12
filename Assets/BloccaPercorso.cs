using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloccaPercorso : MonoBehaviour
{
    //ormai non possiamo più cambiare l'impostazione del prefab del goblin, quindi mettimo i nodi della path che deve seguire
    //nello stesso prefab del goblin e blocchiamo con questo piccolo script la loro posizione. cosi evitiamo di riempire la mappa
    //di nodi o di cambiare il funzionamento del prefab
    public Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos;
    }
}
