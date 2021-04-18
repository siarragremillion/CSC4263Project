using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    [SerializeField] Text dialogText;
    [SerializeField] int lettersPerSecond;
    [SerializeField] Color highlightedColor;

    [SerializeField] GameObject itemSelector;
    [SerializeField] public List<Text> itemTexts;
    [SerializeField] public bool itemsShown;
    [SerializeField] public List<Text> itemPrices;

    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;

    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            /*var tempVol = SfxManager.sfxInstance.Audio.volume;
            SfxManager.sfxInstance.Audio.volume = 0.5f;*/
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.dialogBlip);
            /*SfxManager.sfxInstance.Audio.volume = tempVol;*/
            yield return new WaitForSeconds(1f/lettersPerSecond);
        }
        yield return StartCoroutine(WaitForKeyDown(KeyCode.E));
    }

    public void EnableItemText(bool enabled)
    {
        itemSelector.SetActive(enabled);
        itemsShown = enabled;
    }

    public void UpdateItemSelection(int selectedItem)
    {
        for (int i = 0; i < itemTexts.Count; i++)
        {
            if (i == selectedItem)
            {
                ChangeColorOfChildrenAndSelf(itemTexts[i], highlightedColor);
                //itemTexts[i].color = highlightedColor;
            }
            else
            {
                ChangeColorOfChildrenAndSelf(itemTexts[i], Color.white);
                //itemTexts[i].color = Color.white;
            }
        }
    }

    void ChangeColorOfChildrenAndSelf(Text itemText, Color color)
    {
        itemText.color = color;
        foreach (var item in itemText.GetComponentsInChildren<Text>())
        {
            item.color = color;
        }
    }

    public void ResetVendor(Vendor vendor)
    {
        foreach (var item in itemTexts)
        {
            item.gameObject.SetActive(false);
        }

        foreach (var item in itemPrices)
        {
            item.gameObject.SetActive(false);
        }

        for (int i = 0; i < vendor.itemNames.Count; i++)
        {
            itemTexts[i].gameObject.SetActive(true);
            itemPrices[i].gameObject.SetActive(true);
        }

    }

    // Waits until a certain key is pressed
    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
        {
            yield return null;
        }
    }
}
