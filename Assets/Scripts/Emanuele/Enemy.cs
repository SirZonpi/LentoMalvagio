using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //per usare le action

public class Enemy : Entity
{
    public int animeDrop;
    public GameObject animeDropPrefab;


    Player player;

    //override dei metodi della classe base Entity
    public override void KillEnemy()
    {
        Debug.Log("Un nemico è stato ucciso");

        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        GameObject animeDropped = Instantiate(animeDropPrefab, spawnPos, Quaternion.identity,null) as GameObject;

        animeDropped.SetActive(true);
        animeDropped.GetComponent<TestFollowPlayer>().thisEnemyDrop = animeDrop;

        //animeDropPrefab.GetComponent<TestFollowPlayer>().thisEnemyDrop = animeDrop;
        //animeDropPrefab.SetActive(true);
        //animeDropPrefab.transform.SetParent(null);
       
        base.KillEnemy();

        transform.position = startPosition;

    }

    IEnumerator EnemyHitted()
    {
        enemyHitted = true;
        yield return new WaitForSeconds(2);
        enemyHitted = false;
        yield return null;
    }

    public override void TakeDamage(int amount)
    {
        Debug.Log("Un nemico ha preso danno");
        StartCoroutine(EnemyHitted());
        base.TakeDamage(amount);
    }

    // Start is called before the first frame update
    void Awake()
    {
        // animeDropPrefab.SetActive(false);
        startPosition = transform.position;

        player = GameManager.instance.player; //////////

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(5);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            animeDropPrefab.SetActive(true);

        }

        if (player.Health <= 0)
        {
            this.RestoreHealth();
            //OnHealthChanged(maxHealth);
        }

    }
}
