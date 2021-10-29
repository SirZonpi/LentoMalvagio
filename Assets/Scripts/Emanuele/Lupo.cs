using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 

public class Lupo : Enemy
{
    public GameObject playerTransform;

    public float attackRadius = default;

    public float timer;
    public float nextTime = default;
    public bool inRange;

    public NavMeshAgent _agent;

    public bool loadSpell;

    public GameObject bulletPrefab;
    public GameObject spellSpawnPoint;

    Vector3 dir;

    [SerializeField] float enemyDistance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CastSpell()
    {
        GameObject bulletSpell = Instantiate(bulletPrefab, spellSpawnPoint.transform.position, Quaternion.identity) as GameObject;
        bulletSpell.transform.SetParent(null);
        LupoBullet lb = bulletSpell.GetComponent<LupoBullet>();
        dir = (transform.forward);
        if (bulletPrefab != null)
            //lb.Setup(dir);
            StartCoroutine(lb.ScaleBullet(dir));
    }

    float time = 0f;
    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, playerTransform.transform.position);
        Debug.Log("distance " + distance);


        if (distance <= attackRadius && distance>=2)
        {
            loadSpell = true;

            Vector3 direction = playerTransform.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10);

        }
        else { loadSpell = false; }

        if (loadSpell)
        {

         
            Debug.Log("TTTTT " + time);

            if (time <= 4f)
            {
                time += Time.deltaTime;
                if (time >= 4f)
                {
                    CastSpell();
                    time = 0f;
                }
           
            }
        }

        if ( distance <= attackRadius)
        {
           
        }
            //else { return; }


        }
}
