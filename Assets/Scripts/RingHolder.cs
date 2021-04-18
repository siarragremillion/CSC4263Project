using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingHolder : MonoBehaviour
{
    [SerializeField] private List<Ring.RingType> ringList;
    private Ring.RingType activeRing;

    private void Start()
    {
        ringList = GlobalControl.Instance.ringList;
        activeRing = GlobalControl.Instance.activeRing;
    }

    public void SaveRings()
    {
        GlobalControl.Instance.ringList = ringList;
        GlobalControl.Instance.activeRing = activeRing;
    }

    public List<Ring.RingType> GetRingList()
    {
        return ringList;
    }

    public void SetRingList(List<Ring.RingType> _ringList)
    {
        ringList = _ringList;
    }

    public void AddRing(Ring.RingType ringType){
        ringList.Add(ringType);
    }

    public void RemoveRing(Ring.RingType ringType){
        ringList.Remove(ringType);
    }

    public bool ContainsRing(Ring.RingType ringType){
        return ringList.Contains(ringType);
    }

    public Ring.RingType GetActiveRing(){
        return activeRing;
    }

    public void SetActiveRing(Ring.RingType ringType){
        activeRing = ringType;
    }

    public void ChangeRing(){
        List<Ring.RingType> silverRings = new List<Ring.RingType>();
        foreach(Ring.RingType ring in ringList){
            if(ring == Ring.RingType.RedSilver || ring == Ring.RingType.BlueSilver || ring == Ring.RingType.GreenSilver){
                silverRings.Add(ring);
            }
        }
        int silverLength = silverRings.Count;
        int currIndex = 0;
        for(int i = 0; i < silverRings.Count; i++){
            if(silverRings[i] == activeRing){
                currIndex = i;
                break;
            }
        }

        if(silverLength == 2){
            if(currIndex == 0){
                activeRing = silverRings[1];
                Debug.Log(activeRing);
            }
            else{
                activeRing = silverRings[0];
                Debug.Log(activeRing);
            }
        }
        else if(silverLength == 3){
            if(currIndex == 0){
                activeRing = silverRings[1];
                Debug.Log(activeRing);
            }
            else if(currIndex == 1){
                activeRing = silverRings[2];
                Debug.Log(activeRing);
            }
            else{
                activeRing = silverRings[0];
                Debug.Log(activeRing);
            }
        }

        // int currIndex = 0;
        // for(int i = 0; i < ringList.length; i++){
        //     if(currRing == ringList[i].GetRingType()){
        //         currIndex = i;
        //         break;
        //     }
        // }

    }


    private void isPickedUp(){
        Ring ring = gameObject.GetComponent<Ring>();
        if(ring != null){
            Destroy(ring.gameObject);
        }
    }
}
