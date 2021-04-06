using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalSystem : MonoBehaviour
{
    [SerializeField]
    public List<(JournalEntry entry, bool hasInJournal)> journals = new List<(JournalEntry entry, bool hasInJournal)>
        {
            (new JournalEntry {
                Title = "Help!!!",
                Content = "",
                Author = ""
            }, false),
            (new JournalEntry
            {
                Title = "Rings",
                Content = @"When I first heard of this cave, I was told never to go in, for those who do, never come out.  I’ve yet to determine why that is.
In fact, it would seem quite the opposite given my discoveries thus far, because I've found something!

A ring, that imbues power!  It sounds like something out of a novel, yet here I am, holding it.
When I wear it, it seems my steps tread so softly, almost like I could walk on nothing at all.


Almost.  Attempts to fly or glide have failed.  It seems I still need the slightest resistance.",
                Author = ""
            }, false),
            (new JournalEntry
            {
                Title = "Artifacts",
                Content = @"I’ve had a strange idea, terribly strange I must admit.  I see across this stream, an artifact.  The door to move forward is locked, but the door also has a indention that looks to hold one of those things quite nicely.  I think that’s the ticket out, or, I suppose in.

The strange part.  Maybe I’m going mad…but I’d bet this ring will let me get across the stream rather nicely…",
                Author = ""
            }, false)
        };

    [SerializeField] GameObject JournalSelector;
    [SerializeField] public List<Text> titleTexts;
    [SerializeField] public Text JournalContent;

    [SerializeField] public bool InJournal;

    // Start is called before the first frame update
    void Start()
    {
        JournalContent.gameObject.SetActive(false);
        for (int i = 0; i < journals.Count; i++)
        {
            titleTexts[i].text = journals[i].entry.Title;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InJournal)
        {

        }
    }
}
