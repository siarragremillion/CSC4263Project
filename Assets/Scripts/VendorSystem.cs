using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorSystem : MonoBehaviour
{
    [SerializeField] Rocky player;
    [SerializeField] DialogBox dialogBox;

    private void Start()
    {
        
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
}
