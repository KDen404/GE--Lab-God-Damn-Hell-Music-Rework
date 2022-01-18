using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Cardsystem : MonoBehaviour
{
    public GameObject player;
    private string searchedItem;
    private GameObject currentCard = null;     // the current card thats being checked, only needed in Main Menu
  
    private string savegamePath;
    public static Savegame savegame = null;

    public Image potionNumberDisplay;
    public Sprite[] potionSpritesList;          // list  of the Number Sprites

    private void Start()
    {
        savegamePath = Path.Combine(Application.persistentDataPath, "savegame.json");
        if (savegame != null)
        { 
            LoadSavegame();
        }
        else
        {
            savegame = new Savegame();
        }
        equipFromSavegame();
    }

    public void LoadSavegame()
    {
        if (File.Exists(savegamePath))
        {
            savegame = JsonUtility.FromJson<Savegame>(File.ReadAllText(savegamePath));
        }
    }

    public void SaveSavegame()
    {
        File.WriteAllText(savegamePath, JsonUtility.ToJson(savegame));
    }

    public void equipFromSavegame()
    {
        
        searchedItem = savegame.equipmentSafedataHead;
        searchForItem(player.transform);

        searchedItem = savegame.equipmentSafedataTop;
        searchForItem(player.transform);

        searchedItem = savegame.equipmentSafedataBottom;
        searchForItem(player.transform);
    }

    public void equipOnClick(GameObject card)   // equips the Item attached to the clicked button and saves it to savegame;
    {
        currentCard = card;
        searchedItem = currentCard.GetComponent<Card>().itemname;
        searchForItem(player.transform);  // recursive function to serch for the Item thats supposed to be equipped; 
    }

    private void saveItemNameToSavegame()     // saves the Item to the corresponding slot, for Scenechanges, into savegame
    {
        if(currentCard != null) {                                   // if outside of Main Menu (Live Scene), saving is not needed
            if (currentCard.GetComponent<Card>().itemtype == "head")
            {
                savegame.equipmentSafedataHead = searchedItem;
            }
            else if (currentCard.GetComponent<Card>().itemtype == "top")
            {
                savegame.equipmentSafedataTop = searchedItem;
            }
            else if (currentCard.GetComponent<Card>().itemtype == "bottom")
            {
                savegame.equipmentSafedataBottom = searchedItem;
            }
        }
    }

    private void searchForItem(Transform childToTest)   // equips the searched item if it exists
    {
        for (int i = 0; i < childToTest.childCount; ++i)
        {
            searchForItem(childToTest.GetChild(i));
        }
        if (childToTest.childCount == 0)    // all Children without children,    optional but probably faster
        {
            if (childToTest.name == searchedItem)     // if its the searched item
            {
                bool invertState = !childToTest.gameObject.activeSelf;  // inverts the Activity State of the object (to unequip on click)
                //Deactivate all other weapons on this slot
                for (int i = 0; i < childToTest.parent.transform.childCount; ++i)
                {
                    childToTest.parent.transform.GetChild(i).gameObject.SetActive(false);
                }
                childToTest.gameObject.SetActive(invertState);

                saveItemNameToSavegame();
            }
        }
        
    }

    public void changePotionNumber(int changeAmount)
    {
        if ((savegame.potionNumber + changeAmount >= 0) && (savegame.potionNumber + changeAmount <= 2))        // potionNumber restricted to a Number between 0 and 2
        {
            savegame.potionNumber += changeAmount;
            potionNumberDisplay.sprite = potionSpritesList[savegame.potionNumber];
        }
    }
}
