using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateEnemy : MonoBehaviour
{
    private EnemyController enemyController_ref;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetEnemy(EnemyController enemycontroller)
    {
        enemyController_ref = enemycontroller;

    }
    public void DeactivateEnemy_()
    {
        enemyController_ref.DeactivateCurrentEnemy();
    }
}
