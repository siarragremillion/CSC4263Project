using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField] private ArtifactType artifactType;
    [SerializeField] public GameObject loot;
    public enum ArtifactType {
        Totem,
        Relic,
        Orb,
        Loot
    }

    public ArtifactType GetArtifactType() {
        return artifactType;
    }

}
