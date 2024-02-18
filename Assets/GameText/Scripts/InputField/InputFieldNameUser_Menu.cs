using System.Collections;
using System.Collections.Generic;
using System.Text; 
using System; 
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;
using TMPro;

using CommunicationButtonNamespace;

using CommunicationTextScriptAnimationNamespace;



public class ContainerUserInformation_Class
{

    public int int_CurrentLevelUser = 0;
    public string string_NameOfTheUser = "Machinator";

}


public class InputFieldNameUser_Menu : MonoBehaviour
{


    [SerializeField]
    private GameObject gameobject_HOMEMENU;
    
    [SerializeField]
    private GameObject gameobject_HolderEKeyPress;
    
    [SerializeField]    
    private GameObject gameobject_InputField;

    [SerializeField]    
    private GameObject gameobject_PlaceHolder;

    [SerializeField]    
    private GameObject gameobject_MiddleScreenUserName;

    [SerializeField]    
    private GameObject gameobject_TextLevel;



    private string string_FilePathJSON_ContainerUserInformation;


    string string_NameOfTheUser = "";
    int int_LevelOfUser = 0;



    void Start()
    {

        
        TMP_InputField textmeshpro_InputField = gameobject_InputField.GetComponent<TMP_InputField>();
        TMP_Text textmeshpro_PlaceHolder = gameobject_PlaceHolder.GetComponent<TMP_Text>();
        TMP_Text textmeshpro_MiddleScreenUserName = gameobject_MiddleScreenUserName.GetComponent<TMP_Text>();
        TMP_Text textmeshpro_TextLevel = gameobject_TextLevel.GetComponent<TMP_Text>();


        string string_PathDevice  = Application.persistentDataPath;

        string string_DirectoryLocation = string_PathDevice + "/User_Information_Directory";
        
        Debug.Log(string_DirectoryLocation);
        
  
        if(Directory.Exists(string_DirectoryLocation) == false)
        {
        
            Directory.CreateDirectory(string_DirectoryLocation);
        
        }

        
        string string_FilePath = string_DirectoryLocation + "/User_Information_Data.json";

        string_FilePathJSON_ContainerUserInformation = string_FilePath;

        if (File.Exists(string_FilePath) == false)
        {
            

            ContainerUserInformation_Class ContainerUserInformation_Variable = new ContainerUserInformation_Class();

            string_NameOfTheUser = ContainerUserInformation_Variable.string_NameOfTheUser;
            int_LevelOfUser = ContainerUserInformation_Variable.int_CurrentLevelUser;

            string string_ToWrite = JsonUtility.ToJson(ContainerUserInformation_Variable);


            File.WriteAllText(string_FilePath, string_ToWrite, Encoding.UTF8);


            textmeshpro_InputField.text = string_NameOfTheUser;
            textmeshpro_PlaceHolder.text = string_NameOfTheUser;
            textmeshpro_MiddleScreenUserName.text = string_NameOfTheUser;
            textmeshpro_TextLevel.text = "Level " + int_LevelOfUser.ToString();



        }
        else
        {
 
            string string_ContainerUserInformation_JSON = File.ReadAllText(string_FilePath);

            ContainerUserInformation_Class ContainerUserInformation_Variable = JsonUtility.FromJson<ContainerUserInformation_Class>(string_ContainerUserInformation_JSON);
            
            string_NameOfTheUser = ContainerUserInformation_Variable.string_NameOfTheUser;
            int_LevelOfUser = ContainerUserInformation_Variable.int_CurrentLevelUser;


            textmeshpro_InputField.text = string_NameOfTheUser;
            textmeshpro_PlaceHolder.text = string_NameOfTheUser;
            textmeshpro_MiddleScreenUserName.text = string_NameOfTheUser;
            textmeshpro_TextLevel.text = "Level " + int_LevelOfUser.ToString();

        }


    }


    bool bool_SetNewUserInformation = false;

    bool bool_SetUpSwitchUserInformation_0 = false;
    bool bool_SetUpSwitchTrigger_0 = true;
    bool bool_SetUpSwitchTrigger_1 = false;


    void Update()
    {


        if(CommunicationButtonClass.bool_CommunicationButtonNameChange && bool_SetUpSwitchUserInformation_0 == false)
        {

            bool_SetUpSwitchUserInformation_0 = true;
            CommunicationButtonClass.bool_CommunicationButtonNameChange = false;
            bool_SetUpSwitchTrigger_0 = false;

            CommunicationTextScriptAnimationClass.bool_ActivateAnimationFadeIn = true;            

			EventSystem.current.SetSelectedGameObject(gameobject_InputField.gameObject);
            

        }

        string string_OperativeValidation = string_NameOfTheUser;


        if(CommunicationButtonClass.bool_CommunicationButtonNameChange && bool_SetUpSwitchUserInformation_0 == true)
        {

            bool_SetUpSwitchUserInformation_0 = false;
            
            CommunicationButtonClass.bool_CommunicationButtonNameChange = false;
            bool_SetUpSwitchTrigger_1 = true; 

			EventSystem.current.SetSelectedGameObject(null);

            
            string_OperativeValidation = gameobject_InputField.GetComponent<TMP_InputField>().text;


            CommunicationTextScriptAnimationClass.bool_ActivateAnimationFadeOut = true;

        }

        if(bool_SetUpSwitchUserInformation_0 && gameobject_HOMEMENU.activeSelf == true)
        {
        
            gameobject_HolderEKeyPress.GetComponent<Michsky.UI.Shift.PressKeyEvent>().enabled = false;

        }
        
        if(bool_SetUpSwitchUserInformation_0 == false && gameobject_HOMEMENU.activeSelf == true)
        {
        
            gameobject_HolderEKeyPress.GetComponent<Michsky.UI.Shift.PressKeyEvent>().enabled = true;
            gameobject_InputField.GetComponent<TMP_InputField>().text = string_OperativeValidation;
            
        }
        

        if(bool_SetUpSwitchTrigger_1 && string_OperativeValidation != string_NameOfTheUser && string_OperativeValidation.Length > 0)
        {

            bool_SetUpSwitchTrigger_1 = false;

            ContainerUserInformation_Class ContainerUserInformation_Variable = new ContainerUserInformation_Class();

            string_NameOfTheUser = string_OperativeValidation;

            ContainerUserInformation_Variable.string_NameOfTheUser = string_NameOfTheUser;
            ContainerUserInformation_Variable.int_CurrentLevelUser = int_LevelOfUser;
            
            string string_ToWriteJSONFile = JsonUtility.ToJson(ContainerUserInformation_Variable);


            File.WriteAllText(string_FilePathJSON_ContainerUserInformation, string_ToWriteJSONFile, Encoding.UTF8);

            Debug.Log("WRITING FILES MORE THAN ONE TIME?");

            gameobject_MiddleScreenUserName.GetComponent<TMP_Text>().text = string_NameOfTheUser;
            gameobject_PlaceHolder.GetComponent<TMP_Text>().text = string_NameOfTheUser;

        }

    }

}
