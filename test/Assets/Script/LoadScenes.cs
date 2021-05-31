using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
	static private int queue = 1;
    // Start is called before the first frame update
    //public void ChangeScenes()
    //{
    //	if (queue < 4){
    //		SceneManager.LoadScene(queue);
    //		queue = queue + 1;
    //	}
    //	else{
    //		queue = 0;
    //		SceneManager.LoadScene(queue);
    //		queue = queue + 1;
    //	}
    //}
    public void BackMenu()
    {
    	SceneManager.LoadScene(0);
    }
    public void NextZnakomstvo()
    {
    	SceneManager.LoadScene(1);
    }
    public void NextInstruction()
    {
    	SceneManager.LoadScene(2);
    }
    public void NextError()
    {
    	SceneManager.LoadScene(3);
    }
    public void NextHelp()
    {
    	SceneManager.LoadScene(4);
    }
}
