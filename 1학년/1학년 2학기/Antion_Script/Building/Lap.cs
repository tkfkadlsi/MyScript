using Karin;
using System.Collections;
using System.Collections.Generic;
using Tkfkadlsi;
using UnityEngine;

public class Lap : MonoBehaviour, IStructure
{
    public BuildingBuild StructureData { get => structureData; set => structureData = value; }
    [SerializeField] private BuildingBuild structureData;
    public float CurrentHp { get; set; } = 0;
    public float MaxHP { get; set; } = 0;
    public GameObject MygameObject { get; set; }

    private void Awake()
    {
        MaxHP = structureData.maxHealth;
        MygameObject = gameObject;
        CurrentHp = StructureData.maxHealth;
    }
}
