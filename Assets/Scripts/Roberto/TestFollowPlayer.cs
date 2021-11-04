using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFollowPlayer : MonoBehaviour
{
    public Player Giocatore;
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(Giocatore.transform.position.x, Giocatore.transform.position.y + 0.5f, Giocatore.transform.position.z), velocity*Time.deltaTime);
        }
    }
}
