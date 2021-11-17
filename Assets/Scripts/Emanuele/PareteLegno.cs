using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PareteLegno : MonoBehaviour
{

    public int hp ;
    int startHp;
 
    private void Start()
    {
        startHp = hp;
    }

    private void OnDisable()
    {
        hp = startHp;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SpadaPlayer") || other.CompareTag("SpellPlayer"))
        {
            hp -= 1;

        }

    }

    private void Update()
    {

        if(hp == 0)
        {
            this.gameObject.SetActive(false);
            GameManager.instance.oggettidaDisattivare.Add(this.gameObject);
        }


    }

}
