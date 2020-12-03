using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
 public class MonsterLevel
 {
     [SerializeField] private int cost;
     [SerializeField] private GameObject visual;

     public int Cost => cost;

     public GameObject Visual => visual;
 }
public class Monster : MonoBehaviour
{
    [SerializeField] private List<MonsterLevel> monsterLevels;

    private MonsterLevel _currentLevel;

    public MonsterLevel CurrentLevel
    {
        get => _currentLevel;
        set
        {
            _currentLevel = value;
            var currentLevelIndex = monsterLevels.IndexOf(_currentLevel);
            var visualization = monsterLevels[currentLevelIndex].Visual;
            for (var i = 0; i < monsterLevels.Count; i++)
            {
                if (visualization == null) continue;
                monsterLevels[i].Visual.SetActive(i == currentLevelIndex);
            }
        }
    }

    public MonsterLevel GetNextLevel()
    {
        var currentLevelIndex = monsterLevels.IndexOf(_currentLevel);
        var maxLevel = monsterLevels.Count - 1;
        return currentLevelIndex < maxLevel ? monsterLevels[currentLevelIndex + 1] : null;

    }
    public void IncreaseLevel()
    {
        var currentLevelIndex = monsterLevels.IndexOf(_currentLevel);
        if (currentLevelIndex < monsterLevels.Count - 1)
        {
            CurrentLevel = monsterLevels[currentLevelIndex + 1];
        }
    }

    private void OnEnable()
    {
        CurrentLevel = monsterLevels[0];
    }
}
