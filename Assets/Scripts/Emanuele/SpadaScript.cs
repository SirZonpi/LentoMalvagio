using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpadaScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("EnemyHit"))
        {
            other.transform.parent.GetComponent<Enemy>().TakeDamage(5);

        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
