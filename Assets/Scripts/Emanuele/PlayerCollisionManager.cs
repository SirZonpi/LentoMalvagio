using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    [SerializeField]Player player;

    public bool doOnce;

    private void OnTriggerEnter(Collider other)
    {
        doOnce = false;

        if (other.CompareTag("Trappola") )
        {
            player.TakeDamage(2);
          
        }
        
        if (other.CompareTag("EnemyAttack") && doOnce==false)
        {
            Debug.Log("UNAHIT");

            if (other.gameObject.transform.root.GetComponent<Enemy>())
            {
                doOnce = true;

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

        else if (other.CompareTag("Spellboss"))
        {
            SpellBoss sb = other.GetComponent<SpellBoss>();
            player.TakeDamage(sb.attacco);

        }


    }



}
