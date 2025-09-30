using NUnit.Framework;
using UnityEngine;

public class DefineLevel : MonoBehaviour
{
    public int level;
    void Start()
    {
        GameData.currentLevel = level;
    }
}
