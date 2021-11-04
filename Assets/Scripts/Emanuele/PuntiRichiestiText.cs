using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntiRichiestiText : MonoBehaviour
{
    [SerializeField] Player player;
    Text puntirichiestiText;

    // Start is called before the first frame update
    void Start()
    {
        puntirichiestiText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.livelloDifficolta == "Normale")
        {
            puntirichiestiText.text = GameManager.instance.diffDifficile.ToString();
        }
        else if (player.livelloDifficolta == "Difficile")
        {
            puntirichiestiText.text = GameManager.instance.diffFolle.ToString();
        }
        else if (player.livelloDifficolta == "Folle")
        {
            puntirichiestiText.text = "Da implementare";
        }
    }
}
