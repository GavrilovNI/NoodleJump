using System;
using UnityEngine;

public class GenerationResult
{
    public float GeneratedHeight { get; private set; }

    public GenerationResult(float generatedHeight)
    {
        GeneratedHeight = generatedHeight;
    }
}
