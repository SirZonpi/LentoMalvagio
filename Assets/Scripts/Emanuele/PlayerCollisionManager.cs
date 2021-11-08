using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    [SerializeField]Player player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trappola") || other.CompareTag("EnemyAttack"))
        {
            player.TakeDamage(2);
        }
    }

    private void Start()
    {
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
