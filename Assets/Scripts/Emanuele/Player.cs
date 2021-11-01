using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    public int minionsKilled=1000; //1000 per debug
    public string currentLevel;

    public string livelloDifficolta;  ///aggiunto oggi

    void Start()
    {
        if (GameManager.isLoaded == true)
        {
            GameManager.instance.LoadPlayer();

        }
    }

    private void Awake()
    {
        currentLevel = "Scena1";
        livelloDifficolta = "Normale";  ///aggiunto oggi
    }


    

   

    //override dei metodi della classe base Entity
    public override void TakeDamage(int amount)
    {
        Debug.Log("Il player ha subito danno");
        base.TakeDamage(amount);
    }

    IEnumerator IncrementaHpCo()
    {
        float elapseTime = 0;
        float waitTime = 3;
        float tmp = 0;
        while (elapseTime < waitTime)
        {
            elapseTime += Time.deltaTime;
            tmp += Time.deltaTime;

            if (tmp >= 0.2f)
            {
                
                Health++;
                tmp = 0f;
            }

            yield return null;
        }
        yield return null;

    }

    public override void RestoreHealth()
    {
        StartCoroutine(IncrementaHpCo());
    }

    public override void KillEnemy()
    {
        Debug.Log("Il player è stato ucciso");
        base.KillEnemy();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("MAX " + maxHealth);
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(1);
           
        }
    }

    
}
