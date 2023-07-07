using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CircleManager : MonoBehaviour
{
    [SerializeField] private Transform _plane;

    [SerializeField] private Score _score;

    public void Initialize(Cylinder cylinderPrefab, ColorsProvider colorsProvider)
    {
        for (int i = 0; i < 6; i++)
        {
            var cylinder = Instantiate(cylinderPrefab, _plane.position, Quaternion.identity, _plane);

            var color = colorsProvider.GetColor();

            cylinder.Initialize(color);

            AddScore(color);
        }
    }

    public void Initialize(Sphere spherePrefab, ColorsProvider colorsProvider)
    {
        var cylinder = Instantiate(spherePrefab, _plane.position, Quaternion.identity, _plane);

        cylinder.Initialize(colorsProvider);
    }

    private void AddScore(Color color)
    {
        if (color == Color.red)
            _score.CylinderAppeared.Invoke('r', '+');
        if (color == Color.yellow)
            _score.CylinderAppeared.Invoke('y', '+');
        if (color == Color.green)
            _score.CylinderAppeared.Invoke('g', '+');
    }
}