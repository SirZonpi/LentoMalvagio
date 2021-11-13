using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpada : MonoBehaviour
{
    bool doOnce = true;
    [SerializeField] MeleeUI iconaSpada;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && doOnce)
        {
            doOnce = false;
            Player player = GameManager.instance.player;
            GameManager.instance.audioManager.PlaySound("powerup");
            player.StartCoroutine(player.SpadaInfuocata()); //diabolico
            //StartCoroutine(player.SpadaInfuocata());
       
            GameManager.instance.oggettidaDisattivare.Add(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

}
