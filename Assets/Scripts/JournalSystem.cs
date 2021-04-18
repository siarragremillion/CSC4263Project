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
        journals = GlobalControl.Instance.journals;

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

    public void SaveJournals()
    {
        GlobalControl.Instance.journals = journals;
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
