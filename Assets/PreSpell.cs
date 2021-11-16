using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreSpell : MonoBehaviour
{
    PlayerStateManager player;

    private void Start()
    {
        player = GameManager.instance.player.GetComponent<PlayerStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.currentPlayerState != player.castState)
        {
            Destroy(this.gameObject);
        }
    }
}
