using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("EnemyHit"))
        {
            other.transform.parent.GetComponent<Enemy>().TakeDamage(5);

        }

    }

}
