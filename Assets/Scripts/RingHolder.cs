using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingHolder : MonoBehaviour
{
    [SerializeField] private List<Ring.RingType> ringList;

    private void Awake(){
        ringList = new List<Ring.RingType>();
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


    private void OnTriggerEnter2D(Collider2D other){
        Ring ring = other.GetComponent<Ring>();
        if(ring != null){
            AddRing(ring.GetRingType());
            Destroy(ring.gameObject);
        }
    }
}
