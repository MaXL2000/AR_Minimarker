using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Instruction : MonoBehaviour
{
    //Счетчик инструкции
    private int queue = 1;
    //Кнопка далее
    public GameObject NextButton;
    //Кнопка назад
    public GameObject PreviousButton;
    //Включение блока питания и управления
    public GameObject Point1;
    //Работа в плоскости
    public GameObject Point2;
    //Откройте крышку лазера
    public GameObject Point3;
    //установка заготовки
    public GameObject Point4;
    //установка флажка
    public GameObject Point5;
    //Защитная пластина
    public GameObject Point6;
    //Порядковый номере инструкции
    public TextMeshProUGUI StepNumberUI;
    //описание инструкции
    public TextMeshProUGUI InstructionTextUI;

    public GameObject PreviosGO;
    public TextMeshProUGUI PreviosUI;

    Stack<GameObject> stackGO = new Stack<GameObject>();

    private void NextStep(GameObject AddNewGO)
    {
        PreviousButton.SetActive(true);
        StepOfInstruction s = instruction1[queue - 1];
        StepNumberUI.text = s.number;
        InstructionTextUI.text = s.text;
        InstructionTextUI.color = Color.green;
        queue += 1;


        if (stackGO.Count!=0)
        {
            stackGO.Peek().SetActive(false);
        }

        AddNewGO.SetActive(true);
        stackGO.Push(AddNewGO);
    }


    enum TypeOfInstruction { NoAr, AR };
    class StepOfInstruction
    {
        //Номер инстукции
        public string number;
        //
        public string text;
        public TypeOfInstruction type;

        public StepOfInstruction(string number, TypeOfInstruction type, string text)
        {
            this.number = number;
            this.type = type;
            this.text = text;
            
        }

    }

    List<StepOfInstruction> instruction1 = new List<StepOfInstruction>() {
new StepOfInstruction("1",TypeOfInstruction.NoAr,"Включите компьютер"),
new StepOfInstruction("2",TypeOfInstruction.AR,"Включите блок питания и управления"),
new StepOfInstruction("3",TypeOfInstruction.NoAr,"Запустить программу MARKER"),
new StepOfInstruction("4",TypeOfInstruction.NoAr,"Убедитесь, что программа работает корректно"),
new StepOfInstruction("5",TypeOfInstruction.AR,"Выберите работу в плоскости LES5 или на поворотном устройстве ПВ60М"),
new StepOfInstruction("6",TypeOfInstruction.NoAr,"Запустите необходимую программу на компьтере"),
new StepOfInstruction("7",TypeOfInstruction.AR,"Откройте крышку лазера"),
new StepOfInstruction("8",TypeOfInstruction.AR,"На рабочем столе устанавите заготовку."),
new StepOfInstruction("9",TypeOfInstruction.AR,"Установите флажок для настройки фокуса"),
new StepOfInstruction("10",TypeOfInstruction.AR,"Флажок фокуса, должен соответствовать объективу установленном на лазерной установке."),
new StepOfInstruction("11",TypeOfInstruction.AR,"Уберите флажок"),
new StepOfInstruction("12",TypeOfInstruction.AR,"Опустите защитную пластину"),
new StepOfInstruction("13",TypeOfInstruction.NoAr,"Нажимаем в MARKER СТАРТ"),
};



    public void DoSome()
    {
        StepOfInstruction s;
        switch (queue)
        {
      
            case 2:
                PreviousButton.SetActive(true);
                //s = instruction1[queue - 1];
                NextStep(Point1);
                //StepNumberUI.text = s.number;
                //InstructionTextUI.text = s.text;
                //InstructionTextUI.color = Color.green;
                //queue += 1;
                break;
            case 5:
                //s = instruction1[queue - 1];
                NextStep(Point2);
                //StepNumberUI.text = s.number;
                //InstructionTextUI.text = s.text;
                //queue += 1;
                break;
            case 7:
                
                NextStep(Point3);
               
                break;
            case 8:
                
                NextStep(Point4);
                
                break;
            case 9:
                
                NextStep(Point5);
               
                break;
            case 10:
                
                NextStep(Point5);
                
                break;
            case 11:
                
                NextStep(Point5);
               
                break;
            case 12:
               
                NextStep(Point6);
                
                break;

            default:
                StepOfInstruction prevStep;
            if (queue == 13)
            {
            NextButton.SetActive(false);

            }
            //queue = queue - 1;
            if (queue!= 1)
            {
            prevStep = instruction1[queue-2];
            }
            else prevStep = null;

            if ((prevStep != null) && (prevStep.type == TypeOfInstruction.AR))
            {
            stackGO.Peek().SetActive(false);
            }
            s = instruction1[queue - 1];
            StepNumberUI.text = s.number;
            InstructionTextUI.text = s.text;
            InstructionTextUI.color = Color.blue;
            PreviosUI = StepNumberUI;
            queue += 1;
            break;
        }

    }

    public void PreviousStep()
    {
        StepOfInstruction prevStep;
        StepOfInstruction currentStep;

        //Сделать кнопку назад видимой если она была отключена (в конце)
    
        if (NextButton.activeSelf == false)
        {
            NextButton.SetActive(true);
        }

        //Сделать кнопку назад невидимой если она была включена (в начале)
        if ((PreviousButton.activeSelf == true)&&(queue-2==1))
        {
            PreviousButton.SetActive(false);
        }

        //queue = queue - 1;
        if (queue - 3 != -1)
        {
            prevStep = instruction1[queue - 3];
        }
        else prevStep = null;
       
        currentStep = instruction1[queue-2];

        if (prevStep == null) return;


        //Если текущий тип AR
        if (currentStep.type == TypeOfInstruction.AR)
        {
            //Выключаем текущий объект AR и удаляем его из стека
            stackGO.Pop().SetActive(false);
            //if (stackGO.Count != 0)
            //    {
            //        stackGO.Pop().SetActive(false);
            //    }

            //Если предыдущий объект есть и он AR
            if ((prevStep!=null)&&(prevStep.type == TypeOfInstruction.AR)) {
                stackGO.Pop();
                queue = queue - 2;
                DoSome();
            }
            //Если предыдущий объект есть и он NoAr
            if ((prevStep != null) && (prevStep.type == TypeOfInstruction.NoAr))
            {
                queue = queue - 2;
                DoSome();
            }      
        }
        //Если текущий тип NoAr а предыдущий Ar
        else
        if((prevStep != null) && (prevStep.type == TypeOfInstruction.AR))
        {
            stackGO.Pop();
            queue =queue-2;
            DoSome();
        }
        //Если текущий тип NoAr и предудущий NoAr
        else
        {
            queue = queue - 2;
            DoSome();
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