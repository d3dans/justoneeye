using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public string questitemName;
    void Start()
    {
        questitemName = gameObject.name.ToString();
    }

    public void ItemCollected()
    {
        if(gameObject.name == "Generator" || gameObject.name == "Gate")
        {

        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
