using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemHandler : MonoBehaviour
{

    Text gemDisplayCount;
    public static int gemAmount;
    public static int maxCoinAmount;

    public Rocky rocky;

    // Start is called before the first frame update
    void Start()
    {
        //gemAmount = rocky.crystals;
        gemDisplayCount = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //gemAmount = rocky.crystals;
        gemDisplayCount.text = gemAmount.ToString();
        //rocky.crystals = gemAmount;
    }
}
