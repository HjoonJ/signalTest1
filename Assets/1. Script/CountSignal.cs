using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CountSignal : Signal
{
    // ������ �ð� �ȿ� ������ Ƚ����ŭ ��ġ�ϱ�.

    public TMP_Text countText;
    public Image timerBar;

    public float limitTime; // ������ �ð�
    public float timer = 0f; // Ÿ�̸�
    
    public int touchCount; //������ Ƚ��
    public int currentCount = 0; //���� Ƚ��

    public bool counting = false;

    private void Start()
    {
        touchCount = Random.Range(2, 6); // 2,3,4,5 ����
        
        countText.text = touchCount.ToString();
        timerBar.fillAmount = 1;
    }

    void Update()
    {
        if (counting == true)
        {
            // �浹 ���� ���� �� Ÿ�̸� ����
            timer += Time.deltaTime;

            timerBar.fillAmount = (limitTime - timer)/limitTime;

            // ������ �ð� �̻� �����Ǹ� ������Ʈ�� �ı� 
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
