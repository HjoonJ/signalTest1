using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class SequenceSignal : Signal
{    
    public SequenceElement[] elements;

    public Image timerBar;

    public int nextNumber; //순차적으로 번호를 선택하게끔 만들기 위한 변수

 
    public void Start()
    {
        int[] nums = new int[4];

        for (int i = 0; i < nums.Length; i++)
        { 
            nums[i] = i+1;
        }

        nums = FisherShuffle(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            int number = nums[i];

            elements[i].SetNumber(number);

            elements[i].gameObject.SetActive(true);
        
        }

        nextNumber = 1;

    }

    //배열 랜덤화
    public static T[] FisherShuffle<T>(T[] array)
    {
        System.Random random = new System.Random();

        for (int i = array.Length - 1; i > 0; i--)
        {
            // i까지의 범위에서 무작위 인덱스를 선택
            int j = random.Next(0, i + 1);

            // 현재 요소와 무작위 요소를 교환
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        return array;
    }

    public void ElementTouched(SequenceElement sequenceElement)
    {
        // 올바른 숫자라면 Destroy, 다음 숫자 대기
        if (sequenceElement.number == nextNumber)
        {
            sequenceElement.gameObject.SetActive(false);

            nextNumber++;

            // 모두 올바르게 터치 시 다음 스테이지
            if (nextNumber > elements.Length)
            {
                EndSignal(true);
                // 클리어!!
            }
        }
        else
        {
            //리셋하거나 패널티
            ResetSequence();
        }
    }

    private void ResetSequence()
    {
        // 다시 시작!
        Start();

    }


}
