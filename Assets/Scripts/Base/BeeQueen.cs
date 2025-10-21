using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeQueen
{
    private Bee _queen;
    public Bee Bee { get { return _queen; } }
    public Genetics Gens { get { return _queen.Gens; } }
    public float Health { get { return _queen.Health; } }
    public float Production { get { return _queen.Production; } }
    public float LifeTime { get { return _queen.LifeTime; } }

    public BeeQueen(Bee queen, Bee drone)
    {
        //Breeding and mutatuion
        _queen = queen;
    }

    public void LifeTick()
    {
        _queen.LifeTick();
    }
}
