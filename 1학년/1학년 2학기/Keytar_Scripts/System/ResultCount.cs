using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultCount
{

    private int play = 0;
    private int miss = 0;
    private int moving = 0;
    private int atkSuccess = 0;
    private float energySum = 0;
    private float energycnt = 0;
    private float energyAccurary = 0;

    public int Score = 0;
    public int Play
    {
        get { return play; }
        set
        {
            play = value;
        }
    }
    public int Miss
    {
        get { return miss; }
        set
        {
            miss = value;
        }
    }
    public int Moving
    {
        get { return moving; }
        set
        {
            moving = value;
        }
    }
    public int ATKSuccess
    {
        get { return atkSuccess; }
        set
        {
            atkSuccess = value;
        }
    }
    public float EnergyAccurary
    {
        get { return energyAccurary; }
    }
    public float EnergySum
    {
        get { return energySum; }
        set
        {
            energySum = value;

            energycnt++;
            energyAccurary = energySum / energycnt;
        }
    }
    public float Accuracy = 0;
}
