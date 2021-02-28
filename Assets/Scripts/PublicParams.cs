using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PublicParams", menuName = "runner/PublicParams", order = 0)]
public class PublicParams : ScriptableObject {
    public float maxPlaneSpeed = 10;
    public float currentPlaneSpeed = 0;
    public int ballRotationSpeed = 6;

    public int pointsForBig = 10;
    public int pointsForSmall = 2;

    public float ballScale = 0.2f;

    public float maxBallScale = 3.5f;
}
