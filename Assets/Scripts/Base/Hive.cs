using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hive: ITick, IUpgrades
{
    private BeeQueen _beeQueen;
    private Bee[] _bees;
    private int _production = 0;
    private int _maxProduction = 20;
    private List<Upgrade> upgrades;

    public Bee[] Bees { get { return _bees; } }
    public Bee BeeQueen { get { return _beeQueen == null ? null : _beeQueen.Bee; } }

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

    public void LiveTick(WeatherData weather)
    {
        if (_beeQueen == null)
        {
            //Try find bee for breeding
            if(ContainBee()> 1 )
            {
                BeeBriding();
            }
            else
                return;
        }
        if(IsSlotAvailable())
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

    private void BeeBriding()
    {
        Bee drone = null, queen = null;
        bool droneFinded = false;
        foreach (var bee in _bees)
        {
            if (bee == null)
                continue;
            if (bee.IsQueen)
                queen = bee;
            else
            {
                if (!droneFinded)
                {
                    drone = bee;
                    droneFinded = true;
                }
            }
        }
        if (drone != null && queen != null)
        {
            _beeQueen = new BeeQueen(queen, drone);
            for (int i = 0; i < _bees.Length; i++)
            {
                _bees[i] = null;
            }
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
            LiveTick(new WeatherData());
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
            if (bee != null)
                counter++;
        }
        return counter < _bees.Length;
    }

    public int ContainBee()
    {
        int count = 0;
        if (_beeQueen != null)
            count += 1;
        foreach (Bee bee in _bees)
        {
            if (bee != null)
                count++;
        }

        return count;
    }

    public void AddUpgrade(Upgrade upgrade)
    {
        upgrades.Add(upgrade);
    }

    public void RemoveUpgrade(Upgrade upgrade)
    {
        if(upgrades.Contains(upgrade))
            upgrades.Remove(upgrade);
    }
}
