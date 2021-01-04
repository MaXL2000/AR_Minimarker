using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
	static private int queue = 1;
    // Start is called before the first frame update
    public void ChangeScenes()
    {
    	if (queue < 4){
    		SceneManager.LoadScene(queue);
    		queue = queue + 1;
    	}
    	else{
    		queue = 0;
    		SceneManager.LoadScene(queue);
    		queue = queue + 1;
    	}
    }
}
