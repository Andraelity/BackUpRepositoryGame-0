using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinkCommunicationLanguagesFilesNamespace
{

    public static class LinkCommunicationLanguagesFilesClass
    {
        
        public static string string_CurrentActiveLanguage_Words_One = "WordListEnglish";
        public static string string_CurrentActiveLanguage_Words_Two = "WordListFrench";
        
        
        public static string string_CurrentActiveLanguage_Sentences_One = "SentencesListEnglish";
        public static string string_CurrentActiveLanguage_Sentences_Two = "SentencesListFrench";
        


        static public void SetCurrentActiveLanguge_MAIN(int int_LanguageSelected)
        {


            switch(int_LanguageSelected)
            {
                case 0:
                    Set_Words_CurrentActiveLanguge_English_French();
                    Set_Sentences_CurrentActiveLanguge_English_French();
                    break;        
                case 1:
                    Set_Words_CurrentActiveLanguge_English_Portuguese();
                    Set_Sentences_CurrentActiveLanguge_English_Portuguese();
                    break;        
                    
                case 2:
                    Set_Words_CurrentActiveLanguge_English_Spanish();
                    Set_Sentences_CurrentActiveLanguge_English_Spanish();
                    break;        
                
                default:
                    Set_Words_CurrentActiveLanguge_English_French();
                    Set_Sentences_CurrentActiveLanguge_English_French();
                    break;        
                    
            }

        }

        
        static public void Set_Words_CurrentActiveLanguge_English_French()
        {
            
            string string_PathToFile = "WordTranslation/DirectoryList_English-French/WordListComplete/";
            string string_EnglishLanguage = string_PathToFile + "WordList_English";
            string string_FrenchLanguage = string_PathToFile + "WordList_French";

            string_CurrentActiveLanguage_Words_One = string_EnglishLanguage;
            string_CurrentActiveLanguage_Words_Two = string_FrenchLanguage;

        }

        static public void Set_Sentences_CurrentActiveLanguge_English_French()
        {
            
            string string_PathToFile = "WordTranslation/DirectoryList_English-French/SentencesListComplete/";
            string string_EnglishLanguage = string_PathToFile + "SentencesList_English";
            string string_FrenchLanguage = string_PathToFile + "SentencesList_French";

            string_CurrentActiveLanguage_Sentences_One = string_EnglishLanguage;
            string_CurrentActiveLanguage_Sentences_Two = string_FrenchLanguage;

        }


        static public void Set_Words_CurrentActiveLanguge_English_Portuguese()
        {
            
            string string_PathToFile = "WordTranslation/DirectoryList_English-Portuguese/WordListComplete/";
            string string_EnglishLanguage = string_PathToFile + "WordList_English";
            string string_PortugueseLanguage = string_PathToFile + "WordList_Portuguese";

            string_CurrentActiveLanguage_Words_One = string_EnglishLanguage;
            string_CurrentActiveLanguage_Words_Two = string_PortugueseLanguage;

        }


        static public void Set_Sentences_CurrentActiveLanguge_English_Portuguese()
        {
            
            string string_PathToFile = "WordTranslation/DirectoryList_English-Portuguese/SentencesListComplete/";
            string string_EnglishLanguage = string_PathToFile + "SentencesList_English";
            string string_PortugueseLanguage = string_PathToFile + "SentencesList_Portuguese";

            string_CurrentActiveLanguage_Sentences_One = string_EnglishLanguage;
            string_CurrentActiveLanguage_Sentences_Two = string_PortugueseLanguage;

        }


        static public void Set_Words_CurrentActiveLanguge_English_Spanish()
        {
            
            string string_PathToFile = "WordTranslation/DirectoryList_English-Spanish/WordListComplete/";
            string string_EnglishLanguage = string_PathToFile + "WordList_English";
            string string_SpanishLanguage = string_PathToFile + "WordList_Spanish";

            string_CurrentActiveLanguage_Words_One = string_EnglishLanguage;
            string_CurrentActiveLanguage_Words_Two = string_SpanishLanguage;

        }


        static public void Set_Sentences_CurrentActiveLanguge_English_Spanish()
        {
            
            string string_PathToFile = "WordTranslation/DirectoryList_English-Spanish/SentencesListComplete/";
            string string_EnglishLanguage = string_PathToFile + "SentencesList_English";
            string string_SpanishLanguage = string_PathToFile + "SentencesList_Spanish";

            string_CurrentActiveLanguage_Sentences_One = string_EnglishLanguage;
            string_CurrentActiveLanguage_Sentences_Two = string_SpanishLanguage;

        }

    }

}
