using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficoltaAttualeText : MonoBehaviour
{
    [SerializeField] Player player;
    Text difficoltaText;

    
    void Start()
    {
        difficoltaText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        difficoltaText.text = player.livelloDifficolta;
    }
}
