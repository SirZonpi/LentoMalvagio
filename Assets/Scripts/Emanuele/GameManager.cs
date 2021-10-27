using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioManager audioManager;
    public Player player;

    public List<GameObject> oggettidaDisattivare;
    public TimeManager timeManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(player);
    }

    public void LoadPlayer()
    {
        PlayerData playerData = SaveSystem.LoadPlayer();

        int health = player.Health;

        Vector3 position= CheckPoints.GetActiveCheckPointPosition(); //posizione ultimo checkpoint attivato
        /*
        position.x = playerData.position[0];
        position.y = playerData.position[1];
        position.z = playerData.position[2];
        */
        player.transform.position = position;

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            timeManager.SlowMotion();
        }
    }
}
