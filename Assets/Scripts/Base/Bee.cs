using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee
{
    private Genetics _gens;
    private float _health = 20;
    private float _production = 20;
    private float _liveTime = 20;
    private bool _isQueen = false;

    public Genetics Gens { get { return _gens; } }
    public float Health { get { return _health; } }
    public float Production { get { return _production; } }
    public float LiveTime { get { return _liveTime; } } 

    public Bee(Genetics gens, bool isQueen = false)
    {
        _gens = gens;
        _isQueen = isQueen;
    }
}
