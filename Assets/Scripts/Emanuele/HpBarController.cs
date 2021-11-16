using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarController : MonoBehaviour
{
    [SerializeField] HpBar hpBarPrefab; //il prefab della hp bar

    Dictionary<Entity, HpBar> hpBars = new Dictionary<Entity, HpBar>(); //un dizionario che accoppia entity(chiave) e hpbar(valore)

    private void Awake()
    {
        //sottoscriviamo nei due delegati dichiarati nello script Entity le due funzioni dichiarate poco sotto
        //possiamo farlo senza reference perchè sono eventi pubblici statici

        //quando una entity viene aggiunta (e questo viene fatto nell onenable dello script entity) sottoscriviamo le due funzioni
        Entity.OnHealthAdded += AddHpBar; //aggiuntiamo una hp bar (vedi sotto)
        Entity.OnHealthRemoved += RemoveHpBar;

    }

    //controlliamo se il dizionario contiene già l' entity (questa funzione è sottoscritta nell event chiamato nell onable dello script entity, viene quindi subito richiamata)
    void AddHpBar(Entity entityHealth)
    {
        if(hpBars.ContainsKey(entityHealth) == false) //se la chiave non è presente istanziamo una nuova hpbar
        {
            HpBar hpBar = Instantiate(hpBarPrefab, transform); //nota: transform è il parent (il canvas nella hirarchy che contiene tutte le hpbar)
            hpBars.Add(entityHealth, hpBar); //aggiungiamo key e value al dizionario
            hpBar.SetHealth(entityHealth);  
        }
    }

    void RemoveHpBar(Entity entityHealth)
    {
        
            if (hpBars.ContainsKey(entityHealth) == true || entityHealth == null)
            {
                Destroy(hpBars[entityHealth].gameObject);
                hpBars.Remove(entityHealth);
            }
        
    }


}
