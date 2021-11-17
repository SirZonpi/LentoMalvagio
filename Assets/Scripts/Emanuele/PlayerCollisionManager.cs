using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    [SerializeField]Player player;

    bool doOnce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trappola") )
        {
            player.TakeDamage(2);
          
        }
        
        if (other.CompareTag("EnemyAttack"))
        {
            //Debug.Log("UNAHIT");

            if (other.gameObject.transform.root.GetComponent<Enemy>())
            {
                Enemy enemy = other.gameObject.transform.root.GetComponent<Enemy>();
                player.TakeDamage(enemy.attaccoFisico);
            }

        }
        else if (other.CompareTag("SpellFatina"))
        {
            FatinaBullet fb = other.GetComponent<FatinaBullet>();
            player.TakeDamage(fb.attacco);

        }

        else if (other.CompareTag("SpellLupo"))
        {
            LupoBullet lp = other.GetComponent<LupoBullet>();
            player.TakeDamage(lp.attacco);

        }


    }



}
