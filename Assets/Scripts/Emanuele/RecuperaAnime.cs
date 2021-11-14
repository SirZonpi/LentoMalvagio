using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecuperaAnime : MonoBehaviour
{
    public static int animeDaRecuperare;
    Player player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.audioManager.PlaySound("animerecuperate");
             player.minionsKilled = animeDaRecuperare;
             player.CambiaTestoAnime();
             Debug.Log("minions " + player.minionsKilled);
             Destroy(this.gameObject, 1.5f);

          
        }
    }

    void Awake()
    {
        player = GameManager.instance.player;
    }


}
