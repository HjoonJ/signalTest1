using UnityEngine;

public class HoldSignal : Signal
{
    //1. 유지되고 있는 상태를 알아야됌
    //2. 현재 몇초가 지났는지 알아야됌
    //3. holdTime초가 지났을때 && 유지되고 있는 상태 일때 EndSignal(true) 함

    public float holdTime; //이 변수에 담긴 초 만큼 닿고 있어야 사라짐

    public float holdTimer = 0f;
    
    public bool holding = false; 
    
    
    public void Update()
    {
        if (holding == true)
        {
            // 충돌 유지 중일 때 타이머 증가
            holdTimer += Time.deltaTime;

            // 설정된 시간 이상 유지되면 오브젝트를 파괴 
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


