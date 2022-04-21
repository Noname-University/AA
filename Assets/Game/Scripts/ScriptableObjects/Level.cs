
using UnityEngine;

[CreateAssetMenu(menuName = "Level", fileName = "newLevel")]
public class Level : ScriptableObject
{
    public float mainObjectSpeed;
    public int arrowCount;
    public int[] obstacleDegrees;
    public float timer;

}
