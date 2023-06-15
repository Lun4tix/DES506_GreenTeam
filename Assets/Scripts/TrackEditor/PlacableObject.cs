using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacableObject : MonoBehaviour
{
    private bool canScale = true;
    private float scaleSpeed = 1.0f;

    // scale presets
    private float multiLarge = 1.1f;
    private float multiSmall = 0.8f;
    private Vector3 scaleSmall;
    private Vector3 scaleLarge;
    private Vector3 scaleNext;
    private Vector3 scaleOriginal;

    private void Awake()
    {
        scaleOriginal = transform.localScale;
        scaleSmall = scaleOriginal * multiSmall;
        scaleLarge = scaleOriginal * multiLarge;
        scaleNext = scaleLarge;
    }

    void FixedUpdate()
    {
       UpdateScale();
    }

    internal virtual void UpdateScale()
    {
        if (canScale == false)
            return;

        transform.localScale = Vector3.MoveTowards(transform.localScale, scaleNext, scaleSpeed * Time.deltaTime);

        if (transform.localScale == scaleLarge)
            scaleNext = scaleSmall;
        if (transform.localScale == scaleSmall)
            scaleNext = scaleLarge;
    }

    internal void StopScaling()
    {
        canScale = false;
        transform.localScale = scaleOriginal;
    }
}