using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Car))]
public class CarEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        Car myTarget = (Car)target;

        myTarget.carPrefab = (GameObject) EditorGUILayout.ObjectField("Car Prefab", myTarget.carPrefab, typeof(GameObject), true);
        myTarget.speed = EditorGUILayout.IntField("Car Speed", myTarget.speed);
        myTarget.gear = EditorGUILayout.IntField("Car Gear", myTarget.gear);

        EditorGUILayout.LabelField("Total Speed", myTarget.TotalSpeed.ToString());

        if(myTarget.TotalSpeed > 200)
        {
            EditorGUILayout.HelpBox("Error: Total speed is too high!", MessageType.Error);
        }

        GUI.color =  Color.lightPink;
        
        if(GUILayout.Button("Create Car"))
        {
            myTarget.InstantiateCar();  
        }
    }
}
