using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    int escapeQuest = 0;
    int banishQuest = 0;
    RaycastHit hit;
    RaycastHit demonhit;

    public GameObject Demon;
    Transform trapPos;
    public GameObject CameraPivot;
    public GameObject MenuCanvas;

    public GameObject escape0;
    public GameObject escape1;
    public GameObject escape2;
    public GameObject gastext;
    public GameObject repairkittext;
    public GameObject keytext;
    public GameObject escape3;
    public GameObject escape4;
    public bool repairKit = false;
    public bool key = false;
    public bool gas = false;
    public bool studyDoor = false;

    public GameObject demoneye;
    public GameObject humaneye;
    public GameObject banish0;
    public GameObject banish1;
    public GameObject salttext;
    public GameObject candlestext;
    public GameObject eyestext;
    public GameObject banish2;
    public GameObject banish3;
    public bool salt;
    public int eyes;
    public bool candles;

    

    void Start()
    {
        escape0.SetActive(true);
        escape1.SetActive(false);
        escape2.SetActive(false);
        keytext.SetActive(false);
        escape3.SetActive(false);
        escape4.SetActive(false);

        //banish0.SetActive(true);
        //banish1.SetActive(false);
       // banish2.SetActive(false);
       // banish3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("TabMenu"))
        {
            MenuCanvas.SetActive(!MenuCanvas.activeSelf);
        }

        if (Physics.Raycast(CameraPivot.transform.position, CameraPivot.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.GetComponent<QuestItem>())
            {
                Debug.Log("hit");
                if (Input.GetMouseButtonDown(0))
                {
                    EscapeQuest(hit.collider.gameObject);
                    //BanishQuest(hit.collider.gameObject);
                }
            }            
        }

        /*if (Physics.Raycast(CameraPivot.transform.position, CameraPivot.transform.forward, out demonhit, 10))
        {
            if (demoneye.activeSelf && !humaneye.activeSelf && demonhit.collider.gameObject.name == "DemonTextQuest")//change name later?
            {
                Debug.Log("demon latin");
                banishQuest = 1;
                banish0.SetActive(false);
                banish1.SetActive(true);
                BanishQuest(null);
            }

            if(escapeQuest == 2 && demonhit.collider.gameObject.name == "DemonTrap")
            {
                trapPos = demonhit.collider.gameObject.transform;
                banishQuest = 3;
                BanishQuest(null);
            }
        }

        if(banishQuest == 3)
        {
            if(Demon.transform.position == trapPos.position)
            {
                banishQuest = 4;
                BanishQuest(null);
            }
        }*/

    }

    void EscapeQuest(GameObject item)
    {
        string questItemName = item.GetComponent<QuestItem>().questitemName;
        switch (escapeQuest)
        {
            case 0:
                if (questItemName == "Gate")
                {
                    escape0.SetActive(false);
                    escape1.SetActive(true);
                    escapeQuest += 1;
                }
                    break;
            case 1://find generator
                if(questItemName == "Generator")
                {
                    escape1.SetActive(false);
                    escape2.SetActive(true);
                    escapeQuest += 1;
                }
                break;                
            case 2://get parts                
                if (questItemName == "Gas")
                {
                    gas = true;
                    gastext.SetActive(false);
                    Destroy(item);
                }
                else if(questItemName == "StudyDoor")
                {
                    studyDoor = true;
                    keytext.SetActive(true);
                    //set key active in scene
                }
                else if (questItemName == "Key" && studyDoor)
                {
                    key = true;
                    keytext.SetActive(false);
                    Destroy(item);
                }
                else if(questItemName == "RepairKit")
                {
                    repairKit = true;
                    repairkittext.SetActive(false);
                    Destroy(item);
                }
                if(gas && repairKit)
                {
                    escape2.SetActive(false);
                    escape3.SetActive(true);
                    escapeQuest += 1;
                }

                break;
            case 3://fix generator
                if (questItemName == "Generator")
                {
                    escape3.SetActive(false);
                    escape4.SetActive(true);
                    //escapeQuest += 1;
                }
                break;
            default:
                Debug.Log("error");
                break;
        }
        //find escape
    }

    void BanishQuest(GameObject item)
    {
        string questItemName;
        if (item != null)
        {
            questItemName = item.GetComponent<QuestItem>().questitemName;
        }
        else
        {
            questItemName = "none";
        }

        switch (banishQuest)
        {
            case 0:
                Debug.Log("look at the latin man");
                break;
            case 1://collect supplies
                
                if (questItemName == "Salt")
                {
                    salt = true;
                    salttext.SetActive(false);
                    Destroy(item);
                }
                else if(questItemName == "Candles")
                {
                    candles = true;
                    candlestext.SetActive(false);
                    Destroy(item);
                }
                else if(questItemName == "Eye")
                {
                    eyes += 2;
                    eyestext.GetComponent<Text>().text = "Eyes " + eyes + "/5";
                    if(eyes == 5)
                    {
                        eyestext.SetActive(false);
                    }
                }
   
                if(salt && candles && eyes == 5)
                {                    
                    escapeQuest = 2;
                    banish1.SetActive(false);
                    banish2.SetActive(true);
                }

                break;
            case 2://set trap
                banish1.SetActive(false);
                banish2.SetActive(true);
                break;
            case 3://trap demon
                banish2.SetActive(false);
                banish3.SetActive(true);
                break;
            case 4://need demon to finish
                banish3.SetActive(false);
                //hide all text and images for quest
                break;
            default:
                Debug.Log("error");
                break;
        }
    }
}
