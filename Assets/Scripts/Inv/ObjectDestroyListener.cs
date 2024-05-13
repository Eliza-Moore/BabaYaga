using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class ObjectDestroyListener : MonoBehaviour
{
    // Ссылка на блок в Fungus, который нужно запустить после уничтожения объекта
    public Flowchart fungusFlowchart;

    // Функция, вызываемая при уничтожении объекта
    void OnDestroy()
    {
        // Активация блока в Fungus
        fungusFlowchart.ExecuteBlock("Item1");
    }
}
