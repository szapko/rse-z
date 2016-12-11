using UnityEngine;
using System.Collections;
using System;

public abstract class itemAbstract : MonoBehaviour {

    public Texture2D itemIcon;

    public string itemName;
    public string itemDescription;
    public string itemType;
    public float itemWeight;
    public float itemStrange; // wytrzymałość
    public bool disposable;

    public Texture2D getIcon()
    {
        return itemIcon;
    }
    
    public string getName()
    {
        return itemName;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Gracz"))
        {
            other.GetComponent<playerEquipment>().SendMessage("addItem", this);
            Destroy(gameObject);
        }
    }

    public abstract bool execute(playerStatistics pS);
}
