using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class ObjectDestroyListener : MonoBehaviour
{
    // ������ �� ���� � Fungus, ������� ����� ��������� ����� ����������� �������
    public Flowchart fungusFlowchart;

    // �������, ���������� ��� ����������� �������
    void OnDestroy()
    {
        // ��������� ����� � Fungus
        fungusFlowchart.ExecuteBlock("Item1");
    }
}
