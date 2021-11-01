using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpendiAnime : MonoBehaviour
{
    Player player;

    public void UseMinionsPoints(int amount) ///aggiunto oggi
    {
        amount = GameManager.instance.diffDifficile;
        player.minionsKilled -= amount;

    }

    public void IncrementaDifficiolta()
    {
        if( player.minionsKilled >= GameManager.instance.diffDifficile)
        {
            UseMinionsPoints(GameManager.instance.diffDifficile);
            player.livelloDifficolta = "Difficile";

        }
    }


    void Start()
    {
        player = GameManager.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
