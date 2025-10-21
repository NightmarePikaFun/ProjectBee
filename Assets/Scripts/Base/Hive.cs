using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive
{
    private BeeQueen _beeQueen;
    private Bee[] _bees;
    private int _production = 0;
    private int _maxProduction = 20;

    public Hive ()
    {
        _bees = new Bee[6];
    }

    public void Production()
    {
        if(_production < _maxProduction )
        {
            _production++;
        }
    }

    public void LifeCycle()
    {
        if(_beeQueen == null && IsSlotAvailable())
        {
            AddBee(new Bee(_beeQueen));
        }
        for(int i = 0; i < _bees.Length; i++)
        {
            if (_bees[i] != null)
            {
                _bees[i].LifeTick();
                if (_bees[i].Health <= 0)
                {
                    _bees[i] = null;
                }
            }
        }
        _beeQueen.LifeTick();
        if(_beeQueen.Health <= 0)
        {
            for (int i = 0; i < _bees.Length; i++)
            {
                _bees[i] = null;
            }
            //Create child
            _beeQueen = null;
        }
    }


    public bool AddBee(Bee bee)
    {
        if(IsSlotAvailable())
        {
            int counter = 0;
            foreach (Bee _bee in _bees)
            {
                if (_bee != null)
                    counter++;
                else
                    break;
            }
            _bees[counter] = bee;
            return true;
        }
        return false;
    }

    public int CollectHoney()
    {
        int returendProduction = _production;
        _production = 0;
        return returendProduction;
    }

    private bool IsSlotAvailable()
    {
        int counter = 0;
        foreach(Bee bee in _bees)
        {
            if (bee == null)
                counter++;
        }
        return counter < _bees.Length;
    }

    public bool ContainBee()
    {
        if (_beeQueen != null)
            return true;
        foreach(Bee bee in _bees)
        {
            if (bee != null)
                return true;
        }

        return false;
    }
}
