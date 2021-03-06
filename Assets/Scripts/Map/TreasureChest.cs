﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class TreasureChest : InteractableTile
{
    public BaseItem treasure;
    public bool hasBeenOpened = false;

    bool heroStandingOnThisTile = false;

    private void Update()
    {
        if (heroStandingOnThisTile && Input.GetButtonDown("AButton"))
        {
            if (currentlyStandingOnInteractableTile)
            {
                if (!hasBeenOpened)
                {
                    TextBoxManager textManager = TextBoxManager.tbm;
                    textManager.currentLine = 0;
                    textManager.endLine = 0; // Controls how many windows

                    string boxMessage = "Inside the chest, you found a " + treasure.GetItemData().itemName + ".";
                    TextBoxManager.tbm.EnableTextBox(null, boxMessage, true);
                    // TODO: Open box animation
                    GameManager.gm.gameObject.GetComponent<Inventory>().AddToInventory(treasure.GetItemData());


                    hasBeenOpened = true;
                    heroStandingOnThisTile = false;
                    Debug.Log("Open Chest");
                }
                else
                {

                }
            } else
            {
                heroStandingOnThisTile = false;
            }
        }
    }

    public override void ActivateInteraction()
    {
        if (!hasBeenOpened)
        {
            heroStandingOnThisTile = true;
        }
    }
}
