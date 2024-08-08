using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Car", menuName ="Car/Stat")]
public class CarStat : ScriptableObject
{
    public string PlayerCarName;
    public float IdleRPM;
    public float HP;

    public Rigidbody PlayerRB;
}
