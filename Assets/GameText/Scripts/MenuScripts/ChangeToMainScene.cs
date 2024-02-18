using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using StyleModeNamespace;

public class ChangeToMainScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    int int_StyleMode = 0;
    int int_CurrentScene = 0;


	public void MenuToMainSceneChallenge()
    {
        
        int_StyleMode = 0;
	
        StyleModeClass.int_StyleMode = 0;    

    	SceneManager.LoadScene(sceneBuildIndex:1);
    
    }


	public void MenuToMainSceneFreeMode()
    {
        int_StyleMode = 1;        

        StyleModeClass.int_StyleMode = 1;    
    	SceneManager.LoadScene(sceneBuildIndex:1);
        
    }

    public void MainToMenuGeneral()
    {

    	SceneManager.LoadScene(sceneBuildIndex:0);
        
    }
    

    public void LeftArrowChangeScene()
    {
        
        int_CurrentScene = StyleModeClass.int_CurrentSceneGeneral - 1;

        StyleModeClass.int_CurrentSceneGeneral = int_CurrentScene;
        
        if(int_CurrentScene < 1)
        {
            int_CurrentScene = 1;
            StyleModeClass.int_CurrentSceneGeneral = int_CurrentScene;
    
        }

    	SceneManager.LoadScene(sceneBuildIndex:int_CurrentScene);

    }


    public void RightArrowChangeScene()
    {
        
        int_CurrentScene = StyleModeClass.int_CurrentSceneGeneral + 1;
        StyleModeClass.int_CurrentSceneGeneral = int_CurrentScene;


        if(int_CurrentScene > 11)
        {
            int_CurrentScene = 11;
            StyleModeClass.int_CurrentSceneGeneral = int_CurrentScene;

        }

    	SceneManager.LoadScene(sceneBuildIndex:int_CurrentScene);

    }


    // public void MainToMenuGeneral()
    // {

    // 	SceneManager.LoadScene(sceneBuildIndex:11);
        
    // }




    // Update is called once per frame
    void Update()
    {
        
    }
}
