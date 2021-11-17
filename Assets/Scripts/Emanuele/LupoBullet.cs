using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LupoBullet : MonoBehaviour
{
    GameObject playerTransform;
    Vector3 direzione;
    public Rigidbody rb;
    float speed = 25f;

    public int attacco;

    Vector3 bulletTargetScale = new Vector3(1, 1, 1);

    LupoStateManager lpm;

    public void Setup(Vector3 shootDir)
    {
        direzione = shootDir;

        //rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;

        rb.velocity = new Vector2(0, 0);

        rb.AddForce(shootDir * speed, ForceMode.Impulse);

    }


    public IEnumerator ScaleBullet(Vector3 _dir)
    {
        rb.isKinematic = true;

        float elapsedTime = 0f;
        float waitTime = 2;

        while (elapsedTime < waitTime)
        {
           

            if(lpm.currentLupoState!= lpm.attackState)
            {
                
                Destroy(this.gameObject);
               // this.enabled = false;
                break;
            }
            else
            {
                elapsedTime += Time.deltaTime;
                transform.localScale = Vector3.Lerp(transform.localScale, bulletTargetScale, elapsedTime / waitTime);
            }

            yield return null;

        }
        Setup(_dir);

        yield return null;

    }

    IEnumerator disattiva()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
        yield return null;
    }

    private void OnEnable()
    {
        lpm = transform.parent.GetComponent<LupoStateManager>(); ///
       // StartCoroutine(ScaleBullet());
        StartCoroutine(disattiva());
    }

    private void Awake()
    {
        //playerTransform = GameObject.FindGameObjectWithTag("Player");
        playerTransform = GameManager.instance.player.transform.gameObject;

    }


    // Start is called before the first frame update
    void Start()
    {
     
    }


    void Update()
    {
        

    }
}
