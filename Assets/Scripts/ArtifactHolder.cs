using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArtifactHolder : MonoBehaviour
{
    [SerializeField] private List<Artifact.ArtifactType> artifactList;
    [SerializeField] public DialogHandler dialogHandler;

    private void Awake(){
        artifactList = new List<Artifact.ArtifactType>();
    }

    public void AddArtifact(Artifact.ArtifactType artifactType){
        artifactList.Add(artifactType);
    }

    public void RemoveArtifact(Artifact.ArtifactType artifactType){
        artifactList.Remove(artifactType);
    }

    public bool ContainsArtifact(Artifact.ArtifactType artifactType){
        return artifactList.Contains(artifactType);
    }


    private void OnTriggerEnter2D(Collider2D other){
        Artifact artifact = other.GetComponent<Artifact>();
        if(artifact != null){
            StartCoroutine(ArtifactPickUp(artifact));
        }

        ArtifactDoor artifactDoor = other.GetComponent<ArtifactDoor>();
        if(artifactDoor != null){
            if (SceneManager.GetActiveScene().name.Equals("Level0"))
            {
                StartCoroutine(artifactDoor.OpenDoor(gameObject.GetComponent<Rocky>()));
            }
            else if(ContainsArtifact(artifactDoor.GetArtifactType())){
                RemoveArtifact(artifactDoor.GetArtifactType());
                StartCoroutine(artifactDoor.OpenDoor(gameObject.GetComponent<Rocky>()));
            }
        }
    }

    public IEnumerator ArtifactPickUp(Artifact artifact)
    {
        dialogHandler.SetUpDialog();
        var music = GameObject.FindGameObjectWithTag("Music");
        var musicSource = music.GetComponent<AudioSource>();
        musicSource.Pause();
        
        AddArtifact(artifact.GetArtifactType());

        if(artifact.GetArtifactType() == Artifact.ArtifactType.Loot){
            Instantiate(artifact.loot, artifact.transform.position, artifact.transform.rotation);
        }

        Destroy(artifact.gameObject);
        dialogHandler.gameObject.SetActive(true);
        
        string artifactDlg = "";
        switch(artifact.GetArtifactType()){
            case Artifact.ArtifactType.Totem:
                artifactDlg = "You found the Artifact!\nYou can now complete the level.\nGo to the door!!!!";
                break;
            case Artifact.ArtifactType.Loot:
                artifactDlg = "You found an artifact!";
                break;
        }
        StartCoroutine(dialogHandler.TypeDialog(artifactDlg));

        if (artifact.BossKey)
        {
            FindObjectOfType<Rocky>().journalSystem.FindJournal(6);
        }
        if (artifact.IsFirst)
        {
            FindObjectOfType<Rocky>().journalSystem.FindJournal(5);
        }

        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.ArtifactFound);
        yield return new WaitForSeconds(SfxManager.sfxInstance.ArtifactFound.length / 2.0f);

    }

}
