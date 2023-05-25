using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BasicOpponentData", fileName = "NewOpponentData")]
public class BasicOpponentData : ScriptableObject {
    [SerializeField] private float attackThreshold;
    [SerializeField] private float backupAmount;
    [SerializeField] private float rotationSpeed;

    public float GetAttackThreshold() {
        return attackThreshold;
    }

    public float GetBackupAmount() {
        return backupAmount;
    }

    public float GetRotationSpeed() {
        return rotationSpeed;
    }
}
