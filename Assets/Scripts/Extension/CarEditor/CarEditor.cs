using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NaughtyAttributes;

[CustomEditor(typeof(Car))]
public class CarEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var car = (Car)target;
        
        base.OnInspectorGUI();
        

        if (GUILayout.Button("Botao Inutil"))
        {
            Debug.Log("Esse botao não fez nada!");
        }


        if (GUILayout.Button("Spawnar Carro"))
        {
            car.spawnCarro();
        }


    }
}
