using UnityEngine;

public class Hacker : MonoBehaviour {

    //Game configuration data
    string[] level1passwords = { "Law", "Preisdent", "Constitution", "Major", "Secretary"};
    string[] level2passwords = { "Solidier", "Helicopter", "Submanirne" , "Aircraft", "Casualyties"};
    string[] level3passwords = { "Telescope", "Expedition", "Astronauts", "Starfield", "enviorment"};
    
    //Game State
    int level;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;
    string password;

	// Use this for initialization
	void Start () {
        ShowMainMenu();
    }
    
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the Goverment");
        Terminal.WriteLine("Press 2 for the Pentagon");
        Terminal.WriteLine("Press 3 for the Nasa");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu" || input == "Menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber)
        {
            level = int.Parse(input); // string to int
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Wrong input");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You chose level " + level);
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:                
                password = level1passwords[Random.Range(0, level1passwords.Length)];
                break;

            case 2:
                password = level2passwords[Random.Range(0, level2passwords.Length)];
                break;

            case 3:
                password = level3passwords[Random.Range(0, level3passwords.Length)];
                break;

            default:
                Debug.LogError("Invalid level number");
                break;
        }
        Terminal.WriteLine("Eneter your password, hint: " + password.Anagram());
        GoBackToMenu();
    }
	
    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLeveLReward();
        GoBackToMenu();
    }

    void ShowLeveLReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You won a Flower!\nTry level 2");
                break;

            case 2:
                Terminal.WriteLine("You won a Car!\nTry level 3");
                break;

            case 3:
                Terminal.WriteLine("You won a 100000$!");
                break;

            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }

    void GoBackToMenu()
    {
        Terminal.WriteLine("Type 'Menu' to go back");
    }

	// Update is called once per frame
	void Update () {

	}
}
