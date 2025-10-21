using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private List<Bee> _drones;
    private List<Bee> _queens;

    private int _honey;

    private string _name;

    public List<Bee> Drones { get { return _drones; } }
    public List<Bee> Queens { get { return _queens; } }
    public string PlayerName { get { return _name; } }
    public int Honey { get { return _honey; } }
  
    public PlayerData(string name)
    {
        _name = name;
        _drones = new List<Bee>();
        _queens = new List<Bee>();
    }

    public void AddBee(Bee bee)
    {
        if(bee.IsQueen)
        {
            _queens.Add(bee);
        }
        else
        {
            _drones.Add(bee);
        }
    }

    public void RemoveBee(Bee bee)
    {
        if (bee.IsQueen)
        {
            if (_queens.Contains(bee))
                _queens.Remove(bee);
        }
        else
        {
            if (_drones.Contains(bee))
                _drones.Remove(bee);
        }
    }

    public void AddHoney(int value)
    {
        _honey += value;
    }
}
