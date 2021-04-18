using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalSystem : MonoBehaviour
{
    public List<JournalEntry> journals;
    [SerializeField] GameObject JournalSelector;
    [SerializeField] List<Text> JournalTitlesTexts;
    [SerializeField] List<string> JournalTitles;
    [SerializeField] public Text JournalContent;
    [SerializeField] public Text BackButton;

    [SerializeField] public bool InJournal;

    private int selector;
    private int titleCounter;
    private bool backButtonAdded;
    private bool cached;

    [SerializeField] Color highlightedColor;
    [SerializeField] Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        journals = new List<JournalEntry>
        {
            new JournalEntry {
                Title = "Help!!!",
                Content = @"I'm trapped at the bottom of this cave. I was searching for the secrets hidden within. Please come find me! You can switch weapons by pressing the E key.",
                Author = "",
                hasInJournal = true,
                isAdded = false
            },
            new JournalEntry
            {
                Title = "Water Ring",
                Content = @"When I first heard of this cave, I was told never to go in, for those who do, never come out.  I’ve yet to determine why that is.
In fact, it would seem quite the opposite given my discoveries thus far, because I've found something!

A ring, that imbues power!  It sounds like something out of a novel, yet here I am, holding it.
When I wear it, it seems my steps tread so softly, almost like I could walk on nothing at all.


Almost.  Attempts to fly or glide have failed.  It seems I still need the slightest resistance.",
                Author = "",
                hasInJournal = false,
                isAdded = false
            },
            new JournalEntry {
                Title = "Fire Ring",
                Content = @"When holding this ring I feel the power of a flame. I wonder if I would feel the pain of fire? Let me try it out.",
                Author = "",
                hasInJournal = false,
                isAdded = false
            },
            new JournalEntry {
                Title = "Earth Ring",
                Content = @"This ring gives me the strength of an ox! I bet I could move that boulder, I bet it could go for miles. ",
                Author = "",
                hasInJournal = false,
                isAdded = false
            },
            new JournalEntry
            {
                Title = "Artifacts",
                Content = @"I’ve had a strange idea, terribly strange I must admit.  I see across this stream, an artifact.  The door to move forward is locked, but the door also has a indention that looks to hold one of those things quite nicely.  I think that’s the ticket out, or, I suppose in.

The strange part.  Maybe I’m going mad…but I’d bet this ring will let me get across the stream rather nicely…",
                Author = "",
                hasInJournal = false,
                isAdded = false
            },
            new JournalEntry {
                Title = "test3",
                Content = @"mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm",
                Author = "",
                hasInJournal = false,
                isAdded = false
            },
            new JournalEntry {
                Title = "test4",
                Content = @"test4",
                Author = "",
                hasInJournal = false,
                isAdded = false
            },
            new JournalEntry {
                Title = "test5",
                Content = @"test5",
                Author = "",
                hasInJournal = false,
                isAdded = false
            }
        };

        HideTitles();

        titleCounter = 0;

        JournalContent.gameObject.SetActive(false);

        JournalOrganization();
    }

    // Update is called once per frame
    void Update()
    {
        if (InJournal)
        {
            if (!cached)
            {
                JournalOrganization();
            }

            HandleJournalSelection();
        }

    }

    public void SetUp()
    {
        JournalSelector.SetActive(true);
        ShowTitles();
        InJournal = true;
    }

    public void FindJournal(int journalNumber)
    {
        journals[journalNumber].hasInJournal = true;
        cached = false;
    }

    public void JournalOrganization()
    {
        selector = 0;
        JournalTitles = new List<string>();
        backButtonAdded = false;
        foreach (var item in JournalTitlesTexts)
        {
            if (!item.text.Equals("<"))
                item.text = "";
        }
        foreach (var item in journals)
        {
            item.isAdded = false;
        }
        int journalSelectorTextIndex = 0;
        for (int i = 0; i < journals.Count; i++)
        {
            if (journals[i].hasInJournal && !journals[i].isAdded)
            {

                JournalTitlesTexts[journalSelectorTextIndex].text = journals[i].Title;
                JournalTitles.Add(journals[i].Title);

                journals[i].isAdded = true;

                titleCounter++;
                journalSelectorTextIndex++;
            }

        }

        if (!backButtonAdded)
        {
            JournalTitles.Add(BackButton.text);
            backButtonAdded = true;
        }
        ShowTitles();
        cached = true;
    }

    private void HideTitles()
    {
        foreach (var item in JournalTitlesTexts)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void ShowTitles()
    {
        var limit = 0;
        if (titleCounter > JournalTitlesTexts.Count)
        {
            limit = JournalTitlesTexts.Count - 1;
        }
        else
        {
            limit = titleCounter;
        }
        for (int i = 0; i < limit; i++)
        {
            JournalTitlesTexts[i].gameObject.SetActive(true);
        }
        JournalTitlesTexts[7].gameObject.SetActive(true);
    }

    public void HandleJournalSelection()
    {
        if (Input.GetKeyDown(KeyCode.S) && selector + 1 < JournalTitles.Count)
        {
            selector++;
        }
        else if (Input.GetKeyDown(KeyCode.W) && selector > 0)
        {
            selector--;
        }

        UpdateItemSelection(selector, JournalTitlesTexts);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ItemSelected(JournalTitles[selector], selector);
        }
    }

    public void UpdateItemSelection(int selectedItem, List<Text> selectorTexts)
    {
        if (selectedItem == JournalTitles.Count - 1)
        {
            selectorTexts[7].color = highlightedColor;
        }
        else
        {
            selectorTexts[7].color = defaultColor;
        }
        for (int i = 0; i < selectorTexts.Count - 1; i++)
        {
            if (i == selectedItem)
            {

                selectorTexts[i].color = highlightedColor;
            }
            else
            {
                selectorTexts[i].color = defaultColor;
            }
        }
    }

    public void ItemSelected(string selectedText, int journalNumber)
    {
        //Debug.Log(selectedText);
        if (selectedText.Equals("<"))
        {
            JournalSelector.SetActive(false);
            var uiManager = GameObject.FindObjectOfType<UIManager>();
            InJournal = false;
            uiManager.ReEnterPause();
        }
        else
        {
            var journal = journals.Find(u => u.Title.Equals(selectedText));
            if (journal != null)
            {
                JournalContent.text = journal.Content;
                JournalContent.gameObject.SetActive(true);
            }
        }
    }
}
