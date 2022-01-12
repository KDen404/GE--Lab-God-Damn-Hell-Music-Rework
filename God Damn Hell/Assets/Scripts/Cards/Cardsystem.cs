using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cardsystem : MonoBehaviour
{
    public GameObject player;
    private string searchedItem;
    private GameObject currentCard;     // the current card thats being checked

    private string[] equipment = {"emptyString", "emptyString", "emptyString" };

    public void equipOnClick(GameObject card)
    {
        currentCard = card;
        searchedItem = currentCard.GetComponent<Card>().itemname;
        searchForItem(player.transform);        // recursive function to serch for the Item thats supposed to be equipped;

    }

    private void safeItemName()     // saves the Item for Scene changes at Scenechange only the information in equipment will be safed to json
    {
        if(currentCard.GetComponent<Card>().itemtype == "head")
        {
            equipment[0] = searchedItem;
        }
        else if (currentCard.GetComponent<Card>().itemtype == "top")
        {
            equipment[1] = searchedItem;
        }
        else if (currentCard.GetComponent<Card>().itemtype == "bottom")
        {
            equipment[2] = searchedItem;
        }
    }

    private void searchForItem(Transform childToTest)
    {
        for (int i = 0; i < childToTest.childCount; ++i)
        {
            searchForItem(childToTest.GetChild(i));
        }
        if (childToTest.childCount == 0)    // all Children without children
        {
            if (childToTest.name == searchedItem)     // if its the searched item
            {
                //Deactivate all other weapons on this slot
                for (int i = 0; i < childToTest.parent.transform.childCount; ++i)
                {
                    childToTest.parent.transform.GetChild(i).gameObject.SetActive(false);
                }
                childToTest.gameObject.SetActive(true);
                safeItemName();
            }
        }
    }
}
