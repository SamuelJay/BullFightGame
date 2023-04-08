using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BasicOpponentData", fileName = "NewOpponentData")]
public class BasicOpponentData : ScriptableObject
{
    [SerializeField] private int attackThreshold;

    public int GetAttackThreshold() 
    {
        return attackThreshold;
    }
}
