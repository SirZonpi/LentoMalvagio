using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckPoints : MonoBehaviour
{
   
    public bool activated = false;
    public static GameObject[] checkPointsList;

    [SerializeField] GameObject saveCanvas;
    [SerializeField] ParticleSystem ps;
    

    [SerializeField] Player playerHealth;

    public static string level; ////

    public void Rigenera()
    {
        playerHealth.RestoreHealth();
      
    }


    public static Vector3 GetActiveCheckPointPosition()                                                                     
    {
        // se il player muore senza aver toccato un checkpoint lo riposiziniamo in un punto predefinito
        //Vector3 result = new Vector3(5f, 25f, -103f);

        Vector3 result = GameManager.instance.playerStartPos;

        if (checkPointsList != null)
        {
            foreach (GameObject cp in checkPointsList)
            {
                if (cp != null)
                {
                    // cerchiamo l'ultimo checkpoint attivato per ottenre la posizione di spawn
                    if (cp.GetComponent<CheckPoints>().activated)
                    {
                        result = cp.transform.position;
                        break;
                    }
                }
            }
        }

        return result; //otteniamo il valore di result che può essere o il valore di default (prima riga) o la pos dell ultimo checpoint
    }

    private void ActivateCheckPoint()
    {

        // controlliamo tutti i checkpoint in scena
        foreach (GameObject cp in checkPointsList)
        {
           if(cp!=null)                                                          
            cp.GetComponent<CheckPoints>().activated = false;  //li disattiviamo                                                         
        }

        //attiviamo il checkpoint corrente
        activated = true;                                                                                                   
        //GetComponent<SpriteRenderer>().color = Color.green;                                                              
       // GetComponent<SpriteRenderer>().sprite = checkActive;                                                        
    }

    void OnTriggerEnter(Collider other)
    {
        // se il player collide con un checkpoint e questo non è attualmente attivo, lo attiviamo
        if (other.gameObject.CompareTag("Player") && !this.activated)                                                                                         
        {
            Cursor.visible = true;
            Debug.Log("checkpoint attivato");
            ActivateCheckPoint();
            Rigenera();
            GameManager.instance.audioManager.PlaySound("checkpoint");

            if (ps != null)
            {
                ps.Play();
            }
            //GameManager.instance.audioManager.PlaySound("checkpoint");
            GetScenename();

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && this.activated)
        {
            Cursor.visible = true;
            saveCanvas.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && this.activated)
        {
            saveCanvas.SetActive(false);
            Cursor.visible = false;

            if (ps != null)
            {
                ps.Stop();
            }

        }
    }

    private void OnEnable()
    {

       // saveCanvas = GameObject.FindGameObjectWithTag("savecanvas");///

       checkPointsList = GameObject.FindGameObjectsWithTag("CheckPoint"); //cerchiamo tutti i checkpoint in scena usando una tag

        Debug.Log("cp list " + checkPointsList.Length);
        
        //  playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

       
    }

    private void Awake()
    {

    }

    public void  GetScenename()
    {
        level = gameObject.scene.name;///
        Debug.Log("scena : " + level);
        playerHealth.currentLevel = level;
        //return level;
    }


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameManager.instance.player;
        saveCanvas = GameManager.instance.saveCanvas;

        level = gameObject.scene.name;///

        saveCanvas.SetActive(false);

    }


}
