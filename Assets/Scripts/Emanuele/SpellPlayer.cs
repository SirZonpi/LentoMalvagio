using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellPlayer : MonoBehaviour
{
    Player player;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("EnemyHit"))
        {
            other.transform.parent.GetComponent<Enemy>().TakeDamage(player.attaccoMagico);

        }
        else if (other.CompareTag("Ostacolo"))
        {
            Destroy(this.gameObject);
        }

    }

    private void Start()
    {
        player = GameManager.instance.player;
    }

}
