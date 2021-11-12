using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpadaScript : MonoBehaviour
{
    public PlayerStateManager player;
    public GameObject scintille1;
    public GameObject scintille2;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("EnemyHit"))
        {
            if (player.currentPlayerState == player.attackState)
            {
                StartCoroutine(ScintileCo());
            }
             if (player.currentPlayerState == player.attack2State)
            {
                Debug.Log("DIOEBREO");
                StartCoroutine(Scintile2Co());
            }
            other.transform.parent.GetComponent<Enemy>().TakeDamage(5);

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
