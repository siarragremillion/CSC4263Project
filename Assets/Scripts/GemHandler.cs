using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemHandler : MonoBehaviour
{

    Text gemDisplayCount;
    public static int gemAmount;
    public static int maxCoinAmount;

    // Start is called before the first frame update
    void Start()
    {
        gemDisplayCount = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        gemDisplayCount.text = gemAmount.ToString();
    }
}
