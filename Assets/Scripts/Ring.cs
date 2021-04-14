using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public bool isActive;

    [SerializeField] private RingType ringType;
    public enum RingType {
        RedGold,    // double health
        BlueGold,   // double damage
        GreenGold,  // double food's impact
        RedSilver,  // walk through fire
        BlueSilver, // walk on water
        GreenSilver, // walk through boulders
        none
    }

    public RingType GetRingType() {
        return ringType;
    }

}
