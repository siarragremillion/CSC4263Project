using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorSystem : MonoBehaviour
{
    [SerializeField] Rocky player;
    [SerializeField] DialogBox dialogBox;

    public bool canLeaveInteraction;

    int currentItem;

    private void Start()
    {
        dialogBox.EnableItemText(false);
    }

    public IEnumerator SetupVendor()
    {
        yield return dialogBox.TypeDialog("Hey Rock, the names Paulie. What weapon do you want to upgrade?");
        yield return new WaitForSeconds(1f/30);

        ItemSelection();
    }

    void ItemSelection()
    {
        dialogBox.EnableItemText(true);
    }

    private void Update()
    {
        if (dialogBox.itemsShown)
        {
            HandleItemSelection();
            canLeaveInteraction = true;
        }
    }

    void HandleItemSelection()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentItem < 1)
            {
                ++currentItem;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentItem > 0)
            {
                --currentItem;
            }
        }
        dialogBox.UpdateItemSelection(currentItem);
    }
}
