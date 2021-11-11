using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public int animeDrop;
    public GameObject animeDropPrefab; ////

    //override dei metodi della classe base Entity
    public override void KillEnemy()
    {
        Debug.Log("Un nemico è stato ucciso");
        //GameObject animeDroppate = Instantiate(animeDropPrefab, transform.position, Quaternion.identity); ////
        animeDropPrefab.GetComponent<TestFollowPlayer>().thisEnemyDrop = animeDrop;
        animeDropPrefab.SetActive(true);
        animeDropPrefab.transform.SetParent(null);


        base.KillEnemy();
    }

    public override void TakeDamage(int amount)
    {
        Debug.Log("Un nemico ha preso danno");
        base.TakeDamage(amount);
    }

    // Start is called before the first frame update
    void Awake()
    {
       // animeDropPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(5);
        }
    }
}
