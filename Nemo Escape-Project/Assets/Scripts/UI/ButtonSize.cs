using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HarmonicOscillation))]
[RequireComponent(typeof(RectTransform))]
public class ButtonSize : MonoBehaviour
{
    RectTransform button;
    Vector3 initLocalScale;
    HarmonicOscillation o;
    void Start()
    {
        button = GetComponent<RectTransform>();
        o = GetComponent<HarmonicOscillation>();
        initLocalScale = button.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        button.transform.localScale = initLocalScale + new Vector3(o.x, o.x, 0);
    }
}
