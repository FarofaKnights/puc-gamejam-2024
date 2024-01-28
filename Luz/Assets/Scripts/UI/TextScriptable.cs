using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SimpleText {
    [TextAreaAttribute(3, 10)]
    public string text;
    public UIController.HaikouType type;
}


[CreateAssetMenu(fileName = "TextScriptable", menuName = "ScriptableObjects/TextScriptable", order = 1)]
public class TextScriptable : ScriptableObject {
    public List<SimpleText> texts;
}