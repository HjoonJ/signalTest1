using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class SequenceSignal : Signal
{    
    public SequenceElement[] elements;

    public Image timerBar;

    public int nextNumber; //���������� ��ȣ�� �����ϰԲ� ����� ���� ����

 
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

    //�迭 ����ȭ
    public static T[] FisherShuffle<T>(T[] array)
    {
        System.Random random = new System.Random();

        for (int i = array.Length - 1; i > 0; i--)
        {
            // i������ �������� ������ �ε����� ����
            int j = random.Next(0, i + 1);

            // ���� ��ҿ� ������ ��Ҹ� ��ȯ
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        return array;
    }

    public void ElementTouched(SequenceElement sequenceElement)
    {
        // �ùٸ� ���ڶ�� Destroy, ���� ���� ���
        if (sequenceElement.number == nextNumber)
        {
            sequenceElement.gameObject.SetActive(false);

            nextNumber++;

            // ��� �ùٸ��� ��ġ �� ���� ��������
            if (nextNumber > elements.Length)
            {
                EndSignal(true);
                // Ŭ����!!
            }
        }
        else
        {
            //�����ϰų� �г�Ƽ
            ResetSequence();
        }
    }

    private void ResetSequence()
    {
        // �ٽ� ����!
        Start();

    }


}
