using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyController
{

    

    // Start is called before the first frame update


    public static void EnemyAction(GameObject enemyToBeControlled)
    {
      
        if (enemyToBeControlled.GetComponent<Enemy>().followsPlayer)
        {
            if(enemyToBeControlled.GetComponent<Enemy>().distanceFromPlayer < enemyToBeControlled.GetComponent<Enemy>().lineOfSight && enemyToBeControlled.GetComponent<Enemy>().distanceFromPlayer > enemyToBeControlled.GetComponent<Enemy>().firingRange)
            {
                enemyToBeControlled.transform.position = Vector2.MoveTowards(enemyToBeControlled.transform.position, enemyToBeControlled.GetComponent<Enemy>().player.transform.position, enemyToBeControlled.GetComponent<Enemy>().moveSpeed * Time.deltaTime);
            }
        }
        //firing
        if (enemyToBeControlled.GetComponent<Enemy>().distanceFromPlayer < enemyToBeControlled.GetComponent<Enemy>().firingRange && enemyToBeControlled.GetComponent<Enemy>().nextFire < 0)
        {
            BulletScript.InvokeRepeat(enemyToBeControlled, enemyToBeControlled.GetComponent<Enemy>().bulletType, enemyToBeControlled.GetComponent<Enemy>().bulParent);
            
            enemyToBeControlled.GetComponent<Enemy>().nextFire = enemyToBeControlled.GetComponent<Enemy>().fireRate;
        }
        //else
        //{
        //    //BulletScript.CancelInvokeRepeat();
        //}

    }


}
