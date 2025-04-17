using UnityEngine;

public class HoldSignal : Signal
{
    //1. �����ǰ� �ִ� ���¸� �˾ƾ߉�
    //2. ���� ���ʰ� �������� �˾ƾ߉�
    //3. holdTime�ʰ� �������� && �����ǰ� �ִ� ���� �϶� EndSignal(true) ��

    public float holdTime; //�� ������ ��� �� ��ŭ ��� �־�� �����

    public float holdTimer = 0f;
    
    public bool holding = false; 
    
    
    public void Update()
    {
        if (holding == true)
        {
            // �浹 ���� ���� �� Ÿ�̸� ����
            holdTimer += Time.deltaTime;

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
        }
        else if (on == false)
        {
            holding = false;
            holdTimer = 0f;
            
        }
    }

    public override void EndSignal(bool complete)
    {
        if (complete == true)
        {
            Destroy(signalObject);
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


