using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMonster : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private AudioSource audioSource;

    private GameObject _monster;
    private bool _isMonsterPlaced = false;
    private void OnMouseUp()
    {
        if (_isMonsterPlaced == false)
        {
            _monster = Instantiate(monsterPrefab, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(audioSource.clip);
            _isMonsterPlaced = true;
            //TODO: remove gold
        }
        else if (CanUpgradeMonster())
        {
            _monster.GetComponent<Monster>().IncreaseLevel();
            audioSource.PlayOneShot(audioSource.clip);
            //TODO: remove gold
        }
        
    }
    private bool CanUpgradeMonster()
    {
        if (_monster == null) return false;
        var monster = _monster.GetComponent<Monster>();
        var nextLevel = monster.GetNextLevel();
        return nextLevel != null;
    }
}
