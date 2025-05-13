using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightTwinkling : MonoBehaviour
{
    private Light2D _light;

    private void Awake()
    {
        _light = GetComponent<Light2D>();
    }

    private IEnumerator Twinkling()
    {
        yield return new WaitForSeconds(0.3f);
    }
}
