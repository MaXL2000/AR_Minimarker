using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class training : MonoBehaviour
{


    public GameObject Step1;
    public GameObject Step2;
    public GameObject Step3;
    public GameObject Step4;

    int step=1;

    public void NextStep()
    {

        switch (step)
        {
            case 1:
                Step4.SetActive(false);
                Step1.SetActive(true);
                step++;
                break;
            case 2:
                Step1.SetActive(false);
                Step2.SetActive(true);
                step++;
                break;
            case 3:
                Step2.SetActive(false);
                Step3.SetActive(true);
                step++;
                break;
            case 4:
                Step3.SetActive(false);
                Step4.SetActive(true);
                step = 1;
                break;




        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
