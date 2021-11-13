using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestFollowPlayer : MonoBehaviour
{
    public Player player;
    public float velocity;

    public float distance;
    public int thisEnemyDrop;
    public AudioSource audioSource;


    void Start()
    {
        player = GameManager.instance.player;
    }


    public void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z), velocity*Time.deltaTime);
        }
    }

    private void Update()
    {
         distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 0.7f)
        {
            GameManager.instance.audioManager.PlaySound("animepop");
            player.minionsKilled += thisEnemyDrop;
            player.CambiaTestoAnime();

            Destroy(this.gameObject);
        }

    }

}
