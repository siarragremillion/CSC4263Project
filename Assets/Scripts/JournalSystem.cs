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
    private bool isInSecondHalf;
    private bool backButtonAdded;
    private bool cached;

    [SerializeField] Color highlightedColor;
    [SerializeField] Color defaultColor;

    public UIManager uiManager;

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
                Title = "Rings",
                Content = @"When I first heard of this cave, I was told never to go in, for those who do, never come out.  I’ve yet to determine why that is.
In fact, it would seem quite the opposite given my discoveries thus far, because I've found something!

A ring, that imbues power!  It sounds like something out of a novel, yet here I am, holding it.
When I wear it, it seems my steps tread so softly, almost like I could walk on nothing at all.


Almost.  Attempts to fly or glide have failed.  It seems I still need the slightest resistance.",
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
                Title = "Test1",
                Content = @"Test1",
                Author = "",
                hasInJournal = false,
                isAdded = false
            },
            new JournalEntry {
                Title = "test2",
                Content = @"test2",
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

        if (titleCounter > 7)
        {

            if (isInSecondHalf)
            {
                JournalTitlesTexts[0].text = "...";
                JournalTitles.Add("...");
                for (int i = 6; i < journals.Count; i++)
                {
                    if (journals[i].hasInJournal && !journals[i].isAdded)
                    {
                        JournalTitlesTexts[i - 5].text = journals[i].Title;
                        JournalTitles.Add(journals[i].Title);

                        journals[i].isAdded = true;

                        titleCounter++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    if (journals[i].hasInJournal && !journals[i].isAdded)
                    {
                        JournalTitlesTexts[i].text = journals[i].Title;
                        JournalTitles.Add(journals[i].Title);

                        journals[i].isAdded = true;

                        titleCounter++;
                    }
                }
                JournalTitlesTexts[6].text = "...";
                JournalTitles.Add("...");
            }
            if (!backButtonAdded)
            {
                JournalTitles.Add(BackButton.text);
                backButtonAdded = true;
            }
        }
        else
        {
            for (int i = 0; i < journals.Count; i++)
            {
                if (journals[i].hasInJournal && !journals[i].isAdded)
                {

                        JournalTitlesTexts[i].text = journals[i].Title;
                        JournalTitles.Add(journals[i].Title);

                        journals[i].isAdded = true;

                        titleCounter++;
                    
                }
            }

            if (!backButtonAdded)
            {
                JournalTitles.Add(BackButton.text);
                backButtonAdded = true;
            }
        }
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
        Debug.Log(selectedText);
        if (selectedText.Equals("<"))
        {
            JournalSelector.SetActive(false);
            uiManager.ReEnterPause();
        }
        else if (selectedText.Equals("..."))
        {
            // Show next page....
            isInSecondHalf = !isInSecondHalf;
            cached = false;
        }
        else
        {
            if (isInSecondHalf)
            {
                JournalContent.text = journals[journalNumber + 5].Content;
                JournalContent.gameObject.SetActive(true);
            }
            else
            {
                JournalContent.text = journals[journalNumber].Content;
                JournalContent.gameObject.SetActive(true);
            }
        }
    }
}
