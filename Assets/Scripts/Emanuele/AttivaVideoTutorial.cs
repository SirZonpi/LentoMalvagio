using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AttivaVideoTutorial : MonoBehaviour
{
    public VideoPlayer vp;
    public GameObject videoPanel;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            videoPanel.SetActive(true);

            vp.Play();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            vp.Stop();
            videoPanel.SetActive(false);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        vp.Stop();
        videoPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
