using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioManager audioManager;
    public Player player;

    public List<GameObject> oggettidaDisattivare;
    public TimeManager timeManager;

    public GameObject saveCanvas;

    public string levelToLoad;

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


        levelToLoad = player.currentLevel;

    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(player);
    }

    public void LoadPlayer()
    {
        PlayerData playerData = SaveSystem.LoadPlayer();

        player.Health = playerData.health;

        levelToLoad = playerData.level;

        Vector3 position;
       
        position.x = playerData.position[0];
        position.y = playerData.position[1];
        position.z = playerData.position[2];
        
        player.transform.position = position;

    }

    Enemy[] enemies;

    void Start()
    {
        Debug.Log("scena nel GM " + levelToLoad);

        SceneManager.LoadSceneAsync(levelToLoad, LoadSceneMode.Additive);
         
    }

    private void OnEnable()
    {
       // Debug.Log("CARICA : " + levelToLoad);
    }

    public static bool isLoaded = false;
    public void LoadGame()
    {
        isLoaded = true;
        SceneManager.LoadScene("ScenaPrincipale");
        //LoadPlayer();
    }

    public void NewGame()
    {
        isLoaded = false;
        SceneManager.LoadScene("ScenaPrincipale");
        //LoadPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) //PER DEBUG
        {
            timeManager.SlowMotion();
        }

   
    }
}
