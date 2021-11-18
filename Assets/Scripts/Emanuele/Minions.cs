using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Minions : Enemy
{
    Player player;

    public NavMeshAgent _agent;
    public float enemyDistanceRun=default;
    public GameObject playerTransform;

    Rigidbody _rb;

    public Vector3 newPos;

    void Start()
    {
        // playerTransform = GameObject.FindGameObjectWithTag("Player");///

        playerTransform = GameManager.instance.player.transform.gameObject;

        player = GameManager.instance.player;

        newPos = transform.position;

        _agent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
    }

    public override void KillEnemy()
    {
        GameManager.instance.audioManager.PlaySound("minion_morte");

        player.Health+=1;
        player.hpbar.SetHealth(player.Health);

        base.KillEnemy();
    }
}
