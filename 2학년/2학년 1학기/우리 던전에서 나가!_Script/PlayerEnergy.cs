using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    public event Action PlayerTurnEnd;

    private GameUI pieceManager;
    private int energy = 0;

    private void Awake()
    {
        pieceManager = FindObjectOfType<GameUI>();
    }

    public void TurnStart(int newTurnEnergy)
    {
        TMananger.instance.CurrnetState = GameState.PlayerTurn;
        energy = newTurnEnergy;
        pieceManager.Resetleadership(energy);
    }

    public int GetEnergy()
    {
        return energy;
    }

    public void PlusEnergy(int plusEnergy)
    {
        energy += plusEnergy;
    }

    public void MinusEnergy(int value)
    {
        energy -= value;

        if(energy == 0)
        {
            StartCoroutine(GoEnemyTurn());
        }
    }

    private IEnumerator GoEnemyTurn()
    {
        yield return new WaitForSeconds(0.1f);

        if (energy == 0)
        {
            TMananger.instance.CurrnetState = GameState.EnemyTurn;
            PlayerTurnEnd?.Invoke();
        }
    }
}
