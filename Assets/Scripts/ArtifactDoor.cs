using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArtifactDoor : MonoBehaviour
{
    [SerializeField] private Artifact.ArtifactType artifactType;
    public Sprite sprite;

    public Artifact.ArtifactType GetArtifactType() {
        return artifactType;
    }

    public IEnumerator OpenDoor(Rocky rocky) {
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
        
        if (sceneName.Contains("Level"))
        {
            var lastChar = sceneName.Substring(sceneName.Length - 1);
            var lastInt = int.Parse(lastChar);
            if (lastInt == 0)
            {
                lastInt = GlobalControl.Instance.currentLevel;
            }
            else
            {
                lastInt++;
                GlobalControl.Instance.currentLevel = lastInt;
            }
            UIManager.LoadLevel("Level" + lastInt);
        }
    }
}
