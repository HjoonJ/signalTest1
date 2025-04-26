using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CountSignal : Signal
{
    // 정해진 시간 안에 정해진 횟수만큼 터치하기.

    public TMP_Text countText;
    public Image timerBar;

    public float limitTime; // 정해진 시간
    public float timer = 0f; // 타이머
    
    public int touchCount; //정해진 횟수
    public int currentCount = 0; //현재 횟수

    public bool counting = false;

    private void Start()
    {
        touchCount = Random.Range(2, 6); // 2,3,4,5 나옴
        
        countText.text = touchCount.ToString();
        timerBar.fillAmount = 1;
    }

    void Update()
    {
        if (counting == true)
        {
            // 충돌 유지 중일 때 타이머 증가
            timer += Time.deltaTime;

            timerBar.fillAmount = (limitTime - timer)/limitTime;

            // 설정된 시간 이상 유지되면 오브젝트를 파괴 
            if (timer <= limitTime && currentCount == touchCount)
            {
                EndSignal(true);
                counting = false;
            }

            else if (timer > limitTime)
            {
                counting = false;
                timer = 0f;
                timerBar.fillAmount = 1f;
                currentCount = 0;
                
            }
        }
    }

    public override void StartSignal(SignalMethod signalMethod = SignalMethod.Any, bool on = false)
    {
        if (on == true)
        {
            counting = true;
            currentCount++;
            countText.text = (touchCount - currentCount).ToString();
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



}
