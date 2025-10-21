using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeQueen
{
    public Bee _queen;

    public Genetics Gens { get { return _queen.Gens; } }
    public float Health { get { return _queen.Health; } }
    public float Production { get { return _queen.Production; } }
    public float LiveTime { get { return _queen.LiveTime; } }

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
