using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCreatorManager : MonoBehaviour
{
    List<string> genderNames = new List<string>() { "Please select a gender", "Male", "Female"};
    List<string> raceNames = new List<string>() { "Please select a race", "Human", "Elf", "Half Elf", "Dwarf", "Gnome", "Halfling" };
    List<string> curClassNames = new List<string>();

    List<string> curAlignmentNames = new List<string>();
    List<string> alignmentNames = new List<string>() { "Please select an alignment", "Lawful Good", "Lawful Neutral", "Lawful Evil", "Neutral Good", "True Neutral", "Neutral Evil", "Chaotic Good", "Chaotic Neutral", "Chaotic Evil" };
    List<string> clericAlignmentNames = new List<string>() { "Please select an alignment", "Lawful Good", "Lawful Neutral", "Neutral Good", "True Neutral", "Chaotic Good", "Chaotic Neutral" };
    List<string> paladinAlignmentNames = new List<string>() { "Please select an alignment", "Lawful Good", };

    /*public enum GENDER { Male, Female };
    public enum RACE { Human, Elf, Half_Elf, Dwarf, Gnome, Halfling };
    public enum CLASS { Cleric, Fighter, Ranger, Mage, Paladin, Thief, Fighter_Cleric, Fighter_Mage, Fighter_Thief, Mage_Thief, Thief_Mage, Cleric_Thief, Cleric_Ranger, Fighter_Mage_Thief, Fighter_Mage_Cleric };
    public enum ALIGNMENT { Lawful_Good, Lawful_Neutral, Lawful_Evil, Neutral_Good, True_Neutral, Neutral_Evil, Chaotic_Good, Chaotic_Neutral, Chaotic_Evil };
    */

    // Character Panels
    public InputField nameField;
    public Image genderPanel;
    public Image racePanel;
    public Image classPanel;
    public Image alignmentPanel;

    // Character Dropdowns
    public TMP_Dropdown genderDropdown;
    public TMP_Dropdown raceDropdown;
    public TMP_Dropdown classDropdown;
    public TMP_Dropdown alignmentDropdown;

    // Character selections text
    public Text characterNameText;
    public Text genderNameText;
    public Text raceNameText;
    public Text classNameText;
    public Text alignmentNameText;

    // Selections showing in stats change page
    public Text finalGenderNameText;
    public Text finalRaceNameText;
    public Text finalClassNameText;
    public Text finalLevelText;
    public Text finalCharacterNameText;

    // Current Stats
    private int currentStrength = 8;
    private int currentDexterity = 8;
    private int currentIntelligence = 8;
    private int currentWisdom = 8;
    private int currentConstitution = 8;
    private int currentCharisma = 8;
    private int currentMaxHealth = 10;

    // Stats
    public Text strValueText;
    public Text dexValueText;
    public Text intValueText;
    public Text wisValueText;
    public Text conValueText;
    public Text chrValueText;
    public Text healthValueText;

    // Buttons
    public Button rollStatsButton;
    public Button createCharacterButton;

    // Character setup variables
    [SerializeField] private CharacterStats.GENDER _characterGenderOptions;
    [SerializeField] private CharacterStats.RACE _characterRaceOptions;
    [SerializeField] private CharacterStats.CLASS _characterClassOptions;
    [SerializeField] private CharacterStats.ALIGNMENT _characterAlignmentOptions;

    // Race ability modifiers
    private int _maxStrength;
    private int _maxDexterity;
    private int _maxIntelligence;
    private int _maxWisdom;
    private int _maxConstitution;
    private int _maxCharisma;
    private int _maxHP;

    private GameObject newCharacter;

    // Start is called before the first frame update
    void Start()
    {
        newCharacter = GameObject.FindGameObjectWithTag("Player") ;
        PopulateGenderDropdown();
        PopulateRaceDropdown();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateClassLevelsText(int singleClass)
    {
        finalLevelText.text = singleClass.ToString();
    }

    public void UpdateClassLevelsText(int firstClass, int secondClass)
    {
        finalLevelText.text = firstClass.ToString() + " / " + secondClass;
    }

    public void UpdateClassLevelsText(int firstClass, int secondClass, int thirdClass)
    {
        finalLevelText.text = firstClass.ToString() + " / " + secondClass.ToString() + " / " + thirdClass.ToString() ;
    }

    public void SelectName()
    {
        Debug.Log(nameField.text + " selected as character name.");
        //newCharacter.characterName = nameField.text;
        finalCharacterNameText.text = nameField.text;
    }

    public void SelectGender(int index)
    {
        genderNameText.text = genderNames[index];
        // Get the current gender 

        // Set the current characters gender option to it
        if(index == 0)
        {
            genderNameText.color = Color.red;
        }
        else if(genderNameText.text == "Male")
        {
            _characterGenderOptions = CharacterStats.GENDER.Male;
        }
        else if(genderNameText.text == "Female")
        {
            _characterGenderOptions = CharacterStats.GENDER.Female;
        }
        else
        {
            Debug.LogError("Incorrect selection??");
        }
        
        Debug.Log(_characterGenderOptions.ToString() + " gender selected.. dropdown value: " + index);

        // Make the next selection panel interactable
        racePanel.gameObject.SetActive(true);
        // Make the gender panel uninteractable unless the player goes back from next selection. 
        // genderPanel.GetComponent<Dropdown>().interactable = false;

        finalGenderNameText.text = genderNameText.text;
    }

    public void SelectRace(int index)
    {
        raceNameText.text = raceNames[index];
        // Get the current gender 

        // Set the current characters gender option to it
        if (index == 0)
        {
            raceNameText.color = Color.red;
        }
        else if (raceNameText.text == "Human")
        {
            _characterRaceOptions = CharacterStats.RACE.Human;

            classDropdown.options.Clear();
            curClassNames.Clear();
            curClassNames = Human.classNames;
            classDropdown.AddOptions(curClassNames);
            Debug.Log(_characterRaceOptions.ToString() + " race selected. Loading available classes" );
        }
        else if (raceNameText.text == "Elf")
        {
            _characterRaceOptions = CharacterStats.RACE.Elf;

            classDropdown.options.Clear();
            curClassNames.Clear();
            curClassNames = Elf.classNames;
            classDropdown.AddOptions(curClassNames);

            Debug.Log(_characterRaceOptions.ToString() + " race selected. Loading available classes");
        }
        else if (raceNameText.text == "Half Elf")
        {
            _characterRaceOptions = CharacterStats.RACE.Half_Elf;

            classDropdown.options.Clear();
            curClassNames.Clear();
            curClassNames = HalfElf.classNames;
            classDropdown.AddOptions(curClassNames);

            Debug.Log(_characterRaceOptions.ToString() + " race selected. Loading available classes");
        }
        else if (raceNameText.text == "Dwarf")
        {
            _characterRaceOptions = CharacterStats.RACE.Dwarf;

            classDropdown.options.Clear();
            curClassNames.Clear();
            curClassNames = Dwarf.classNames;
            classDropdown.AddOptions(curClassNames);

            Debug.Log(_characterRaceOptions.ToString() + " race selected. Loading available classes");
        }
        else if (raceNameText.text == "Gnome")
        {
            _characterRaceOptions = CharacterStats.RACE.Gnome;

            classDropdown.options.Clear();
            curClassNames.Clear();
            curClassNames = Gnome.classNames;
            classDropdown.AddOptions(curClassNames);

            Debug.Log(_characterRaceOptions.ToString() + " race selected. Loading available classes");
        }
        else if (raceNameText.text == "Halfling")
        {
            _characterRaceOptions = CharacterStats.RACE.Halfling;

            classDropdown.options.Clear();
            curClassNames.Clear();
            curClassNames = Halfling.classNames;
            classDropdown.AddOptions(curClassNames);

            Debug.Log(_characterRaceOptions.ToString() + " race selected. Loading available classes");
        }
        else
        {
            Debug.LogError("Incorrect selection??");
        }

        Debug.Log(_characterRaceOptions.ToString() + " race selected.. dropdown value: " + index);

        // Make the next selection panel interactable
        classPanel.gameObject.SetActive(true);
        // Make the race panel uninteractable unless the player goes back from next selection. 
        // racePanel.GetComponent<Dropdown>().interactable = false;

        finalRaceNameText.text = raceNameText.text;
    }

    public void SelectClass(int index)
    {
        classNameText.text = curClassNames[index];
        // Get the current gender 

        // Set the current characters gender option to it
        if (index == 0)
        {
            classNameText.color = Color.red;
        }
        else if (classNameText.text == "Cleric")
        {
            _characterClassOptions = CharacterStats.CLASS.Cleric;

            alignmentDropdown.options.Clear();
            curAlignmentNames = clericAlignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);

        }
        else if (classNameText.text == "Fighter")
        {
            _characterClassOptions = CharacterStats.CLASS.Fighter;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Ranger")
        {
            _characterClassOptions = CharacterStats.CLASS.Ranger;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Mage")
        {
            _characterClassOptions = CharacterStats.CLASS.Mage;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Paladin")
        {
            _characterClassOptions = CharacterStats.CLASS.Paladin;

            alignmentDropdown.options.Clear();
            curAlignmentNames = paladinAlignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Thief")
        {
            _characterClassOptions = CharacterStats.CLASS.Thief;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Fighter/Thief")
        {
            _characterClassOptions = CharacterStats.CLASS.Fighter_Thief;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Fighter/Cleric")
        {
            _characterClassOptions = CharacterStats.CLASS.Fighter_Cleric;

            alignmentDropdown.options.Clear();
            curAlignmentNames = clericAlignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Fighter/Mage")
        {
            _characterClassOptions = CharacterStats.CLASS.Fighter_Mage;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Cleric/Ranger")
        {
            _characterClassOptions = CharacterStats.CLASS.Cleric_Ranger;

            alignmentDropdown.options.Clear();
            curAlignmentNames = clericAlignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Cleric/Thief")
        {
            _characterClassOptions = CharacterStats.CLASS.Cleric_Thief;

            alignmentDropdown.options.Clear();
            curAlignmentNames = clericAlignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Mage/Thief")
        {
            _characterClassOptions = CharacterStats.CLASS.Mage_Thief;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Thief/Mage")
        {
            _characterClassOptions = CharacterStats.CLASS.Thief_Mage;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Fighter/Mage/Thief")
        {
            _characterClassOptions = CharacterStats.CLASS.Fighter_Mage_Thief;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Fighter/Mage/Cleric")
        {
            _characterClassOptions = CharacterStats.CLASS.Fighter_Mage_Cleric;

            alignmentDropdown.options.Clear();
            curAlignmentNames = clericAlignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else
        {
            Debug.LogError("Incorrect selection??");
        }

        Debug.Log(_characterClassOptions.ToString() + " class selected.. dropdown value: " + index);

        // Make the next selection panel interactable
        alignmentPanel.gameObject.SetActive(true);
        // Make the class panel uninteractable unless the player goes back from next selection. 
        // classPanel.GetComponent<Dropdown>().interactable = false;

        finalClassNameText.text = classNameText.text;
    }

    public void SelectAlignment(int index)
    {
        alignmentNameText.text = curAlignmentNames[index];
        // Get the current gender 

        // Set the current characters gender option to it
        if (index == 0)
        {
            alignmentNameText.color = Color.red;
        }
        else
        {
            SetupPlayerRaceScripts();
            SetupPlayerClassScripts();
            //SetupPlayerScripts();
            RollDiceStats();
        }
    }

    void PopulateGenderDropdown()
    {
        genderDropdown.ClearOptions();

        genderDropdown.AddOptions(genderNames);
    }

    void PopulateRaceDropdown()
    {
        raceDropdown.ClearOptions();

        raceDropdown.AddOptions(raceNames);
    }

    public void PopulateClassDropdown(int index)
    {
        curClassNames.Clear();
        classDropdown.ClearOptions();
        if (index == 0)
        {
            classNameText.color = Color.red;
        }
        else if(_characterRaceOptions == CharacterStats.RACE.Human)
        {
            classDropdown.AddOptions(Human.classNames);
        }
        else if (_characterRaceOptions == CharacterStats.RACE.Elf)
        {
            classDropdown.AddOptions(Elf.classNames);
        }
        else if (_characterRaceOptions == CharacterStats.RACE.Half_Elf)
        {
            classDropdown.AddOptions(HalfElf.classNames);
        }
        else if (_characterRaceOptions == CharacterStats.RACE.Dwarf)
        {
            classDropdown.AddOptions(Dwarf.classNames);
        }
        else if (_characterRaceOptions == CharacterStats.RACE.Gnome)
        {
            classDropdown.AddOptions(Gnome.classNames);
        }
        else if (_characterRaceOptions == CharacterStats.RACE.Halfling)
        {
            classDropdown.AddOptions(Halfling.classNames);
        }
        else
        {
            Debug.LogError("Incorrect class selected!");
        }
        
        

    }

    public void PopulateAlignmentDropdown(int index)
    {
        alignmentDropdown.ClearOptions();

        if (index == 0)
        {
            alignmentNameText.color = Color.red;
        }
        else if(_characterClassOptions == CharacterStats.CLASS.Cleric || 
                _characterClassOptions == CharacterStats.CLASS.Cleric_Ranger ||
                _characterClassOptions == CharacterStats.CLASS.Cleric_Thief ||
                _characterClassOptions == CharacterStats.CLASS.Fighter_Cleric ||
                _characterClassOptions == CharacterStats.CLASS.Fighter_Mage_Cleric)
        {
            alignmentDropdown.AddOptions(clericAlignmentNames);
        }
        else if(_characterClassOptions == CharacterStats.CLASS.Paladin)
        {
            alignmentDropdown.AddOptions(paladinAlignmentNames);
        }
        else
        {
            alignmentDropdown.AddOptions(alignmentNames);
        }

        
    }


    public void SelectRace()
    {
        // **switch statement for race picked... **

        classPanel.gameObject.SetActive(true);
        racePanel.GetComponent<Dropdown>().interactable = false;
    }

    public void SelectClass()
    {
        // 
        alignmentPanel.gameObject.SetActive(true);
        classPanel.GetComponent<Dropdown>().interactable = false;
    }

    public void SelectAlignment()
    {
        // set the stats panel active
    }

    public void UpdateCharacterStatsText()
    {
        strValueText.text = currentStrength.ToString();
        dexValueText.text = currentDexterity.ToString();
        intValueText.text = currentIntelligence.ToString();
        wisValueText.text = currentWisdom.ToString();
        conValueText.text = currentConstitution.ToString();
        chrValueText.text = currentCharisma.ToString();
        healthValueText.text = currentMaxHealth.ToString();
    }

    public void GetRaceModifiers()
    {
        if(_characterRaceOptions == CharacterStats.RACE.Human)
        {
            _maxStrength = 18 + Human._raceModStrength;
            _maxDexterity = 18 + Human._raceModDexterity;
            _maxIntelligence = 18 + Human._raceModIntelligence;
            _maxWisdom = 18 + Human._raceModWisdom;
            _maxConstitution = 18 + Human._raceModConstitution;
            _maxCharisma = 18 + Human._raceModCharisma;
        }
        else if(_characterRaceOptions == CharacterStats.RACE.Elf)
        {
            _maxStrength = 18 + Elf._raceModStrength;
            _maxDexterity = 18 + Elf._raceModDexterity;
            _maxIntelligence = 18 + Elf._raceModIntelligence;
            _maxWisdom = 18 + Elf._raceModWisdom;
            _maxConstitution = 18 + Elf._raceModConstitution;
            _maxCharisma = 18 + Elf._raceModCharisma;
        }
        else if (_characterRaceOptions == CharacterStats.RACE.Half_Elf)
        {
            _maxStrength = 18 + HalfElf._raceModStrength;
            _maxDexterity = 18 + HalfElf._raceModDexterity;
            _maxIntelligence = 18 + HalfElf._raceModIntelligence;
            _maxWisdom = 18 + HalfElf._raceModWisdom;
            _maxConstitution = 18 + HalfElf._raceModConstitution;
            _maxCharisma = 18 + HalfElf._raceModCharisma;
        }
        else if (_characterRaceOptions == CharacterStats.RACE.Dwarf)
        {
            _maxStrength = 18 + Dwarf._raceModStrength;
            _maxDexterity = 18 + Dwarf._raceModDexterity;
            _maxIntelligence = 18 + Dwarf._raceModIntelligence;
            _maxWisdom = 18 + Dwarf._raceModWisdom;
            _maxConstitution = 18 + Dwarf._raceModConstitution;
            _maxCharisma = 18 + Dwarf._raceModCharisma;
        }
        else if (_characterRaceOptions == CharacterStats.RACE.Gnome)
        {
            _maxStrength = 18 + Gnome._raceModStrength;
            _maxDexterity = 18 + Gnome._raceModDexterity;
            _maxIntelligence = 18 + Gnome._raceModIntelligence;
            _maxWisdom = 18 + Gnome._raceModWisdom;
            _maxConstitution = 18 + Gnome._raceModConstitution;
            _maxCharisma = 18 + Gnome._raceModCharisma;
        }
        else if (_characterRaceOptions == CharacterStats.RACE.Halfling)
        {
            _maxStrength = 18 + Halfling._raceModStrength;
            _maxDexterity = 18 + Halfling._raceModDexterity;
            _maxIntelligence = 18 + Halfling._raceModIntelligence;
            _maxWisdom = 18 + Halfling._raceModWisdom;
            _maxConstitution = 18 + Halfling._raceModConstitution;
            _maxCharisma = 18 + Halfling._raceModCharisma;
        }
    }
    
    

    // STATS BUTTONS
    public void IncreaseStrength()
    {
        int incrStrength = currentStrength + 1;
        if(incrStrength > _maxStrength)
        {
            Debug.Log("Max strength reached!");
        }
        else if(incrStrength <= _maxStrength)
        {
            currentStrength++;
            strValueText.text = currentStrength.ToString();
        }
    }

    public void DecreaseStrength()
    {
        int decrStrength = currentStrength - 1;
        if (decrStrength < 3)
        {
            Debug.Log("Min strength reached!");
        }
        else if (decrStrength > 3)
        {
            currentStrength--;
            strValueText.text = currentStrength.ToString();
        }
    }

    public void IncreaseDexterity()
    {
        int incrDexterity = currentDexterity + 1;
        if (incrDexterity > _maxDexterity)
        {
            Debug.Log("Max dexterity reached!");
        }
        else if (incrDexterity <= _maxDexterity)
        {
            currentDexterity++;
            dexValueText.text = currentDexterity.ToString();
        }
    }

    public void DecreaseDexterity()
    {
        int decrDexterity = currentDexterity - 1;
        if (decrDexterity < 3)
        {
            Debug.Log("Min dexterity reached!");
        }
        else if (decrDexterity > 3)
        {
            currentDexterity--;
            dexValueText.text = currentDexterity.ToString();
        }
    }

    public void IncreaseIntelligence()
    {
        int incrIntelligence = currentIntelligence + 1;
        if (incrIntelligence > _maxStrength)
        {
            Debug.Log("Max intelligence reached!");
        }
        else if (incrIntelligence <= _maxIntelligence)
        {
            currentIntelligence++;
            intValueText.text = currentIntelligence.ToString();
        }
    }

    public void DecreaseIntelligence()
    {
        int decrIntelligence = currentIntelligence - 1;
        if (decrIntelligence < 3)
        {
            Debug.Log("Min intelligence reached!");
        }
        else if (decrIntelligence > 3)
        {
            currentIntelligence--;
            intValueText.text = currentIntelligence.ToString();
        }
    }

    public void IncreaseWisdom()
    {
        int incrWisdom = currentWisdom + 1;
        if (incrWisdom > _maxWisdom)
        {
            Debug.Log("Max wisdom reached!");
        }
        else if (incrWisdom <= _maxWisdom)
        {
            currentWisdom++;
            wisValueText.text = currentWisdom.ToString();
        }
    }

    public void DecreaseWisdom()
    {
        int decrWisdom = currentWisdom - 1;
        if (decrWisdom < 3)
        {
            Debug.Log("Min wisdom reached!");
        }
        else if (decrWisdom > 3)
        {
            currentWisdom--;
            wisValueText.text = currentWisdom.ToString();
        }
    }

    public void IncreaseConstitution()
    {
        int incrConstitution = currentConstitution + 1;
        if (incrConstitution > _maxConstitution)
        {
            Debug.Log("Max constitution reached!");
        }
        else if (incrConstitution <= _maxConstitution)
        {
            currentConstitution++;
            conValueText.text = currentConstitution.ToString();
        }
    }

    public void DecreaseConstitution()
    {
        int decrConstitution = currentConstitution - 1;
        if (decrConstitution < 3)
        {
            Debug.Log("Min constitution reached!");
        }
        else if (decrConstitution > 3)
        {
            currentConstitution--;
            conValueText.text = currentConstitution.ToString();
        }
    }

    public void IncreaseCharisma()
    {
        int incrCharisma = currentCharisma + 1;
        if (incrCharisma > _maxCharisma)
        {
            Debug.Log("Max charisma reached!");
        }
        else if (incrCharisma <= _maxCharisma)
        {
            currentCharisma++;
            chrValueText.text = currentCharisma.ToString();
        }
    }

    public void DecreaseCharisma()
    {
        int decrCharisma = currentCharisma - 1;
        if (decrCharisma < 3)
        {
            Debug.Log("Min charisma reached!");
        }
        else if (decrCharisma > 3)
        {
            currentCharisma--;
            chrValueText.text = currentCharisma.ToString();
        }
    }

    public void IncreaseHP()
    {
        int incrHP = currentMaxHealth + 1;
        if (incrHP > _maxHP)
        {
            Debug.Log("Max HP reached!");
        }
        else if (incrHP <= _maxHP)
        {
            currentMaxHealth++;
            healthValueText.text = currentMaxHealth.ToString();
        }
    }

    public void DecreaseHP()
    {
        int decrHP = currentMaxHealth - 1;
        if (decrHP <= 1)
        {
            Debug.Log("Min HP reached!");
        }
        else if (decrHP > 2)
        {
            currentMaxHealth--;
            healthValueText.text = currentMaxHealth.ToString();
        }
    }

    public int GetConBonus()
    {
        int conBonus = currentConstitution - 10;
        Debug.Log("Current con bonus: " + conBonus.ToString());
        return conBonus;
    }

    /*void SumOfLevelRolls()
    {
        int totalSum = 0;
        CharacterClass[] classList = newCharacter.gameObject.GetComponents<CharacterClass>();
        foreach(CharacterClass characterClass in classList)
        {
            int hpRoll = UnityEngine.Random.Range(1, characterClass.RollLevelHitDice());
            totalSum += hpRoll;
            Debug.Log("Class: " + characterClass.name + " rolled a " + hpRoll + " out of " + characterClass.GetClassHitDice());
        }

    }*/


    /*int MaxOfAllClasses()
    {
        int totalSum = 0;
        CharacterClass[] classList = newCharacter.gameObject.GetComponents<CharacterClass>();
        foreach(CharacterClass characterClass in classList)
        {
            int maxHP = characterClass.GetClassHitDice() * characterClass.GetClassLevel();
            totalSum += maxHP + GetConBonus();
            Debug.Log("Maximum of " + characterClass.GetClassHitDice() + " by " + characterClass.GetClassLevel() + " levels in " + characterClass.name);
        }

        return totalSum;
    }*/

    int GetMaxBaseHP()
    {
        int maxBaseHP = 0;
        if(newCharacter.GetComponent<Fighter>())
        {
            maxBaseHP += (Fighter.classHitDice * newCharacter.GetComponent<Fighter>().currentClassLevel) + GetConBonus();
        }
        if (newCharacter.GetComponent<Cleric>())
        {
            maxBaseHP += (Cleric.classHitDice * newCharacter.GetComponent<Cleric>().currentClassLevel) + GetConBonus();
        }
        if (newCharacter.GetComponent<Mage>())
        {
            maxBaseHP += (Mage.classHitDice * newCharacter.GetComponent<Mage>().currentClassLevel) + GetConBonus();
        }
        if (newCharacter.GetComponent<Ranger>())
        {
            maxBaseHP += (Ranger.classHitDice * newCharacter.GetComponent<Ranger>().currentClassLevel) + GetConBonus();
        }
        if (newCharacter.GetComponent<Paladin>())
        {
            maxBaseHP += (Paladin.classHitDice * newCharacter.GetComponent<Paladin>().currentClassLevel) + GetConBonus();
        }
        if (newCharacter.GetComponent<Thief>())
        {
            maxBaseHP += (Thief.classHitDice * newCharacter.GetComponent<Thief>().currentClassLevel) + GetConBonus();
        }

        return maxBaseHP;
    }

    public void UpdateMaxBaseHP()
    {
        int maxBaseHP = 0;
        if (newCharacter.GetComponent<Fighter>())
        {
            maxBaseHP += (Fighter.classHitDice * newCharacter.GetComponent<Fighter>().currentClassLevel) + GetConBonus();
        }
        if (newCharacter.GetComponent<Cleric>())
        {
            maxBaseHP += (Cleric.classHitDice * newCharacter.GetComponent<Cleric>().currentClassLevel) + GetConBonus();
        }
        if (newCharacter.GetComponent<Mage>())
        {
            maxBaseHP += (Mage.classHitDice * newCharacter.GetComponent<Mage>().currentClassLevel) + GetConBonus();
        }
        if (newCharacter.GetComponent<Ranger>())
        {
            maxBaseHP += (Ranger.classHitDice * newCharacter.GetComponent<Ranger>().currentClassLevel + GetConBonus());
        }
        if (newCharacter.GetComponent<Paladin>())
        {
            maxBaseHP += (Paladin.classHitDice * newCharacter.GetComponent<Paladin>().currentClassLevel + GetConBonus());
        }
        if (newCharacter.GetComponent<Thief>())
        {
            maxBaseHP += (Thief.classHitDice * newCharacter.GetComponent<Thief>().currentClassLevel + GetConBonus());
        }

        _maxHP = maxBaseHP;

        UpdateCharacterStatsText();
    }

    public void SetupPlayerRaceScripts()
    {
        // Destroy any old race scripts
        if (newCharacter.GetComponent<Human>())
        {
            DestroyImmediate(newCharacter.GetComponent<Human>());
        }
        else if (newCharacter.GetComponent<Elf>())
        {
            DestroyImmediate(newCharacter.GetComponent<Elf>());
        }
        else if (newCharacter.GetComponent<HalfElf>())
        {
            DestroyImmediate(newCharacter.GetComponent<HalfElf>());
        }
        else if (newCharacter.GetComponent<Dwarf>())
        {
            DestroyImmediate(newCharacter.GetComponent<Dwarf>());
        }
        else if (newCharacter.GetComponent<Gnome>())
        {
            DestroyImmediate(newCharacter.GetComponent<Gnome>());
        }
        else if (newCharacter.GetComponent<Halfling>())
        {
            DestroyImmediate(newCharacter.GetComponent<Halfling>());
        }

        // Add the corresponding race script
        if (_characterRaceOptions == CharacterStats.RACE.Human)
        {
            newCharacter.gameObject.AddComponent<Human>();
        }
        else if (_characterRaceOptions == CharacterStats.RACE.Elf)
        {
            newCharacter.gameObject.AddComponent<Elf>();
        }
        else if (_characterRaceOptions == CharacterStats.RACE.Half_Elf)
        {
            newCharacter.gameObject.AddComponent<HalfElf>();
        }
        else if (_characterRaceOptions == CharacterStats.RACE.Dwarf)
        {
            newCharacter.gameObject.AddComponent<Dwarf>();
        }
        else if (_characterRaceOptions == CharacterStats.RACE.Gnome)
        {
            newCharacter.gameObject.AddComponent<Gnome>();
        }
        else if (_characterRaceOptions == CharacterStats.RACE.Halfling)
        {
            newCharacter.gameObject.AddComponent<Halfling>();
        }
    }

    public void SetupPlayerClassScripts()
    {
        // Remove the previous classes on the new character
        if (newCharacter.GetComponent<Fighter>())
        {
            DestroyImmediate(newCharacter.GetComponent<Fighter>());
        }
        else if (newCharacter.GetComponent<Cleric>())
        {
            DestroyImmediate(newCharacter.GetComponent<Cleric>());
        }
        else if (newCharacter.GetComponent<Ranger>())
        {
            DestroyImmediate(newCharacter.GetComponent<Ranger>());
        }
        else if (newCharacter.GetComponent<Mage>())
        {
            DestroyImmediate(newCharacter.GetComponent<Mage>());
        }
        else if (newCharacter.GetComponent<Paladin>())
        {
            DestroyImmediate(newCharacter.GetComponent<Paladin>());
        }
        else if (newCharacter.GetComponent<Thief>())
        {
            DestroyImmediate(newCharacter.GetComponent<Thief>());
        }
        

        // Add the correct classes
        if (_characterClassOptions == CharacterStats.CLASS.Fighter)
        {
            newCharacter.gameObject.AddComponent<Fighter>();
            newCharacter.gameObject.GetComponent<Fighter>().currentClassLevel = 3;

            UpdateClassLevelsText(newCharacter.gameObject.GetComponent<Fighter>().currentClassLevel);
        }
        else if (_characterClassOptions == CharacterStats.CLASS.Cleric)
        {
            newCharacter.gameObject.AddComponent<Cleric>();
            newCharacter.gameObject.GetComponent<Cleric>().currentClassLevel = 3;

            UpdateClassLevelsText(newCharacter.gameObject.GetComponent<Cleric>().currentClassLevel);
        }
        else if (_characterClassOptions == CharacterStats.CLASS.Ranger)
        {
            newCharacter.gameObject.AddComponent<Ranger>();
            newCharacter.gameObject.GetComponent<Ranger>().currentClassLevel = 3;

            UpdateClassLevelsText(newCharacter.gameObject.GetComponent<Ranger>().currentClassLevel);
        }
        else if (_characterClassOptions == CharacterStats.CLASS.Mage)
        {
            newCharacter.gameObject.AddComponent<Mage>();
            newCharacter.gameObject.GetComponent<Mage>().currentClassLevel = 3;

            UpdateClassLevelsText(newCharacter.gameObject.GetComponent<Mage>().currentClassLevel);
        }
        else if (_characterClassOptions == CharacterStats.CLASS.Paladin)
        {
            newCharacter.gameObject.AddComponent<Paladin>();
            newCharacter.gameObject.GetComponent<Paladin>().currentClassLevel = 3;

            UpdateClassLevelsText(newCharacter.gameObject.GetComponent<Paladin>().currentClassLevel);
        }
        else if (_characterClassOptions == CharacterStats.CLASS.Thief)
        {
            newCharacter.gameObject.AddComponent<Thief>();
            newCharacter.gameObject.GetComponent<Thief>().currentClassLevel = 3;

            UpdateClassLevelsText(newCharacter.gameObject.GetComponent<Thief>().currentClassLevel);
        }
        else if (_characterClassOptions == CharacterStats.CLASS.Cleric_Ranger)
        {
            newCharacter.gameObject.AddComponent<Cleric>();
            newCharacter.gameObject.GetComponent<Cleric>().classEXPMultiplier = 0.5f;
            newCharacter.gameObject.GetComponent<Cleric>().currentClassLevel = 2;
            newCharacter.gameObject.AddComponent<Ranger>();
            newCharacter.gameObject.GetComponent<Ranger>().classEXPMultiplier = 0.5f;
            newCharacter.gameObject.GetComponent<Ranger>().currentClassLevel = 2;

            UpdateClassLevelsText(newCharacter.gameObject.GetComponent<Cleric>().currentClassLevel, newCharacter.gameObject.GetComponent<Ranger>().currentClassLevel);
        }
        else if (_characterClassOptions == CharacterStats.CLASS.Cleric_Thief)
        {
            newCharacter.gameObject.AddComponent<Cleric>();
            newCharacter.gameObject.GetComponent<Cleric>().classEXPMultiplier = 0.5f;
            newCharacter.gameObject.GetComponent<Cleric>().currentClassLevel = 2;
            newCharacter.gameObject.AddComponent<Thief>();
            newCharacter.gameObject.GetComponent<Thief>().classEXPMultiplier = 0.5f;
            newCharacter.gameObject.GetComponent<Thief>().currentClassLevel = 2;

            UpdateClassLevelsText(newCharacter.gameObject.GetComponent<Cleric>().currentClassLevel, newCharacter.gameObject.GetComponent<Thief>().currentClassLevel);
        }
        else if (_characterClassOptions == CharacterStats.CLASS.Fighter_Cleric)
        {
            newCharacter.gameObject.AddComponent<Fighter>();
            newCharacter.gameObject.GetComponent<Fighter>().classEXPMultiplier = 0.5f;
            newCharacter.gameObject.GetComponent<Fighter>().currentClassLevel = 2;
            newCharacter.gameObject.AddComponent<Cleric>();
            newCharacter.gameObject.GetComponent<Cleric>().classEXPMultiplier = 0.5f;
            newCharacter.gameObject.GetComponent<Cleric>().currentClassLevel = 2;

            UpdateClassLevelsText(newCharacter.gameObject.GetComponent<Fighter>().currentClassLevel, newCharacter.gameObject.GetComponent<Cleric>().currentClassLevel);
        }
        else if (_characterClassOptions == CharacterStats.CLASS.Fighter_Mage)
        {
            newCharacter.gameObject.AddComponent<Fighter>();
            newCharacter.gameObject.GetComponent<Fighter>().classEXPMultiplier = 0.5f;
            newCharacter.gameObject.GetComponent<Fighter>().currentClassLevel = 2;
            newCharacter.gameObject.AddComponent<Mage>();
            newCharacter.gameObject.GetComponent<Mage>().classEXPMultiplier = 0.5f;
            newCharacter.gameObject.GetComponent<Mage>().currentClassLevel = 2;

            UpdateClassLevelsText(newCharacter.gameObject.GetComponent<Fighter>().currentClassLevel, newCharacter.gameObject.GetComponent<Mage>().currentClassLevel);
        }
        else if (_characterClassOptions == CharacterStats.CLASS.Fighter_Thief)
        {
            newCharacter.gameObject.AddComponent<Fighter>();
            newCharacter.gameObject.GetComponent<Fighter>().classEXPMultiplier = 0.5f;
            newCharacter.gameObject.GetComponent<Fighter>().currentClassLevel = 2;
            newCharacter.gameObject.AddComponent<Thief>();
            newCharacter.gameObject.GetComponent<Thief>().classEXPMultiplier = 0.5f;
            newCharacter.gameObject.GetComponent<Thief>().currentClassLevel = 2;

            UpdateClassLevelsText(newCharacter.gameObject.GetComponent<Fighter>().currentClassLevel, newCharacter.gameObject.GetComponent<Thief>().currentClassLevel);
        }
        else if (_characterClassOptions == CharacterStats.CLASS.Mage_Thief)
        {
            newCharacter.gameObject.AddComponent<Mage>();
            newCharacter.gameObject.GetComponent<Mage>().classEXPMultiplier = 0.5f;
            newCharacter.gameObject.GetComponent<Mage>().currentClassLevel = 2;
            newCharacter.gameObject.AddComponent<Thief>();
            newCharacter.gameObject.GetComponent<Thief>().classEXPMultiplier = 0.5f;
            newCharacter.gameObject.GetComponent<Thief>().currentClassLevel = 2;

            UpdateClassLevelsText(newCharacter.gameObject.GetComponent<Mage>().currentClassLevel, newCharacter.gameObject.GetComponent<Thief>().currentClassLevel);
        }
        else if (_characterClassOptions == CharacterStats.CLASS.Thief_Mage)
        {
            newCharacter.gameObject.AddComponent<Thief>();
            newCharacter.gameObject.GetComponent<Thief>().classEXPMultiplier = 0.5f;
            newCharacter.gameObject.GetComponent<Thief>().currentClassLevel = 2;
            newCharacter.gameObject.AddComponent<Mage>();
            newCharacter.gameObject.GetComponent<Mage>().classEXPMultiplier = 0.5f;
            newCharacter.gameObject.GetComponent<Mage>().currentClassLevel = 2;

            UpdateClassLevelsText(newCharacter.gameObject.GetComponent<Thief>().currentClassLevel, newCharacter.gameObject.GetComponent<Mage>().currentClassLevel);
        }
        else if (_characterClassOptions == CharacterStats.CLASS.Fighter_Mage_Thief)
        {
            newCharacter.gameObject.AddComponent<Fighter>();
            newCharacter.gameObject.GetComponent<Fighter>().classEXPMultiplier = 0.33f;
            newCharacter.gameObject.GetComponent<Fighter>().currentClassLevel = 1;
            newCharacter.gameObject.AddComponent<Mage>();
            newCharacter.gameObject.GetComponent<Mage>().classEXPMultiplier = 0.33f;
            newCharacter.gameObject.GetComponent<Mage>().currentClassLevel = 1;
            newCharacter.gameObject.AddComponent<Thief>();
            newCharacter.gameObject.GetComponent<Thief>().classEXPMultiplier = 0.33f;
            newCharacter.gameObject.GetComponent<Thief>().currentClassLevel = 1;

            UpdateClassLevelsText(newCharacter.gameObject.GetComponent<Fighter>().currentClassLevel, newCharacter.gameObject.GetComponent<Mage>().currentClassLevel, newCharacter.gameObject.GetComponent<Thief>().currentClassLevel);
        }
        else if (_characterClassOptions == CharacterStats.CLASS.Fighter_Mage_Cleric)
        {
            newCharacter.gameObject.AddComponent<Fighter>();
            newCharacter.gameObject.GetComponent<Fighter>().classEXPMultiplier = 0.33f;
            newCharacter.gameObject.GetComponent<Fighter>().currentClassLevel = 1;
            newCharacter.gameObject.AddComponent<Mage>();
            newCharacter.gameObject.GetComponent<Mage>().classEXPMultiplier = 0.33f;
            newCharacter.gameObject.GetComponent<Mage>().currentClassLevel = 1;
            newCharacter.gameObject.AddComponent<Cleric>();
            newCharacter.gameObject.GetComponent<Cleric>().classEXPMultiplier = 0.33f;
            newCharacter.gameObject.GetComponent<Cleric>().currentClassLevel = 1;

            UpdateClassLevelsText(newCharacter.gameObject.GetComponent<Fighter>().currentClassLevel, newCharacter.gameObject.GetComponent<Mage>().currentClassLevel, newCharacter.gameObject.GetComponent<Cleric>().currentClassLevel);
        }
    }

    /*public void SetupPlayerScripts()
    {
        if()
        {

        }
        newCharacter.gameObject.AddComponent<>();
    }*/

    public int Roll4d6k3()
    {
        int[] diceRolls = new int[4];
        // Get 4 random d6 rolls
        for (int i = 0; i < diceRolls.Length; i++)
        {
            diceRolls[i] = UnityEngine.Random.Range(1, 6);
        }

        // Sort the dice rools
        Array.Sort(diceRolls);

        // Get the total of the 1st 3
        int best3 = 0;
        for(int i = 0; i < diceRolls.Length-1; i++)
        {
            best3 += diceRolls[i];
        }

        return best3;
    }

    public void RollDiceStats()
    {
        GetRaceModifiers();

        // Roll for strength
        currentStrength = Roll4d6k3();
        if(currentStrength > _maxStrength)
        {
            currentStrength = _maxStrength;
        }
        // currentStrength = UnityEngine.Random.Range(3, _maxStrength);

        // Roll for dexterity
        currentDexterity = Roll4d6k3();
        if (currentDexterity > _maxDexterity)
        {
            currentDexterity = _maxDexterity;
        }
        //currentDexterity = UnityEngine.Random.Range(3, _maxDexterity);

        // Roll for intelligence
        currentIntelligence = Roll4d6k3();
        if (currentIntelligence > _maxIntelligence)
        {
            currentIntelligence = _maxIntelligence;
        }
        //currentIntelligence = UnityEngine.Random.Range(3, _maxIntelligence);

        // Roll for wisdom
        currentWisdom = Roll4d6k3();
        if (currentWisdom > _maxWisdom)
        {
            currentWisdom = _maxWisdom;
        }
        //currentWisdom = UnityEngine.Random.Range(3, _maxWisdom);

        // Roll for constitution
        currentConstitution = Roll4d6k3();
        if (currentConstitution > _maxConstitution)
        {
            currentConstitution = _maxConstitution;
        }
        // currentConstitution = UnityEngine.Random.Range(3, _maxConstitution);

        // Roll for charisma
        currentCharisma = Roll4d6k3();
        if (currentCharisma > _maxCharisma)
        {
            currentCharisma = _maxCharisma;
        }
        //currentCharisma = UnityEngine.Random.Range(3, _maxCharisma);

        // Calculate max possible HP before entering

        _maxHP = GetMaxBaseHP();
        currentMaxHealth = UnityEngine.Random.Range(1, _maxHP);

        UpdateCharacterStatsText();
    }

    public void CreateCharacter()
    {
        // Add all the different input stats to the appropriate scripts
        // Name
        CharacterStats raceChoice = newCharacter.GetComponent<CharacterStats>() as CharacterStats;
        raceChoice.characterName = characterNameText.text;
        Debug.Log(raceChoice + " with name " + raceChoice.characterName);

        // Gender
        raceChoice.charGender = _characterGenderOptions;

        // Race
        raceChoice.charRace = _characterRaceOptions;

        // Classes
        raceChoice.charClass = _characterClassOptions;

        // Alignment
        raceChoice.charAlignment = _characterAlignmentOptions;

        // Stats
        //raceChoice._strength = (currentStrength) as Stat;
        raceChoice._strength = currentStrength;
        raceChoice._dexterity = currentDexterity;
        raceChoice._intelligence = currentIntelligence;
        raceChoice._wisdom = currentWisdom;
        raceChoice._constitution = currentConstitution;
        raceChoice._charisma = currentCharisma;

        raceChoice.maxHealth = currentMaxHealth;

    }

}
