using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyWave", menuName = "Game_Jam_Novembre_2022/Enemy/Waves", order = 1)]
public class EnemyWave : ScriptableObject {

    public List<Enemy> enemiesList;
    public int xCoordTriggerPoint;
    public int yCoordTriggerPoint;

    public int sizeX;
    public int sizeY;
}