using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Card", menuName = "Card") ]
public class Card : ScriptableObject
{
    public Sprite cardsprite;   // also divideable into artwork, description, basic card border
    public string itemname;

    public int defense;     //optional
    public int cost;

}
    
