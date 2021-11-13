using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpadaScript : MonoBehaviour
{
    public PlayerStateManager playerState;
    public Player player;

    public GameObject scintille1;
    public GameObject scintille2;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("EnemyHit"))
        {
            if (playerState.currentPlayerState == playerState.attackState)
            {
                StartCoroutine(ScintileCo());
            }
             if (playerState.currentPlayerState == playerState.attack2State)
            {
                Debug.Log("DIOEBREO");
                StartCoroutine(Scintile2Co());
            }
            other.transform.parent.GetComponent<Enemy>().TakeDamage(player.attaccoFisico);

        }

    }

    public IEnumerator ScintileCo()
    {
            scintille1.SetActive(true);
            yield return new WaitForSeconds(.5f);
            scintille1.SetActive(false);
            yield return null;
       
    }
    public IEnumerator Scintile2Co()
    {
        scintille2.SetActive(true);
        yield return new WaitForSeconds(.5f);
        scintille2.SetActive(false);
        yield return null;

    }

}
