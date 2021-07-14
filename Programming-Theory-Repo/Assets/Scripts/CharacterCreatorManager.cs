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
    List<string> humanClassNames = new List<string>() { "Please select a class", "Cleric", "Fighter", "Mage", "Paladin", "Thief", "Ranger" };
    List<string> elfClassNames = new List<string>() { "Please select a class", "Fighter", "Ranger", "Mage", "Cleric", "Thief", "Fighter/Mage", "Fighter/Thief", "Mage/Thief", "Fighter/Mage/Thief" };
    List<string> halfElfClassNames = new List<string>() { "Please select a class", "Fighter", "Ranger", "Mage", "Cleric", "Thief", "Fighter/Cleric", "Fighter/Mage", "Fighter/Thief", "Cleric/Ranger", "Cleric/Mage", "Thief/Mage", "Fighter/Mage/Cleric", "Fighter/Mage/Thief" };
    List<string> dwarfClassNames = new List<string>() { "Please select a class", "Fighter", "Cleric", "Thief", "Fighter/Cleric", "Fighter/Thief" };
    List<string> gnomeClassNames = new List<string>() { "Please select a class", "Fighter", "Cleric", "Thief", "Fighter/Cleric", "Fighter/Thief", "Cleric/Thief" };
    List<string> halflingClassNames = new List<string>() { "Please select a class", "Fighter", "Cleric", "Thief", "Fighter/Thief" };
    List<string> curAlignmentNames = new List<string>();
    List<string> alignmentNames = new List<string>() { "Please select an alignment", "Lawful Good", "Lawful Neutral", "Lawful Evil", "Neutral Good", "True Neutral", "Neutral Evil", "Chaotic Good", "Chaotic Neutral", "Chaotic Evil" };
    List<string> clericAlignmentNames = new List<string>() { "Please select an alignment", "Lawful Good", "Lawful Neutral", "Neutral Good", "True Neutral", "Chaotic Good", "Chaotic Neutral" };
    List<string> paladinAlignmentNames = new List<string>() { "Please select an alignment", "Lawful Good", };

    public enum GENDER { Male, Female };
    public enum RACE { Human, Elf, Half_Elf, Dwarf, Gnome, Halfling };
    public enum CLASS { Cleric, Fighter, Ranger, Mage, Paladin, Thief, Fighter_Cleric, Fighter_Mage, Fighter_Thief, Mage_Thief, Thief_Mage, Cleric_Thief, Cleric_Ranger, Fighter_Mage_Thief, Fighter_Mage_Cleric };
    public enum ALIGNMENT { Lawful_Good, Lawful_Neutral, Lawful_Evil, Neutral_Good, True_Neutral, Neutral_Evil, Chaotic_Good, Chaotic_Neutral, Chaotic_Evil };

    // Character Panels
    public Image genderPanel;
    public Image racePanel;
    public Image classPanel;
    public Image alignmentPanel;

    // Character Dropdowns
    public TMP_Dropdown genderDropdown;
    public TMP_Dropdown raceDropdown;
    public TMP_Dropdown classDropdown;
    public TMP_Dropdown alignmentDropdown;

    public Text genderNameText;
    public Text raceNameText;
    public Text classNameText;
    public Text alignmentNameText;

    // Character setup variables
    [SerializeField] private GENDER _characterGenderOptions;
    [SerializeField] private RACE _characterRaceOptions;
    [SerializeField] private CLASS _characterClassOptions;
    [SerializeField] private ALIGNMENT _characterAlignmentOptions;

    private Character newCharacter;

    // Start is called before the first frame update
    void Start()
    {
        PopulateGenderDropdown();
        PopulateRaceDropdown();
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            _characterGenderOptions = GENDER.Male;
        }
        else if(genderNameText.text == "Female")
        {
            _characterGenderOptions = GENDER.Female;
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
            _characterRaceOptions = RACE.Human;

            classDropdown.options.Clear();
            curClassNames.Clear();
            curClassNames = humanClassNames;
            classDropdown.AddOptions(curClassNames);
            Debug.Log(_characterRaceOptions.ToString() + " race selected. Loading available classes" );
        }
        else if (raceNameText.text == "Elf")
        {
            _characterRaceOptions = RACE.Elf;

            classDropdown.options.Clear();
            curClassNames.Clear();
            curClassNames = elfClassNames;
            classDropdown.AddOptions(curClassNames);

            Debug.Log(_characterRaceOptions.ToString() + " race selected. Loading available classes");
        }
        else if (raceNameText.text == "Half-Elf")
        {
            _characterRaceOptions = RACE.Half_Elf;

            classDropdown.options.Clear();
            curClassNames.Clear();
            curClassNames = halfElfClassNames;
            classDropdown.AddOptions(curClassNames);

            Debug.Log(_characterRaceOptions.ToString() + " race selected. Loading available classes");
        }
        else if (raceNameText.text == "Dwarf")
        {
            _characterRaceOptions = RACE.Dwarf;

            classDropdown.options.Clear();
            curClassNames.Clear();
            curClassNames = dwarfClassNames;
            classDropdown.AddOptions(curClassNames);

            Debug.Log(_characterRaceOptions.ToString() + " race selected. Loading available classes");
        }
        else if (raceNameText.text == "Gnome")
        {
            _characterRaceOptions = RACE.Gnome;

            classDropdown.options.Clear();
            curClassNames.Clear();
            curClassNames = gnomeClassNames;
            classDropdown.AddOptions(curClassNames);

            Debug.Log(_characterRaceOptions.ToString() + " race selected. Loading available classes");
        }
        else if (raceNameText.text == "Halfling")
        {
            _characterRaceOptions = RACE.Halfling;

            classDropdown.options.Clear();
            curClassNames.Clear();
            curClassNames = halflingClassNames;
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
            _characterClassOptions = CLASS.Cleric;

            alignmentDropdown.options.Clear();
            curAlignmentNames = clericAlignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);

        }
        else if (classNameText.text == "Fighter")
        {
            _characterClassOptions = CLASS.Fighter;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Ranger")
        {
            _characterClassOptions = CLASS.Ranger;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Mage")
        {
            _characterClassOptions = CLASS.Mage;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Paladin")
        {
            _characterClassOptions = CLASS.Paladin;

            alignmentDropdown.options.Clear();
            curAlignmentNames = paladinAlignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Thief")
        {
            _characterClassOptions = CLASS.Thief;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Fighter/Thief")
        {
            _characterClassOptions = CLASS.Fighter_Thief;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Fighter/Cleric")
        {
            _characterClassOptions = CLASS.Fighter_Cleric;

            alignmentDropdown.options.Clear();
            curAlignmentNames = clericAlignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Fighter/Mage")
        {
            _characterClassOptions = CLASS.Fighter_Mage;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Cleric/Ranger")
        {
            _characterClassOptions = CLASS.Cleric_Ranger;

            alignmentDropdown.options.Clear();
            curAlignmentNames = clericAlignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Cleric/Thief")
        {
            _characterClassOptions = CLASS.Cleric_Thief;

            alignmentDropdown.options.Clear();
            curAlignmentNames = clericAlignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Mage/Thief")
        {
            _characterClassOptions = CLASS.Mage_Thief;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Thief/Mage")
        {
            _characterClassOptions = CLASS.Thief_Mage;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Fighter/Mage/Thief")
        {
            _characterClassOptions = CLASS.Fighter_Mage_Thief;

            alignmentDropdown.options.Clear();
            curAlignmentNames = alignmentNames;
            alignmentDropdown.AddOptions(curAlignmentNames);
        }
        else if (classNameText.text == "Fighter/Mage/Cleric")
        {
            _characterClassOptions = CLASS.Fighter_Mage_Cleric;

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
    }

    public void SelectAlignment(int index)
    {

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
        else if(_characterRaceOptions == RACE.Human)
        {
            classDropdown.AddOptions(humanClassNames);
        }
        else if (_characterRaceOptions == RACE.Elf)
        {
            classDropdown.AddOptions(elfClassNames);
        }
        else if (_characterRaceOptions == RACE.Half_Elf)
        {
            classDropdown.AddOptions(halfElfClassNames);
        }
        else if (_characterRaceOptions == RACE.Dwarf)
        {
            classDropdown.AddOptions(dwarfClassNames);
        }
        else if (_characterRaceOptions == RACE.Gnome)
        {
            classDropdown.AddOptions(gnomeClassNames);
        }
        else if (_characterRaceOptions == RACE.Halfling)
        {
            classDropdown.AddOptions(halflingClassNames);
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
        else if(_characterClassOptions == CLASS.Cleric || 
                _characterClassOptions == CLASS.Cleric_Ranger ||
                _characterClassOptions == CLASS.Cleric_Thief ||
                _characterClassOptions == CLASS.Fighter_Cleric ||
                _characterClassOptions == CLASS.Fighter_Mage_Cleric)
        {
            alignmentDropdown.AddOptions(clericAlignmentNames);
        }
        else if(_characterClassOptions == CLASS.Paladin)
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
    
}
