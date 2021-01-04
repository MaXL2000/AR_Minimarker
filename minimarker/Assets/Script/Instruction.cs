using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Instruction : MonoBehaviour
{
    //Счетчик инструкции
    static private int queue = 1;
    //Включение блока питания
    public GameObject Point1;
    //Открыть крышку маркера
    public GameObject Point2;
    //Закрыть защитную пластину
    public GameObject Point3;

    public GameObject Previos;
    public Mesh Text_mesh;
    private void NextStep(GameObject SomeObj)
    {
        if (Previos != null)
        {
            Previos.SetActive(false);
        }
        SomeObj.SetActive(true);
        Previos = SomeObj;
        queue += 1;
    }

    public void DoSome()
    {

        if(queue == 1)
        {
            NextStep(Point1);
        }
        else
        if (queue == 2)
        {
            NextStep(Point2);
        }
        else
        if (queue == 3)
        {
            NextStep(Point3);
            queue = 1;
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
