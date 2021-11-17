using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioManager audioManager;
    public Player player;

    public Vector3 playerStartPos;

    public float defaultCam;

    [SerializeField] GameObject panelPause;
    public static bool isPause = false;
    public AudioMixerGroup musica;
    public AudioMixerGroup sfx;

    public Slider sliderMusica;
    public Slider sliderSfx;

    public List<GameObject> oggettidaDisattivare;
    public TimeManager timeManager;

    public GameObject saveCanvas;

    public string levelToLoad;

   // public string currentLivelloDifficolta;  ///aggiunto oggi
    public int diffDifficile = 500;
    public int diffFolle = 1000;

    public GameObject spawnLivello2;
    public GameObject spawnLivelloBoss;

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

        // levelToLoad = player.currentLevel; //////////////////////////////////////

        playerStartPos = player.transform.position; //

    }

    public void SetVolumeMusica(float sliderValue)
    {
        musica.audioMixer.SetFloat("MusicaVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicaVol", sliderValue);
        Debug.Log("vol " + PlayerPrefs.GetFloat("MusicaVol"));
    }

    public void SetVolumeSFX(float sliderValue)
    {
        sfx.audioMixer.SetFloat("SfxVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SfxVol", sliderValue);
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(player);
        Debug.Log("livellosalvato " + player.currentLevel);
    }

    public void LoadPlayer()
    {
        PlayerData playerData = SaveSystem.LoadPlayer();

        player.Health = playerData.health;

        levelToLoad = playerData.level;

        player.currentLevel = playerData.level; ///////////////////////////////////////////////////////


        player.livelloDifficolta = playerData.difficoltà;

        Vector3 position;
       
        position.x = playerData.position[0];
        position.y = playerData.position[1];
        position.z = playerData.position[2];
        
        player.transform.position = position;

    }


    void Start()
    {
        levelToLoad = player.currentLevel;

        if(isLoaded==false)///
        levelToLoad = "Scena1";///

        SceneManager.LoadSceneAsync( levelToLoad , LoadSceneMode.Additive);//////////////////////////////////////

        panelPause.SetActive(false);

        audioManager.PlaySound("MusicaPrincipale");
        
        SetVolumeMusica(PlayerPrefs.GetFloat("MusicaVol"));
        SetVolumeSFX(PlayerPrefs.GetFloat("SfxVol"));

        sliderMusica.value = PlayerPrefs.GetFloat("MusicaVol");
        sliderSfx.value = PlayerPrefs.GetFloat("SfxVol");

        // currentLivelloDifficolta = player.livelloDifficolta;

    }

    private void OnEnable()
    {
        if (isLoaded) LoadPlayer();
    }

    public static bool isLoaded = false;
    public void LoadGame()
    {
        isLoaded = true;
        SceneManager.LoadScene("ScenaPrincipale");
     
    }

    public void NewGame()
    {
        isLoaded = false;
        SceneManager.LoadScene("ScenaPrincipale");
      
    }

    public void Pausa()
    {
        panelPause.SetActive(true);
        timeManager.enabled = false;
        Time.timeScale = 0f;
        isPause = true;
    }

    public void Resume()
    {
        panelPause.SetActive(false);
        timeManager.enabled = true;

        Time.timeScale = 1f;
        isPause = false;
    }

   

    public bool doOnce1 = true;
    public bool doOnce2 = true;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("IS LOADED " + isLoaded);

        Debug.Log("SCALA TEMPO " + Time.timeScale);

        if (Input.GetKeyDown(KeyCode.L)) //PER DEBUG
        {
            timeManager.SlowMotion();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) //PER DEBUG
        {
            if (isPause)
            {
                Resume();
                Debug.Log("no pausa");
            }
            else
            {
                Pausa();
                Debug.Log("pausa");
            }
           
        }


        if (player.livelloDifficolta == "Difficile" && doOnce1  )
        {

            Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

            foreach (Enemy enemy in enemies)
            {
              
                if (enemy.gameObject.scene.name == player.currentLevel)
                {

                    enemy.maxHealth = 20;
                    enemy.Health = enemy.maxHealth;
                    enemy.animeDrop += ((int)enemy.animeDrop * 20 / 100); ///
                    doOnce1 = false;

                }
            }

        }

        if (player.livelloDifficolta == "Folle" && doOnce2)
        {
            Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

            foreach (Enemy enemy in enemies)
            {

                if (enemy.gameObject.scene.name == player.currentLevel)
                {
                    enemy.maxHealth = 40;
                    enemy.Health = enemy.maxHealth;
                    enemy.animeDrop += ((int)enemy.animeDrop * 50 / 100); ///
                    doOnce2 = false;
                }
            }

        }

    }
}
