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
    public List<Artifact.ArtifactType> artifactList { get; set; }

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
        swordPower = 3;
        gunPower = 2;
        MaxHealth = 3;
        crystals = 30;
        maxCrystals = 99;
        Health = MaxHealth;
        currentWeapon = 0;
        hasDrink = false;
        hasFood = false;
        canPause = true;
        alive = true;
        currentLevel = 1;
        ringList = new List<Ring.RingType>();
        artifactList = new List<Artifact.ArtifactType>();
        journals = new List<JournalEntry>
        {
            new JournalEntry {
                Title = "Help!!!",
                Content = @"Rocky,
I�m taking a trip to look into that cave we spoke about last spring.
I know you said it was dangerous and not worth it, but this needs to be examined. 
If I�m not back in a week�well, I might need your help�
- Chris 
PS: Yes, I remember how to switch weapons with the E key.
",
                Author = "",
                hasInJournal = true,
                isAdded = false
            },
            new JournalEntry {
                Title = "Vendors",
                Content = @"Trees!  Imagine, trees that speak.
Well, I suppose I don�t have to anymore.
Shrewd trees nonetheless!
But to be fair,
the fruit they bear, 
seems to be worth the fare!
haHA!  I�m a poet now too!

-Chris, the poet",
                Author = "",
                hasInJournal = true,
                isAdded = false
            },
            new JournalEntry
            {
                Title = "Water Ring",
                Content = @"Another ring? 
This one seems different, apart from its color.
Again, though gem is blue, it doesn�t seem to be a sapphire.
But I feel lighter.  Perhaps just light enough?
--
Attempts to fly have failed.
It seems I still need a bit of resistance.
-Chris",
                Author = "",
                hasInJournal = false,
                isAdded = false
            },
            new JournalEntry {
                Title = "Fire Ring",
                Content = @"A third ring!
This one has a red gem,
But this definitely isn�t a ruby.
It�s terribly cold, icy even.
--
I�ve just discovered the purpose!
Upon failing at cooking,
I didn�t burn myself like I should have�

-Chris",
                Author = "",
                hasInJournal = false,
                isAdded = false
            },
            new JournalEntry {
                Title = "Earth Ring",
                Content = @"A ring.  

It�s got a green gem on it.
It doesn�t seem like an emerald, though�
I�m not quite sure what this is actually.
But upon wearing it, I feel�
...stronger!

-Chris",
                Author = "",
                hasInJournal = false,
                isAdded = false
            },
            new JournalEntry
            {
                Title = "Artifacts",
                Content = @"An artifact!  The dream of the archaeologist.
Oh Rocky, I hope you get to see this.
It�s like a totem!
With more strange gems�
--
And it seems to have a purpose!
There�s a door at the far end,
And it has a socket shaped just like this thing�",
                Author = "",
                hasInJournal = false,
                isAdded = false
            },
            new JournalEntry {
                Title = "Boss",
                Content = @"Oh man Rocky, you were right.

You�re cunning, so I'm sure you've made it this far.
Something loud, fiery, and big is around the corner, and I think it knows I�m here.
This might be the end of the line for me, old chap.
I�ll see you on the other side.

- Chris
",
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

    public void Death()
    {
        Health = MaxHealth;
    }
}
