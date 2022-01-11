using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cardsystem : MonoBehaviour
{
    public GameObject player;
    private string searchedItem;
    
    public void equipOnClick(GameObject card)
    {
        searchedItem = card.GetComponent<Card>().itemname;
        searchForItem(player.transform);
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
            }
        }
    }
}
