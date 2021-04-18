using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Ring;

public class RingUI : MonoBehaviour
{

    public Image ringImage;
    public List<Sprite> ringSprites;

    public RingType currentRing;

    public Rocky rocky;
    
    // Start is called before the first frame update
    void Start()
    {
        ringImage.sprite = ringSprites[SetCurrentRing()];
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRing != rocky.GetComponent<RingHolder>().GetActiveRing())
        {
            ringImage.sprite = ringSprites[SetCurrentRing()];
        }

        //changing rings
        if (Input.GetKeyDown(KeyCode.K))
        {
            ringImage.sprite = ringSprites[SetCurrentRing()];
        }


    }

    public int SetCurrentRing()
    {
        RingType ring = rocky.GetComponent<RingHolder>().GetActiveRing();
        Debug.Log(ring);
        if (ring == RingType.none)
        {
            Debug.Log("No rings have been collected");
            return 0;
        }
        else
        {
            rocky.GetComponent<RingHolder>().ChangeRing();
            ring = rocky.GetComponent<RingHolder>().GetActiveRing();
            int ringCode = 0;
            if (ring == RingType.RedSilver)
            {
                currentRing = RingType.RedSilver;
                ringCode = 1;
            }
            else if (ring == RingType.BlueSilver)
            {
                currentRing = RingType.BlueSilver;
                ringCode = 2;
            }
            else if (ring == RingType.GreenSilver)
            {
                currentRing = RingType.GreenSilver;
                ringCode = 3;
            }

            return ringCode;
        }
    }
}
