using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpendiAnime : MonoBehaviour
{
    Player player;

    //Text buttonText;

    public void UseMinionsPoints(int amount) ///aggiunto oggi
    {
        amount = GameManager.instance.diffDifficile;
        player.minionsKilled -= amount;

    }

    public void IncrementaDifficiolta()
    {
        if( player.minionsKilled >= GameManager.instance.diffDifficile && player.livelloDifficolta == "Normale")
        {
            UseMinionsPoints(GameManager.instance.diffDifficile);
            player.livelloDifficolta = "Difficile";

        }

        else if (player.minionsKilled >= GameManager.instance.diffFolle && player.livelloDifficolta != "Folle" && player.livelloDifficolta == "Difficile" )
        {
            UseMinionsPoints(GameManager.instance.diffFolle);
            player.livelloDifficolta = "Folle";

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
