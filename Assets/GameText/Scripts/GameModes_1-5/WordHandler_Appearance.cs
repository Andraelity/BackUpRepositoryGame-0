using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// using LinkCommunicationNamespace;

using LinkCommunicationColoredNamespace;

using LinkCommunicationLanguagesFilesNamespace;

using StyleModeNamespace;


public class WordHandler_Appearance : MonoBehaviour
{

	public GameObject ContainerOne_0;
	public GameObject TextOne_0;
	public GameObject BackGroundOne_0;
	public GameObject ShaderBackGroundOne_0;

	public GameObject ContainerTwo_0;
	public GameObject TextTwo_0;
	public GameObject BackGroundTwo_0;
	public GameObject ShaderBackGroundTwo_0;
	
 	List<string> list_OfStringWordEnglish;
 	List<string> list_OfStringWordFrench;

 	TextMeshPro text_OneTranslation;
 	TextMeshPro text_TwoTranslation;

 	float float_CurrentTime;

    string string_OneTranslation = "Goal";
    string string_TwoTranslation = "Goalition";

    Vector3 updatedPositionOne = new Vector3(0.0f, 0.0f, 0.0f);
	Vector3 updatedPositionTwo = new Vector3(0.0f, 0.0f, 0.0f);

	Vector3 coordinateBasePosition = new Vector3(-8.4f, -2.1f, 0.0f);
	Vector3 coordinateBasePositionShader = new Vector3(-8.4f, -2.1f, 1.0f);



    void Start()	
    {	


		var src = DateTime.Now;
		var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, src.Second);


		int HashRandom = (hm.Hour + hm.Year + hm.Month + hm.Day + hm.Minute + hm.Second);


 		list_OfStringWordEnglish = new List<string>();
 		list_OfStringWordFrench = new List<string>();

		LoadStringList();

		text_OneTranslation = TextOne_0.GetComponent<TextMeshPro>();
		text_TwoTranslation = TextTwo_0.GetComponent<TextMeshPro>();


		System.Random randomGeneratorNumber = null;
		
		int int_randomListPosition = 0;

		randomGeneratorNumber = new System.Random(HashRandom + 5830);
		int_randomListPosition = randomGeneratorNumber.Next(0, list_OfStringWordEnglish.Count);
		string_OneTranslation = list_OfStringWordEnglish[int_randomListPosition];
		string_TwoTranslation = list_OfStringWordFrench[int_randomListPosition];  
		text_OneTranslation.text = string_OneTranslation;
		text_TwoTranslation.text = string_TwoTranslation;

		

		float widthText_One = text_OneTranslation.preferredWidth;
		float heightText_One  = text_OneTranslation.preferredHeight;
		
		float widthText_Two = text_TwoTranslation.preferredWidth;
		float heightText_Two  = text_TwoTranslation.preferredHeight;


		System.Random randomPosition = new System.Random();

		float float_OneX = (float)(randomPosition.NextDouble() * 10.5);
		float float_OneY = (float)(randomPosition.NextDouble() * 7.0);

		float float_TwoX = (float)(randomPosition.NextDouble() * 10.5);
		float float_TwoY = (float)(randomPosition.NextDouble() * 7.0);

									

		float overpositionComparation = Math.Abs(float_OneY - float_TwoY);
		if(overpositionComparation < 0.9)
		{
			if(float_OneY > float_TwoY)
			{
				float_OneY += 0.9f;
			}				
			else
			{
				float_TwoY += 0.9f;
			}
		}								



		ContainerOne_0.transform.position = coordinateBasePosition + new Vector3(float_OneX, float_OneY, 0.0f);
		ContainerTwo_0.transform.position = coordinateBasePosition + new Vector3(float_TwoX, float_TwoY, 0.0f);

		BackGroundOne_0.transform.position = coordinateBasePosition + new Vector3(float_OneX, float_OneY, 0.0f);
		BackGroundTwo_0.transform.position = coordinateBasePosition + new Vector3(float_TwoX, float_TwoY, 0.0f);

		ShaderBackGroundOne_0.transform.position = coordinateBasePositionShader + new Vector3(float_OneX, float_OneY, 0.0f);
		ShaderBackGroundTwo_0.transform.position = coordinateBasePositionShader + new Vector3(float_TwoX, float_TwoY, 0.0f);


		Transform transform_ShaderBackOne = ShaderBackGroundOne_0.transform;
		Transform transform_BackOne = BackGroundOne_0.transform;
		Transform transform_ShaderBackTwo = ShaderBackGroundTwo_0.transform;
		Transform transform_BackTwo = BackGroundTwo_0.transform;

		

		transform_ShaderBackOne.localScale = GetScaleBackGround(widthText_One, transform_ShaderBackOne.localScale);
		transform_BackOne.localScale = GetScaleBackGround(widthText_One, transform_BackOne.localScale);
		transform_ShaderBackTwo.localScale = GetScaleBackGround(widthText_Two, transform_ShaderBackOne.localScale);
		transform_BackTwo.localScale = GetScaleBackGround(widthText_Two, transform_BackOne.localScale);

		float position = (widthText_One * 0.212f)/1.15f;
		float position2 = (widthText_Two * 0.212f)/1.15f;

		updatedPositionOne = GetPositionBackGround(widthText_One);
		updatedPositionTwo = GetPositionBackGround(widthText_Two); 

		transform_BackOne.position +=  updatedPositionOne;
		transform_BackTwo.position +=  updatedPositionTwo;

		transform_ShaderBackOne.position +=  updatedPositionOne;
		transform_ShaderBackTwo.position +=  updatedPositionTwo;

		BackGroundOne_0.transform.position = transform_BackOne.position;
		BackGroundTwo_0.transform.position = transform_BackTwo.position; 

		ShaderBackGroundOne_0.transform.position = transform_ShaderBackOne.position;
		ShaderBackGroundTwo_0.transform.position = transform_ShaderBackTwo.position; 


		// transform_BackOne = transform_ContainerOne;
		// transform_BackTwo = transform_ContainerTwo; 

		// Debug.Log("LocalSpace");
		// Debug.Log("LocalSpace");
		// Debug.Log("LocalSpace");
		// Debug.Log(transform_BackOne.localScale);
		// Debug.Log(transform_BackTwo.localScale);
		// Debug.Log("LocalSpace");
		// Debug.Log("LocalSpace");
		// Debug.Log("LocalSpace");


		// Debug.Log("BackGroundOne");
		// Debug.Log("BackGroundOne");

		// Debug.Log(BackGroundOne_0.transform.position);
		// Debug.Log(BackGroundTwo_0.transform.position);

		// Debug.Log("BackGroundOne");
		// Debug.Log("BackGroundOne");

		// Debug.Log("ContainerOne");
		// Debug.Log("ContainerOne");

		// // Debug.Log(transform_ContainerOne.position);
		// // Debug.Log(transform_ContainerTwo.position);

		// Debug.Log("ContainerOne");
		// Debug.Log("ContainerOne");


		// Debug.Log("TransformUpdatedOne");
		// Debug.Log("TransformUpdatedOne");

		// Debug.Log(transform_BackOne.position);
		// Debug.Log(transform_BackTwo.position);

		// Debug.Log("TransformUpdatedOne");
		// Debug.Log("TransformUpdatedOne");

		// // transform_BackOne.position +=  GetPositionBackGround(widthText_One);
		// // transform_BackTwo.position +=  GetPositionBackGround(widthText_Two);


		// // transform_BackOne.position +=  new Vector3(position , 0.0f, 0.0f);
		// // transform_BackTwo.position +=  new Vector3(position2 , 0.0f, 0.0f);


		// // BackGroundOne_0.transform.position = new Vector3(0.0f, 0.0f, 0.0f) +  transform_BackOne.position; 
		// // BackGroundTwo_0.transform.position = new Vector3(0.0f, 0.0f, 0.0f) +  transform_BackTwo.position; 




		// Debug.Log(transform_BackOne.position);
		// Debug.Log(transform_BackTwo.position);
		// Debug.Log("BackGround information");
		// Debug.Log("BackGround information");
		// Debug.Log("BackGround information");
		// Debug.Log(BackGroundOne_0.transform.position);
		// Debug.Log(BackGroundTwo_0.transform.position);
		// Debug.Log("BackGround information");
		// Debug.Log("BackGround information");
		// Debug.Log("BackGround information");

		// Debug.Log(position);
		// Debug.Log(position2);


		// Debug.Log(GetPositionBackGround(widthText_One));
		// Debug.Log(GetPositionBackGround(widthText_Two));


		// Debug.Log("preferredWidth --> " + widthText_One.ToString());
		// Debug.Log("preferredWidth --> "  + widthText_Two.ToString());



    }



    Vector3 GetScaleShaderBackGround(float width, Vector3 Current)
    {
		float scale = (width * 0.06f)/1.15f ;
    	Vector3 valueOut = new Vector3(scale, Current.y, Current.z);
  
    	return valueOut;
    }


    Vector3 GetScaleBackGround(float width, Vector3 Current)
    {
		float scale = (width * 0.045f)/1.15f ;
    	Vector3 valueOut = new Vector3(scale, Current.y, Current.z);
  
    	return valueOut;
    }

    Vector3 GetPositionBackGround(float width)
    {


		float position = (width * 0.212f)/1.15f ; 
    	Vector3 valueOut = new Vector3(position, 0.0f, 0.0f);
  
    	return valueOut;
    	// return position;
    }

    void LoadStringList()
    {


		string string_FirstLanguage = LinkCommunicationLanguagesFilesClass.string_CurrentActiveLanguage_Words_One;
		string string_SecondLanguage = LinkCommunicationLanguagesFilesClass.string_CurrentActiveLanguage_Words_Two;



		// TextAsset asset = (TextAsset)Resources.Load("WordListEnglish");
		TextAsset asset = (TextAsset)Resources.Load(string_FirstLanguage);
		string string_FileLines = asset.ToString();

		string[] lines = string_FileLines.Split(
	    // new string[] { "\r\n", "\r", "\n" },
	    new string[] { "\r\n" },
	    StringSplitOptions.None
		);

		for(int i = 0; i < lines.Length; i++)
		{
			// Debug.Log(lines[i] + "  " + lines[i].Length.ToString());
			list_OfStringWordEnglish.Add(lines[i]);

		}


		// asset = (TextAsset)Resources.Load("WordListFrench");
		asset = (TextAsset)Resources.Load(string_SecondLanguage);
		string_FileLines = asset.ToString();

		string[] lines2 = string_FileLines.Split(
	    // new string[] { "\r\n", "\r", "\n" },
	    new string[] { "\r\n" },
	    StringSplitOptions.None
		);

		for(int i = 0; i < lines2.Length; i++)
		{
			// Debug.Log(lines2[i] + "  " + (lines2[i].Length).ToString());
			list_OfStringWordFrench.Add(lines2[i]);
		
		}


    }

    void ColorCurrentTextList(bool bool_SetList, int numberOfCharacters)
    { 

		TMP_Text m_TextComponent;

		if(bool_SetList == true)
		{
			m_TextComponent = text_OneTranslation.GetComponent<TMP_Text>();

		}
		else
		{
			m_TextComponent = text_TwoTranslation.GetComponent<TMP_Text>();
		}

		m_TextComponent.ForceMeshUpdate();


        TMP_TextInfo textInfo = m_TextComponent.textInfo;

        if(numberOfCharacters > 0)
        {

	        for(int i = 0; i < numberOfCharacters; i++)
	        {
		
		        int currentCharacter = i;
		        
		        int characterCount = textInfo.characterCount;
		
		        Color32[] newVertexColors;
		        Color32 c0 = m_TextComponent.color;
		
		        int materialIndex = textInfo.characterInfo[currentCharacter].materialReferenceIndex;
		        newVertexColors = textInfo.meshInfo[materialIndex].colors32;
		        int vertexIndex = textInfo.characterInfo[currentCharacter].vertexIndex;
		
		
		
		        if (textInfo.characterInfo[currentCharacter].isVisible)
		        {
		            c0 = new Color32((byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), 255);
		            newVertexColors[vertexIndex + 0] = c0;
		            newVertexColors[vertexIndex + 1] = c0;
		            newVertexColors[vertexIndex + 2] = c0;
		            newVertexColors[vertexIndex + 3] = c0;
		            // New function which pushes (all) updated vertex data to the appropriate meshes when using either the Mesh Renderer or CanvasRenderer.
		            m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
		            // This last process could be done to only update the vertex data that has changed as opposed to all of the vertex data but it would require extra steps and knowing what type of renderer is used.
		            // These extra steps would be a performance optimization but it is unlikely that such optimization will be necessary.
		        }
	
		    }

        }


        if(numberOfCharacters == 0)
        {

	        for(int i = 0; i < numberOfCharacters; i++)
	        {
		
		        int currentCharacter = i;
		        
		        int characterCount = textInfo.characterCount;
		
		        Color32[] newVertexColors;
		        Color32 c0 = m_TextComponent.color;
		
		        int materialIndex = textInfo.characterInfo[currentCharacter].materialReferenceIndex;
		        newVertexColors = textInfo.meshInfo[materialIndex].colors32;
		        int vertexIndex = textInfo.characterInfo[currentCharacter].vertexIndex;
		
		
		
		        if (textInfo.characterInfo[currentCharacter].isVisible)
		        {
		            c0 = new Color32((byte)255, (byte)255, (byte)255, 255);
		            newVertexColors[vertexIndex + 0] = c0;
		            newVertexColors[vertexIndex + 1] = c0;
		            newVertexColors[vertexIndex + 2] = c0;
		            newVertexColors[vertexIndex + 3] = c0;
		            // New function which pushes (all) updated vertex data to the appropriate meshes when using either the Mesh Renderer or CanvasRenderer.
		            m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
		            // This last process could be done to only update the vertex data that has changed as opposed to all of the vertex data but it would require extra steps and knowing what type of renderer is used.
		            // These extra steps would be a performance optimization but it is unlikely that such optimization will be necessary.
		        }
	
		    }

		}

    }





    int int_CurrentOne = 0;
    int int_CurrentTwo = 0;

    bool bool_CurrentOne = false;
    bool bool_CurrentTwo = false;

    bool bool_CheckString = false;

    int counter = 0;

    string string_FromInputField = "";

    
    

    void Update()
    {

		if(StyleModeClass.int_StyleMode == 1)
		{

	    	if(Input.GetKeyDown(KeyCode.F1))
	    	{

				SceneManager.LoadScene (sceneBuildIndex:1);
				StyleModeClass.int_CurrentSceneGeneral = 1;

	    	}

	    	if(Input.GetKeyDown(KeyCode.F2))
	    	{

				SceneManager.LoadScene (sceneBuildIndex:2);
				StyleModeClass.int_CurrentSceneGeneral = 2;

	    	}

	    	if(Input.GetKeyDown(KeyCode.F4))
	    	{

				SceneManager.LoadScene (sceneBuildIndex:4);
				StyleModeClass.int_CurrentSceneGeneral = 4;

	    	}

	    	if(Input.GetKeyDown(KeyCode.F5))
	    	{

				SceneManager.LoadScene (sceneBuildIndex:5);
				StyleModeClass.int_CurrentSceneGeneral = 5;

	    	}

	    	if(Input.GetKeyDown(KeyCode.F6))
	    	{

				SceneManager.LoadScene (sceneBuildIndex:6);
				StyleModeClass.int_CurrentSceneGeneral = 6;

	    	}

	    	if(Input.GetKeyDown(KeyCode.F7))
	    	{

				SceneManager.LoadScene (sceneBuildIndex:7);
				StyleModeClass.int_CurrentSceneGeneral = 7;

	    	}

	    	if(Input.GetKeyDown(KeyCode.F8))
	    	{

				SceneManager.LoadScene (sceneBuildIndex:8);
				StyleModeClass.int_CurrentSceneGeneral = 8;

	    	}

	    	if(Input.GetKeyDown(KeyCode.F9))
	    	{

				SceneManager.LoadScene (sceneBuildIndex:9);
				StyleModeClass.int_CurrentSceneGeneral = 9;

	    	}

	    	if(Input.GetKeyDown(KeyCode.F10))
	    	{

				SceneManager.LoadScene (sceneBuildIndex:10);
				StyleModeClass.int_CurrentSceneGeneral = 10;

	    	}

	    	if(Input.GetKeyDown(KeyCode.F11))
	    	{

				SceneManager.LoadScene (sceneBuildIndex:11);
				StyleModeClass.int_CurrentSceneGeneral = 11;

	    	}
		}
		
		
		string string_OperativeInputField = LinkCommunicationColoredClass.string_InputField;
		
		if(bool_CurrentOne)
		{

			Debug.Log("Print elements ||   " + string_OperativeInputField);

			string string_OperativeListEnglish = string_OneTranslation;

			int int_CounterToColorChar = 0;

			if(string_OperativeInputField.Length <= string_OperativeListEnglish.Length)
			{				
				for(int i = 0; i < string_OperativeInputField.Length; i++)
				{
					if(string_OperativeInputField[i] == string_OperativeListEnglish[i])
					{
						int_CounterToColorChar++;
					}
					else
					{
						break;
					}
				}
			}
			Debug.Log("Int COUNTER COLOR 	||||	" + int_CounterToColorChar);
			
			ColorCurrentTextList(true, int_CounterToColorChar);

		}

		if(bool_CurrentTwo)
		{

			Debug.Log("Print elements ||   " + string_OperativeInputField);

			string string_OperativeListFrench = string_TwoTranslation;

			int int_CounterToColorChar = 0;

			if(string_OperativeInputField.Length <= string_OperativeListFrench.Length)
			{				
				for(int i = 0; i < string_OperativeInputField.Length; i++)
				{
					if(string_OperativeInputField[i] == string_OperativeListFrench[i])
					{
						int_CounterToColorChar++;
					}
					else
					{
						break;
					}
				}
			}
			Debug.Log("Int COUNTER COLOR 	||||	" + int_CounterToColorChar);
			
			ColorCurrentTextList(false, int_CounterToColorChar);

		}



		if(bool_CurrentOne == false)
		{

			string string_OperativeListEnglish = string_OneTranslation;

			
			ColorCurrentTextList(true, string_OneTranslation.Length);

		}

		if(bool_CurrentTwo == false)
		{


			string string_OperativeListFrench = string_TwoTranslation;
	
			ColorCurrentTextList(false, string_OperativeListFrench.Length);

		}

    	if(bool_CheckString == true)
    	{

    		bool_CheckString = false;

    			
   			if(string_FromInputField == string_OneTranslation && bool_CurrentOne )
   			{
   			
   				// text_OneTranslation.text = "";
    		
    			bool_CurrentOne = false;
				
				BackGroundOne_0.SetActive(false);

   			}



   			if(string_FromInputField == string_TwoTranslation && bool_CurrentTwo)
   			{

   				// text_TwoTranslation.text = "";

   				bool_CurrentTwo = false;	

				BackGroundTwo_0.SetActive(false);

   			}    			


    	}


    	if(LinkCommunicationColoredClass.bool_ActiveStatus == true)
    	{

    		LinkCommunicationColoredClass.bool_ActiveStatus = false;

    		Debug.Log("String In WordHandler_List = " + LinkCommunicationColoredClass.string_InputField);

    		string_FromInputField = LinkCommunicationColoredClass.string_InputField;


    		bool_CheckString = true;

    	}


    	if(bool_CurrentOne == false && bool_CurrentTwo == false)
    	{
	        float_CurrentTime = Time.realtimeSinceStartup;

			// System.Random randomGeneratorNumber = new System.Random((int) float_CurrentTime);
			// int int_randomListPosition = randomGeneratorNumber.Next(0, list_OfStringWordEnglish.Count);

			System.Random randomGeneratorNumber;
			int int_randomListPosition ;


			randomGeneratorNumber = new System.Random((int) float_CurrentTime);
			int_randomListPosition = randomGeneratorNumber.Next(0, list_OfStringWordEnglish.Count);
			string_OneTranslation = list_OfStringWordEnglish[int_randomListPosition];
			string_TwoTranslation = list_OfStringWordFrench[int_randomListPosition];  
			text_OneTranslation.text = string_OneTranslation;
			text_TwoTranslation.text = string_TwoTranslation;

		
		    bool_CurrentOne = true;
		    bool_CurrentTwo = true;


			float widthText_One = text_OneTranslation.preferredWidth;
			float heightText_One  = text_OneTranslation.preferredHeight;
			
			float widthText_Two = text_TwoTranslation.preferredWidth;
			float heightText_Two  = text_TwoTranslation.preferredHeight;
			
		

			System.Random randomPosition = new System.Random();
	
			float float_OneX = (float)(randomPosition.NextDouble() * 10.5);
			float float_OneY = (float)(randomPosition.NextDouble() * 7.0);
	
			float float_TwoX = (float)(randomPosition.NextDouble() * 10.5);
			float float_TwoY = (float)(randomPosition.NextDouble() * 7.0);
									
			float overpositionComparation = Math.Abs(float_OneY - float_TwoY);
			if(overpositionComparation < 0.9)
			{
				if(float_OneY > float_TwoY)
				{
					float_OneY += 0.9f;
				}				
				else
				{
					float_TwoY += 0.9f;
				}
			}

			// ContainerOne_0.transform.position = coordinateBasePosition + new Vector3(float_OneX, float_OneY, 0.0f);
			// ContainerTwo_0.transform.position = coordinateBasePosition + new Vector3(float_TwoX, float_TwoY, 0.0f);
	
			// BackGroundOne_0.transform.position = coordinateBasePosition + new Vector3(float_OneX, float_OneY, 0.0f);
			// BackGroundTwo_0.transform.position = coordinateBasePosition + new Vector3(float_TwoX, float_TwoY, 0.0f);
	
			// Transform transform_BackOne = BackGroundOne_0.transform;
			// Transform transform_BackTwo = BackGroundTwo_0.transform;
			
			
			// transform_BackOne.localScale = GetScaleBackGround(widthText_One, transform_BackOne.localScale);
			// transform_BackTwo.localScale = GetScaleBackGround(widthText_Two, transform_BackOne.localScale);
	
			// float position = (widthText_One * 0.212f)/1.15f;
			// float position2 = (widthText_Two * 0.212f)/1.15f;
	

			// updatedPositionOne = GetPositionBackGround(widthText_One);
			// updatedPositionTwo = GetPositionBackGround(widthText_Two);

			// transform_BackOne.position +=  updatedPositionOne;
			// transform_BackTwo.position +=  updatedPositionTwo;
	
			// BackGroundOne_0.transform.position = transform_BackOne.position;
			// BackGroundTwo_0.transform.position = transform_BackTwo.position; 


			BackGroundOne_0.SetActive(true);
			BackGroundTwo_0.SetActive(true);



			ContainerOne_0.transform.position = coordinateBasePosition + new Vector3(float_OneX, float_OneY, 0.0f);
			ContainerTwo_0.transform.position = coordinateBasePosition + new Vector3(float_TwoX, float_TwoY, 0.0f);

			BackGroundOne_0.transform.position = coordinateBasePosition + new Vector3(float_OneX, float_OneY, 0.0f);
			BackGroundTwo_0.transform.position = coordinateBasePosition + new Vector3(float_TwoX, float_TwoY, 0.0f);


			ShaderBackGroundOne_0.transform.position = coordinateBasePositionShader + new Vector3(float_OneX, float_OneY, 0.0f);
			ShaderBackGroundTwo_0.transform.position = coordinateBasePositionShader + new Vector3(float_TwoX, float_TwoY, 0.0f);


			Transform transform_ShaderBackOne = ShaderBackGroundOne_0.transform;
			Transform transform_BackOne = BackGroundOne_0.transform;
			Transform transform_ShaderBackTwo = ShaderBackGroundTwo_0.transform;
			Transform transform_BackTwo = BackGroundTwo_0.transform;



			transform_ShaderBackOne.localScale = GetScaleShaderBackGround(widthText_One, transform_ShaderBackOne.localScale);
			transform_BackOne.localScale = GetScaleBackGround(widthText_One, transform_BackOne.localScale);
			transform_ShaderBackTwo.localScale = GetScaleShaderBackGround(widthText_Two, transform_ShaderBackOne.localScale);
			transform_BackTwo.localScale = GetScaleBackGround(widthText_Two, transform_BackOne.localScale);

			float position = (widthText_One * 0.212f)/1.15f;
			float position2 = (widthText_Two * 0.212f)/1.15f;

			updatedPositionOne = GetPositionBackGround(widthText_One);
			updatedPositionTwo = GetPositionBackGround(widthText_Two); 

			transform_BackOne.position +=  updatedPositionOne;
			transform_BackTwo.position +=  updatedPositionTwo;

			transform_ShaderBackOne.position +=  updatedPositionOne;
			transform_ShaderBackTwo.position +=  updatedPositionTwo;


			BackGroundOne_0.transform.position = transform_BackOne.position;
			BackGroundTwo_0.transform.position = transform_BackTwo.position; 

			ShaderBackGroundOne_0.transform.position = transform_ShaderBackOne.position;
			ShaderBackGroundTwo_0.transform.position = transform_ShaderBackTwo.position; 


    	}
        
    }

}
