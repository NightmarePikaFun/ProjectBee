using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BeeElementView : MonoBehaviour
{
    [SerializeField]
    private Button selectButton;
    [SerializeField]
    private Image beeImage;
    [SerializeField]
    private TMP_Text textHealth;
    [SerializeField]
    private TMP_Text textProduction;
    [SerializeField]
    private TMP_Text textLife;

    public void Construct(Bee bee, Action action)
    {
        selectButton.onClick.AddListener(() => { action?.Invoke(); });


        textHealth.text = bee.Gens.HealthMultplayer.ToString();
        textProduction.text = bee.Gens.ProductionMultiplayer.ToString();
        textLife.text = bee.Gens.LifeTimeMultiplayer.ToString();
    }
    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
