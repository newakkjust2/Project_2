using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AllVariantsItemSO))]
[CanEditMultipleObjects]
public class InventoryCollectionInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(20);
        if (GUILayout.Button("refresh"))
        {
            var v = (AllVariantsItemSO) target;
            v.Refresh();
        }
    }
}
