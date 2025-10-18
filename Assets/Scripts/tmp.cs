using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tmp : MonoBehaviour
{
    [SerializeField]
    private Transform cube;
    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private Image image;
    [SerializeField]
    private Button btn;

    private Vector3 startPoint;
    private Tween tween;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = cube.position;
        image.enabled = false;
        btn.onClick.AddListener(() => { ButtonAction(!image.enabled); });
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void ButtonAction(bool state)
    {
        if (state)
        {
            tween = cube.DOMoveY(startPoint.y + 2, 1, false).SetLoops(-1, LoopType.Yoyo);

        }
        else
        {
            if(tween != null)
                tween.Kill();
            cube.position = startPoint;
        }

        image.enabled = state;
    }
}
