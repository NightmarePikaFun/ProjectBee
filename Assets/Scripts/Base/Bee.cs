using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee
{
    private Color _color;
    private Genetics _gens;
    private float _health = 20;
    private float _production = 20;
    private float _lifeTime = 20;
    private bool _isQueen = false;

    public Genetics Gens { get { return _gens; } }
    public float Health { get { return _health; } }
    public float Production { get { return _production; } }
    public float LifeTime { get { return _lifeTime; } }
    public Color BeeColor { get { return _color; } }
    public bool IsQueen { get { return _isQueen; } }
    public Bee(Genetics gens, Color color, bool isQueen = false)
    {
        _gens = gens;
        _isQueen = isQueen;
        _color = color;
        CalcStats();
    }

    public Bee(BeeQueen queen, bool isQueen = false)
    {
        _gens = queen.Gens;
        _health = queen.Health;
        _production = queen.Production;
        _lifeTime = queen.LifeTime;
        _isQueen = isQueen;
        _color = queen.Bee.BeeColor;
    }

    private void CalcStats()
    {

    }

    public void LifeTick()
    {
        _health--;
    }
}
