using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField] private ArtifactType artifactType;
    public enum ArtifactType {
        Totem,
        Relic,
        Orb
    }

    public ArtifactType GetArtifactType() {
        return artifactType;
    }
}
