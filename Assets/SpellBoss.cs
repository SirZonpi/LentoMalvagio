using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBoss : MonoBehaviour
{
    Player player;
    Rigidbody rb;

    void Start()
    {
        player = GameManager.instance.player;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
       rb.velocity = (player.transform.position - transform.position).normalized * 2;
    }
}
