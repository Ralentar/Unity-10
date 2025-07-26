using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float SegmentationThreshold { get; private set; } = 100;

    public event Action<Cube> Click = (cube) => { };

    public void SetSegmentationThreshold(float chance)
    {
        SegmentationThreshold = chance;
    }

    private void Awake() => Recolor();

    private void OnMouseDown() => Click.Invoke(this);

    private void Recolor()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }
}