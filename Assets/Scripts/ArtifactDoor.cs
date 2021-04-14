using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArtifactDoor : MonoBehaviour
{
    [SerializeField] private Artifact.ArtifactType artifactType;

    public Artifact.ArtifactType GetArtifactType() {
        return artifactType;
    }

    public void OpenDoor(Rocky rocky) {
        gameObject.SetActive(false);
        rocky.SavePlayer();
        var sceneName = SceneManager.GetActiveScene().name;
        if (sceneName.Contains("Level"))
        {
            var lastChar = sceneName.Substring(sceneName.Length - 1);
            var lastInt = int.Parse(lastChar);
            lastInt++;
            UIManager.LoadLevel("Level" + lastInt);
        }
        //FindObjectOfType<UIManager>().showComplete();
    }
}
