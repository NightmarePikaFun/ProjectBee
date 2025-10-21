using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    List<Hive> hives;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private IEnumerator HiveTiker()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(8);
            foreach (var hive in hives)
            {
                hive.Production();
                hive.LifeCycle();
            }
            //Tick 
        }
    }
}
