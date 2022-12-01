using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public LevelEnemySpawnMap spawnMap;
    private Transform _enemyTemplate;
    private Transform _triggerTemplate;

    private List<BoxCollider2D> _triggersList;

    private Transform _parent;

    private Transform _enemySprite;

    public RuntimeAnimatorController blasterAnimation;
    public RuntimeAnimatorController spitterAnimation;

    void Start()
    {
        _triggersList = new List<BoxCollider2D>();
        _parent = GameObject.Find("triggers").transform;
        
        _enemyTemplate = transform.Find("triggers/Templates/Enemy");
        _triggerTemplate = transform.Find("triggers/Templates/Trigger");
        int n = 0;
        foreach (EnemyWave enemyWave in spawnMap.EnemyWaves ) {
            // Debug.Log("Trigger point: x: " + enemyWave.xCoordTriggerPoint + " - y: " + enemyWave.yCoordTriggerPoint);
            genericButton trigger = new genericButton();
            
            
            GameObject _enemies = new GameObject($"enemies{n}");
            _enemies.SetActive(false);
            _enemies.transform.parent = _parent;
            _enemies.transform.position = _parent.position;
            Transform triggerTransform = Instantiate(_triggerTemplate, _parent, false).GetComponent<Transform>();
            triggerTransform.gameObject.tag = "EnemyWave";
            triggerTransform.gameObject.SetActive(true);
            triggerTransform.transform.name = $"triggerEnemy{n}";
            BoxCollider2D collider = triggerTransform.GetComponent<BoxCollider2D>();
            collider.size = new Vector2(enemyWave.sizeX, enemyWave.sizeY);
            collider.offset = new Vector2(enemyWave.xCoordTriggerPoint, enemyWave.yCoordTriggerPoint);

            foreach (Enemy enemy in enemyWave.enemiesList) {
                // Debug.Log("Enemy coordinate: x: " + enemy.xSpawnPoint + " - y: " + enemy.ySpawnPoint);
                
                Transform enemyTransform = Instantiate(_enemyTemplate, _enemies.transform, false).GetComponent<Transform>();
                SpriteRenderer sprite = enemyTransform.Find("Sprite").GetComponent<SpriteRenderer>();
                Animator animator = sprite.GetComponent<Animator>();
                
                enemyTransform.GetComponent<SpitterAttack>().entityDamage = enemy.damage;
                enemyTransform.GetComponent<SpitterAttack>().entityHealth = enemy.health;

                enemyTransform.gameObject.SetActive(true);
                if (enemy._enemyType == Enemy.EnemyType.Spitter) {
                    animator.runtimeAnimatorController = spitterAnimation;
                    enemyTransform.GetComponent<Pathfinding.AIPath>().enabled = true;
                }
                else if (enemy._enemyType == Enemy.EnemyType.Blaster) {
                    animator.runtimeAnimatorController = blasterAnimation;
                }
                enemyTransform.transform.localPosition = new Vector3((float)enemy.xSpawnPoint, (float)enemy.ySpawnPoint, 0);
                // enemy.sprite = sprite.sprite;
            }
            n++;
        }

    }

    
    
  
}
