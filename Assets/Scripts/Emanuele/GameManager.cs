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

    public string currentLivelloDifficolta;

    //public LivelloDifficolta currentLivelloDifficolta = LivelloDifficolta.Normale;  ///aggiunto oggi
    public int diffDifficile = 500;
    public int diffFolle = 1000;

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

       currentLivelloDifficolta =player.livelloDifficolta;

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

        string stringadelporco = playerData.difficoltà.ToString();

        player.livelloDifficolta = playerData.difficoltà;

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

    /*
    public void IncrementaDifficolta(string lvlDif)  ///aggiunto oggi
    {
        switch (lvlDif)
        {
            case LivelloDifficolta.Normale:
                break;
            case LivelloDifficolta.Difficile:

                Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

                foreach (Enemy enemy in enemies)
                {
                    enemy.maxHealth += 10;
                }

                break;
            case LivelloDifficolta.Folle:
                break;
        }
    }
    */

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) //PER DEBUG
        {
            timeManager.SlowMotion();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            player.livelloDifficolta = "Difficile";

           // Debug.Log("MEDDA " + System.Enum.GetName(typeof(LivelloDifficolta), player.livelloDifficolta).ToString());

        }

        if(player.livelloDifficolta == "Difficile")
        {
            Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();



            foreach (Enemy enemy in enemies)
            {
                if (enemy.gameObject.scene.name == player.currentLevel)
                {

                    enemy.maxHealth = 30;
                  //  enemy.Health = enemy.maxHealth;
                }
            }
        }
   
    }
}
