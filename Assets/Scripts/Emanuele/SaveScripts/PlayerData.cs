using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData  
{
    public int health;
    public float[] position; //non posso serializzare un vector...amarezza
    public string level;

    public string difficoltà; ///aggiunto oggi
    //public int itemRaccolti;

    public PlayerData(Player player) //costruttore
    {
        health = player.Health; //nota: per adesso è praticamente inutile perchè il checkpoint ricarica tutta la vita. 
        level = player.currentLevel;

        difficoltà = player.livelloDifficolta; 

        position = new float[3];
        position[0] = CheckPoints.GetActiveCheckPointPosition().x;
        position[1] = player.transform.position.y; //voglio salvare per quanto riguarda la y la pos del player e non quella del checkpoint
        position[2] = CheckPoints.GetActiveCheckPointPosition().z;

    }

}
