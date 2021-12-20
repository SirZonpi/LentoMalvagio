using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CanvasPlayerManager : MonoBehaviour
{
    public float indicatorTimer = 1; 
    public float maxIndicatorTimer = 1;

    public Image radialIndicatorUI = null;

    public UnityEvent myEvent = null;

    public bool sholdUpdate = false;

    public Animator anim;

    public bool attacco1;

    public PlayerAttackState animAttacco;

    private void Start()
    {
        attacco1 = Input.GetMouseButton(0) && anim.GetBool("attacca");

        indicatorTimer = Mathf.Ceil( animAttacco.animazioneAttacco1.clip.length );
        maxIndicatorTimer = Mathf.Ceil(animAttacco.animazioneAttacco1.clip.length );

    }

    // Update is called once per frame
    void Update()
    {

        if (sholdUpdate == false)
            radialIndicatorUI.enabled = false;

        if (  anim.GetBool("attacca"))
        {
            sholdUpdate = false;
            indicatorTimer -= Time.deltaTime;

            radialIndicatorUI.enabled = true;
            radialIndicatorUI.fillAmount = indicatorTimer;

            if (indicatorTimer <= 0)
            {
                indicatorTimer = maxIndicatorTimer;
                radialIndicatorUI.fillAmount = maxIndicatorTimer;
                radialIndicatorUI.enabled = false;
                myEvent.Invoke();
            }
        }
        else 
        {
            if (sholdUpdate)
            {
                /*
                indicatorTimer += Time.deltaTime;
                radialIndicatorUI.fillAmount = indicatorTimer;
                */
                sholdUpdate = false;
                radialIndicatorUI.enabled = false;
              
                indicatorTimer = maxIndicatorTimer;
                radialIndicatorUI.fillAmount = maxIndicatorTimer;
                //
              
              

                /*
                if (indicatorTimer >= maxIndicatorTimer)
                {

                    indicatorTimer = maxIndicatorTimer;
                    radialIndicatorUI.fillAmount = maxIndicatorTimer;
                    radialIndicatorUI.enabled = false;
                    sholdUpdate = false;
                }
                */
            }

        }

        if (!anim.GetBool("attacca") )
        {
            sholdUpdate = true;
        }


    }

}
