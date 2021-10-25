using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    PowerUp1,
    PowerUp2,
    Collezionabile
}

public class Item : MonoBehaviour
{
    public ItemType tipo;
    public int ID;
    public string nome;
    public GameObject mesh;
    public Sprite icon;
    public bool isStackable;

}
