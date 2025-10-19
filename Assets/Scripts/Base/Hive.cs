using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive
{
    private int _capasity;
    private Bee[] _bees;

    public Hive (int Capasity)
    {
        _capasity = Capasity;
        _bees = new Bee[_capasity];
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
}
