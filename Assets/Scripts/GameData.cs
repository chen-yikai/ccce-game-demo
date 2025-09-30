using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class GameData
{
    public static string answer;
    public static List<ToolType> Tools = new List<ToolType>();
    public static List<ToolType> LevelRequiredTools = new List<ToolType>();
    public static List<int> levelRequiredToolsCount = new List<int> { 1, 2 };
    public static int currentLevel = 2;
    public static GameObject currentNoteBook;
}

public enum ToolType
{
    NoteBook,
    Pen,
}