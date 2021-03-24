using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactDoor : MonoBehaviour
{
    [SerializeField] private Artifact.ArtifactType artifactType;

    public Artifact.ArtifactType GetArtifactType() {
        return artifactType;
    }

    public void OpenDoor() {
        gameObject.SetActive(false);
        FindObjectOfType<UIManager>().showComplete();
    }
}
