using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HoldSignal : Signal
{
    //1. �����ǰ� �ִ� ���¸� �˾ƾ߉�
    //2. ���� ���ʰ� �������� �˾ƾ߉�
    //3. holdTime�ʰ� �������� && �����ǰ� �ִ� ���� �϶� EndSignal(true) ��

    public TMP_Text onText;
    public Image timerBar;


    public float holdTime; //�� ������ ��� �� ��ŭ ��� �־�� �����

    public float holdTimer = 0f;
    
    public bool holding = false; 
    
    
    public void Update()
    {
        if (holding == true)
        {
            // �浹 ���� ���� �� Ÿ�̸� ����
            holdTimer += Time.deltaTime;

            timerBar.fillAmount = (holdTime - holdTimer) / holdTime;

            // ������ �ð� �̻� �����Ǹ� ������Ʈ�� �ı� 
            if (holdTimer >= holdTime)
            {
                EndSignal(true);
                holding = false;   
            }
        }
    }


    public override void StartSignal(SignalMethod signalMethod = SignalMethod.Any, bool on = false)
    {
        if (on == true)
        {
            holding = true;
            onText.text = "On";
        }
        else if (on == false)
        {
            holding = false;
            onText.text = "Off";
            holdTimer = 0f;
            timerBar.fillAmount = 1;


        }
    }




    public override void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            //Debug.Log($"Signal OnTriggerEnter Player {other.gameObject.name}");

            StartSignal(on: true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartSignal(on: false);
            
        }

        

    }

}


