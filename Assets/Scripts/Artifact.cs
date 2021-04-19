using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField] private ArtifactType artifactType;
    [SerializeField] public GameObject loot;
    [SerializeField] public bool BossKey;
    [SerializeField] public bool IsFirst;

    void Start() {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<ArtifactHolder>().ContainsArtifact(artifactType)){
            gameObject.SetActive(false);
        }
    }

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
