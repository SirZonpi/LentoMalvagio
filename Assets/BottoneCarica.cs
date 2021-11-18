using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottoneCarica : MonoBehaviour
{
    Button buttone;

    // Start is called before the first frame update
    void Awake  ()
    {
        buttone = GetComponent<Button>();
    }

    private void Start()
    {
        if(PlayerPrefs.GetInt("FirstSave") == 1)
        {
            buttone.enabled = true;
        }
        else
        {
            buttone.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
