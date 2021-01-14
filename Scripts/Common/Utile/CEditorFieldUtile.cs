#if UNITY_EDITOR
using Sirenix.Utilities.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;

public static partial class CEditorGUIUtile
{
    public static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
    {
        return (propertyExpression.Body as MemberExpression).Member.Name;
    }

    public static bool ToggleField(string _Title, bool _Value)
    {
        SirenixEditorGUI.BeginIndentedHorizontal();
        GUILayout.Label(_Title);
        _Value = EditorGUILayout.Toggle(_Value);
        SirenixEditorGUI.EndIndentedHorizontal();

        return _Value;
    }

    public static Enum EnumField(string _Title, Enum _Value, params GUILayoutOption[] _Options)
    {
        SirenixEditorGUI.BeginIndentedHorizontal();
        GUILayout.Label(_Title);
        _Value = SirenixEditorFields.EnumDropdown(_Value, _Options);
        SirenixEditorGUI.EndIndentedHorizontal();

        return _Value;
    }
    public static Enum EnumField(string _Title,GUIContent _GUIContent, Enum _Value,GUIStyle _GUIStyle, params GUILayoutOption[] _Options)
    {
        SirenixEditorGUI.BeginIndentedHorizontal();
        GUILayout.Label(_Title);
        _Value = SirenixEditorFields.EnumDropdown(_GUIContent,_Value, _GUIStyle, _Options);
        SirenixEditorGUI.EndIndentedHorizontal();

        return _Value;
    }

    public static int LabelField(string _Title, int _Value)
    {
        SirenixEditorGUI.BeginIndentedHorizontal();
        GUILayout.Label(_Title);
        GUILayout.Label(_Value.ToString());
        SirenixEditorGUI.EndIndentedHorizontal();

        return _Value;
    }

    public static int IntField(string _Title, int _Value)
    {
        SirenixEditorGUI.BeginIndentedHorizontal();
        GUILayout.Label(_Title);
        _Value = EditorGUILayout.IntField(_Value); 
        SirenixEditorGUI.EndIndentedHorizontal();

        return _Value;
    }


    public static float FloatField(string _Title, float _Value)
    {
        SirenixEditorGUI.BeginIndentedHorizontal();
        GUILayout.Label(_Title);
        _Value = EditorGUILayout.FloatField(_Value);
        SirenixEditorGUI.EndIndentedHorizontal();

        return _Value;
    }

    public static string StringField(string _Title, string _Value)
    {
        SirenixEditorGUI.BeginIndentedHorizontal();
        GUILayout.Label(_Title);
        _Value = EditorGUILayout.TextField(_Value);
        SirenixEditorGUI.EndIndentedHorizontal();

        return _Value;
    }
    public static Vector3 Vector3Field(string _Title, Vector3 _Value)
    {
        SirenixEditorGUI.BeginIndentedHorizontal();
        GUILayout.Label(_Title);
        _Value = SirenixEditorFields.Vector3Field(_Value);
        SirenixEditorGUI.EndIndentedHorizontal();

        return _Value;
    }

    public static UnityEngine.Object UnityObjectField(string _Title,GUIContent _GUIContent, UnityEngine.Object _Value, Type _Type,bool _allowSceneObjects)
    {
        SirenixEditorGUI.BeginIndentedHorizontal();
        GUILayout.Label(_Title);
        _Value = SirenixEditorFields.UnityObjectField(_GUIContent,_Value, _Type, _allowSceneObjects);
        SirenixEditorGUI.EndIndentedHorizontal();

        return _Value;
    }

    public static void BeginHorizomtalBox()
    {
        SirenixEditorGUI.BeginBox();
        SirenixEditorGUI.BeginIndentedHorizontal();
    }

    public static void EndHorizomtalBox()
    {
        SirenixEditorGUI.EndBox();
        SirenixEditorGUI.EndIndentedHorizontal();
    }

    public static void BeginVerticalBox()
    {
        SirenixEditorGUI.BeginBox();
        SirenixEditorGUI.BeginIndentedVertical();
    }

    public static void EndVerticalBox()
    {
        SirenixEditorGUI.EndBox();
        SirenixEditorGUI.EndIndentedVertical();
    }
}
#endif