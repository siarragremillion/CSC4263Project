using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VendorDoor : MonoBehaviour
{
    public Sprite sprite;

    public IEnumerator OpenDoor(Rocky rocky){
        GetComponent<SpriteRenderer>().sprite = sprite;
        var sceneName = SceneManager.GetActiveScene().name;
        var music = GameObject.FindGameObjectWithTag("Music");
        var musicSource = music.GetComponent<AudioSource>();
        musicSource.Pause();

        yield return new WaitForSeconds(0.5f);

        if (!sceneName.Equals("Level0"))
        {
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.LevelComplete);
            yield return new WaitForSeconds(SfxManager.sfxInstance.LevelComplete.length / 2.0f);
        }

        gameObject.SetActive(false);
        rocky.SavePlayer();
        rocky.journalSystem.SaveJournals();
        rocky.GetComponent<RingHolder>().SaveRings();

        UIManager.LoadLevel("Level" + 0);
    }

    private void OnTriggerEnter2D(Collider2D other){
        StartCoroutine(OpenDoor(GameObject.FindGameObjectWithTag("Player").GetComponent<Rocky>()));
    }
}
