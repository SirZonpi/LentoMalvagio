using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpadaScript : MonoBehaviour
{
    public PlayerStateManager playerState;
    public Player player;

    public GameObject scintille1;
    public GameObject scintille2;

    public GameObject testoHitPrefab;

    Quaternion rotazione;
    Vector3 pos;

    private void Start()
    {
        rotazione = new Quaternion(0, 45, 0, 90);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("EnemyHit"))
        {
            if (playerState.currentPlayerState == playerState.attackState)
            {
                GameObject testo = Instantiate(testoHitPrefab, transform.position + Vector3.up, rotazione,null);
                testo.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("hit!");

                StartCoroutine(ScintileCo());
            }
             if (playerState.currentPlayerState == playerState.attack2State)
            {
                GameObject testo = Instantiate(testoHitPrefab, transform.position + Vector3.up , rotazione, null);
                testo.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("+2!");

                StartCoroutine(Scintile2Co());
            }

            if (playerState.currentPlayerState == playerState.attack3State)
            {
                GameObject testo = Instantiate(testoHitPrefab, transform.position + Vector3.up , rotazione, null);
                testo.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("+4!");

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
