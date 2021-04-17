using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogHandler : MonoBehaviour
{
    public Text dialogText;
    public Rocky rocky;
    public bool inDialog;

    public void SetUpDialog()
    {
        rocky.GetComponent<PlayerMovement>().FreezeMovement();
        inDialog = true;
    }

    public void StopDialog()
    {
        inDialog = false;
    }

    public IEnumerator TypeDialog(string dialog)
    {

        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            var tempVol = SfxManager.sfxInstance.Audio.volume;
            SfxManager.sfxInstance.Audio.volume = 0.5f;
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.dialogBlip);
            SfxManager.sfxInstance.Audio.volume = tempVol;
            yield return new WaitForSeconds(1f / 30);
            
        }

        yield return StartCoroutine(WaitForKeyDown(KeyCode.E));
        rocky.GetComponent<PlayerMovement>().UnfreezeMovement();
        gameObject.SetActive(false);
        var music = GameObject.FindGameObjectWithTag("Music");
        var musicSource = music.GetComponent<AudioSource>();
        musicSource.UnPause();
        inDialog = false;
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
        {
            yield return null;
        }
    }
}
