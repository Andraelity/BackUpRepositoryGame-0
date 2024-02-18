using System; 
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text; 
using UnityEngine;


using CommunicationButtonLanguageNamespace;
using LinkCommunicationLanguagesFilesNamespace;

public class LanguageSelectionData_Class
{

    public int int_CurrentLanguageSelection = 0;

}

public class HandlerLanguageButtonsClass : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> list_GameObjectLanguageSelectionField;

    [SerializeField]
    private GameObject gameobject_IconHolderFrench;

    [SerializeField]
    private GameObject gameobject_IconHolderPortuguese;

    [SerializeField]
    private GameObject gameobject_IconHolderSpanish;


    private bool bool_ButtonSetLanguageToFrench = false;
    private bool bool_ButtonSetLanguageToPortuguese = false;
    private bool bool_ButtonSetLanguageToSpanish = false;

    private bool bool_ConfirmChangeLanguage = false; 

    private string string_FilePathJSON_ContainerLanguagePersistance;

    private int int_CurrentLanguageSelection = 0;

    private bool bool_SetActiveLanguageCurrentSave = false;



    public void ChangeLanguageSelectionFrench()
    {

        // CommunicationButtonLanguageClass.bool_SetLanguageToFrench = true;
        bool_ButtonSetLanguageToFrench = true;

    }
    
    public void ChangeLanguageSelectionPortuguese()
    {

        // CommunicationButtonLanguageClass.bool_SetLanguageToPortuguese = true;
        bool_ButtonSetLanguageToPortuguese = true;
        
    }

    public void ChangeLanguageSelectionSpanish()
    {

        // CommunicationButtonLanguageClass.bool_SetLanguageToSpanish = true;
        bool_ButtonSetLanguageToSpanish = true;
    
    }

    public void ConfirmChangeLanguage()
    {

        bool_ConfirmChangeLanguage = true;

    }

    void Start()
    {

        List<GameObject> list_GameObjectLanguageSelection = list_GameObjectLanguageSelectionField;

        for(int i = 0; i < list_GameObjectLanguageSelection.Count; i++)
        {
            list_GameObjectLanguageSelection[i].transform.GetChild(0).gameObject.SetActive(true);
            list_GameObjectLanguageSelection[i].transform.GetChild(1).gameObject.SetActive(false);
        }
    

        string string_PathDevice  = Application.persistentDataPath;

        string string_DirectoryLocation = string_PathDevice + "/Language_Selection_Persistance";
        
        Debug.Log(string_DirectoryLocation);
        

  
        if(Directory.Exists(string_DirectoryLocation) == false)
        {
        
            Directory.CreateDirectory(string_DirectoryLocation);
        
        }

        
        string string_FilePath = string_DirectoryLocation + "/Language_Selection_Data.json";

        string_FilePathJSON_ContainerLanguagePersistance = string_FilePath;

        if (File.Exists(string_FilePath) == false)
        {
            

            LanguageSelectionData_Class LanguageSelectionData_Variable = new LanguageSelectionData_Class();

            int_CurrentLanguageSelection = LanguageSelectionData_Variable.int_CurrentLanguageSelection;

            string string_ToWrite = JsonUtility.ToJson(LanguageSelectionData_Variable);

            File.WriteAllText(string_FilePath, string_ToWrite, Encoding.UTF8);


        }
        else
        {
 
            string string_LanguageSelectionData_JSON = File.ReadAllText(string_FilePath);

            LanguageSelectionData_Class LanguageSelectionData_Variable = JsonUtility.FromJson<LanguageSelectionData_Class>(string_LanguageSelectionData_JSON);

            int_CurrentLanguageSelection = LanguageSelectionData_Variable.int_CurrentLanguageSelection;
            
        }

        list_GameObjectLanguageSelection[int_CurrentLanguageSelection].transform.GetChild(1).gameObject.SetActive(true);
       
        // gameobject_IconHolderFrench.transform.GetChild(0).gameObject.SetActive(true);
        // gameobject_IconHolderPortuguese.transform.GetChild(0).gameObject.SetActive(true);
        // gameobject_IconHolderSpanish.transform.GetChild(0).gameObject.SetActive(true);

        bool_SetActiveLanguageCurrentSave = true;
        bool_ConfirmChangeLanguage = true;

    }

    bool bool_ReUpdateFiles = false;

    void Update()
    {
        
        if(bool_ConfirmChangeLanguage)
        {


            List<GameObject> list_GameObjectLanguageSelection = list_GameObjectLanguageSelectionField;

            for(int i = 0; i < list_GameObjectLanguageSelection.Count; i++)
            {
                list_GameObjectLanguageSelection[i].transform.GetChild(0).gameObject.SetActive(true);
                list_GameObjectLanguageSelection[i].transform.GetChild(1).gameObject.SetActive(false);
            }



            LanguageSelectionData_Class LanguageSelectionData_Variable = new LanguageSelectionData_Class();

            LanguageSelectionData_Variable.int_CurrentLanguageSelection = int_CurrentLanguageSelection;


            bool_ConfirmChangeLanguage = false;
            
            if(bool_ButtonSetLanguageToFrench || (bool_SetActiveLanguageCurrentSave && int_CurrentLanguageSelection == 0))
            {
                
                bool_SetActiveLanguageCurrentSave = false;

                CommunicationButtonLanguageClass.bool_SetLanguageToFrench = true;

                Debug.Log("    LANGUAGE SET TO FRENCH");
    
                gameobject_IconHolderFrench.transform.GetChild(1).gameObject.SetActive(true);

                int_CurrentLanguageSelection = 0;
    
                LanguageSelectionData_Variable.int_CurrentLanguageSelection = int_CurrentLanguageSelection;

                bool_ReUpdateFiles = true;            

                LinkCommunicationLanguagesFilesClass.SetCurrentActiveLanguge_MAIN(0);

            }
            
            if(bool_ButtonSetLanguageToPortuguese || (bool_SetActiveLanguageCurrentSave && int_CurrentLanguageSelection == 1))
            {
                
                bool_SetActiveLanguageCurrentSave = false;

                CommunicationButtonLanguageClass.bool_SetLanguageToPortuguese = true;
                
                Debug.Log("    LANGUAGE SET TO PORTUGUESE");

                gameobject_IconHolderPortuguese.transform.GetChild(1).gameObject.SetActive(true);
                
                int_CurrentLanguageSelection = 1;
    
                LanguageSelectionData_Variable.int_CurrentLanguageSelection = int_CurrentLanguageSelection;

                bool_ReUpdateFiles = true;

                LinkCommunicationLanguagesFilesClass.SetCurrentActiveLanguge_MAIN(1);


            }

            if(bool_ButtonSetLanguageToSpanish || (bool_SetActiveLanguageCurrentSave && int_CurrentLanguageSelection == 2))
            {
                
                bool_SetActiveLanguageCurrentSave = false;                

                CommunicationButtonLanguageClass.bool_SetLanguageToSpanish = true;

                Debug.Log("    LANGUAGE SET TO SPANISH");
                
                gameobject_IconHolderSpanish.transform.GetChild(1).gameObject.SetActive(true);
                
                int_CurrentLanguageSelection = 2;
    
                LanguageSelectionData_Variable.int_CurrentLanguageSelection = int_CurrentLanguageSelection;

                bool_ReUpdateFiles = true;

                LinkCommunicationLanguagesFilesClass.SetCurrentActiveLanguge_MAIN(2);

            }


            if(bool_ReUpdateFiles)
            {
                
                bool_ReUpdateFiles = false;

                int_CurrentLanguageSelection = LanguageSelectionData_Variable.int_CurrentLanguageSelection;

                string string_ToWrite = JsonUtility.ToJson(LanguageSelectionData_Variable);

                File.WriteAllText(string_FilePathJSON_ContainerLanguagePersistance, string_ToWrite, Encoding.UTF8);

            }
            

            bool_ButtonSetLanguageToFrench = false;
            bool_ButtonSetLanguageToPortuguese = false;
            bool_ButtonSetLanguageToSpanish = false;


        }

    }

}
