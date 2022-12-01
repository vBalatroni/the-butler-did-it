using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelEnemySpawnMap", menuName = "Game_Jam_Novembre_2022/Level", order = 2)]
public class LevelEnemySpawnMap : ScriptableObject {

    public List<EnemyWave> EnemyWaves;
}