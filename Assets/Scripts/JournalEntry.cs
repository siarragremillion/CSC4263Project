using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalEntry
{
    public string Title { get; set; }

    public string Content { get; set; }

    public string Author { get; set; }

    public string Date { get; set; }

    public bool hasInJournal { get; set; }
    public bool isAdded { get; set; }
}
