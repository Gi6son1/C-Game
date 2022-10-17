using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //enabling this allows me to access the computer files to check for files
using UnityEngine.UI;

public class CheckForAccounts : MonoBehaviour
{
    int accountFiles; //this will hold the number of files in the accounts folder
    string[] files; //this will hold the names of the files in the folder
    public GameObject SelectButton; //this will call the select button object so that i may modify it
    public GameObject CreateButton; //this will call the create button object so that i may modify it
    string flashLetter;
    // Start is called before the first frame update
    void Start()
    {
        flashLetter = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        if (!Directory.Exists(flashLetter + "\\Computing Project Program\\Game Files\\Accounts")) //checks if accounts folder exists
        {
            Directory.CreateDirectory(flashLetter + "\\Computing Project Program\\Game Files\\Accounts"); //creates one if it doesn't, meaning only one folder is present to avoid errors
        }
        if (GameObject.Find("FlashLetter") == null) //if there is no selected account game object
        {
            new GameObject("FlashLetter").AddComponent<Text>().text = flashLetter; //make one and add a text component to it
            DontDestroyOnLoad(GameObject.Find("FlashLetter"));
        }
    }

    // Update is called once per frame
    void Update()
    {


        accountFiles = 0; //sets the number of files to 0 so that they may be counted properly 
        files = Directory.GetFiles(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts"); //get all the path of the files in the folder
        foreach (string filename in files) //increases the accountfiles variable by one for every path in the string
        {
            accountFiles++;
        }

        if (accountFiles >= 4) //if the number of files is 4 or greater(if someone directly adds a file in the folder)
        {
            CreateButton.gameObject.SetActive(false); //the create button is turned off, meaning the player cannot create an account through the GUI
        }
        else
            CreateButton.gameObject.SetActive(true);
        if (accountFiles == 0) //if there are no files 
        {
            SelectButton.gameObject.SetActive(false); //the select button is turned off, meaning the player is not given the option to select an account
        }
        else
            SelectButton.gameObject.SetActive(true);
    }
}
