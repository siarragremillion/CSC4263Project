using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogHandler : MonoBehaviour
{
    public Text dialogText;
    public Rocky rocky;

    public void SetUpDialog()
    {
        rocky.GetComponent<PlayerMovement>().FreezeMovement();
    }

    public IEnumerator TypeDialog(string dialog)
    {

        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / 30);
            
        }

        yield return StartCoroutine(WaitForKeyDown(KeyCode.E));
        rocky.GetComponent<PlayerMovement>().UnfreezeMovement();
        gameObject.SetActive(false);
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
        {
            yield return null;
        }
    }
}
