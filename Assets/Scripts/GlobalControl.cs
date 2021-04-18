using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    public int Health { get; set; }

    public int MaxHealth { get; set; }

    public int crystals { get; set; }

    public int maxCrystals { get; set; }

    public int currentWeapon { get; set; }

    public bool alive { get; set; }

    public int swordPower { get; set; }
    public int gunPower { get; set; }

    public List<Ring.RingType> ringList { get; set; }

    public bool hasDrink { get; set; }
    public bool hasFood { get; set; }

    public bool canPause { get; set; }

    public int currentLevel { get; set; }

    public List<JournalEntry> journals { get; set; }

    public Ring ring { get; set; }

    public Ring.RingType activeRing;

    private void Start()
    {
    }

    void Awake()
    {
        Debug.Log("Is not cached");
        swordPower = 3;
        gunPower = 2;
        MaxHealth = 3;
        crystals = 10;
        maxCrystals = 99;
        Health = MaxHealth;
        currentWeapon = 0;
        hasDrink = false;
        hasFood = false;
        canPause = true;
        alive = true;
        currentLevel = 1;
        ringList = new List<Ring.RingType>();
        journals = journals = new List<JournalEntry>
        {
            new JournalEntry {
                Title = "Help!!!",
                Content = @"I'm trapped at the bottom of this cave. I was searching for the secrets hidden within. Please come find me! You can switch weapons by pressing the E key.",
                Author = "",
                hasInJournal = true,
                isAdded = false
            },
            new JournalEntry {
                Title = "Vendors",
                Content = @"Be fooled not by these trees... They bear scrumptious fruit.",
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
                Content = @"When holding this ring I feel the power of a flame. 

I wonder if I would feel the pain of fire? Let me try it out.",
                Author = "",
                hasInJournal = false,
                isAdded = false
            },
            new JournalEntry {
                Title = "Earth Ring",
                Content = @"This ring gives me the strength of an ox! 

I bet I could move that boulder, I bet it could go for miles. ",
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
                Title = "Boss",
                Content = @"test5",
                Author = "",
                hasInJournal = false,
                isAdded = false
            }
        };
        activeRing = Ring.RingType.none;

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
