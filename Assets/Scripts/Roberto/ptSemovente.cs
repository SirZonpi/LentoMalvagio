using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ptSemovente : MonoBehaviour
{
    [SerializeField]
    private float speed; //velocità della piattaforma
    [SerializeField]
    private int startingPoint; //posizione iniziale della piattaforma
    [SerializeField]
    private Transform[] points; //Un array delle posizioni della piattaforma

    private int i;
    private bool test;

    void Start()
    {
        transform.position = points[startingPoint].position; //Setto la posizione della piattaforma in uno dei punti iniziali
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, points[i].position) < 0.02f) //controllo la distanza dei punti
        {
            i++; //aumento i
            if (i == points.Length) //controllo se la piattaforma è sull'ultimo punto dopo l'aumento di i
            {
                i = 0; //imposto i a 0
            }
        }
        //muovo l piattaforma in un punto
        transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        /*
        if (this.gameObject.CompareTag("Enemy"))
        {
            if (Vector3.Distance(transform.position, points[i].position) < 0.02f) //faccio flippare lo sprite.. se mi muovo verso destra gira verso destra e viceversa.
            {
                test = !test;
            }

            if (test)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
       
        }
         */
    }


}
