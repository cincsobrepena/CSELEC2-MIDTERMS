using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public Transform player;        
    public float speed = 3.0f;      
    public float stoppingDistance = 1.5f; 

    private bool gameOver = false;  

    public float disableTime = 5f;  

    private bool isDisabled = false;

    public EnemyPool enemyPool;     

    void Update()
    {
        if (!isDisabled)
        {
            if (!gameOver)
            {
                ChasePlayer();

                /*if (Vector3.Distance(transform.position, player.position) <= stoppingDistance)
                {
                    GameOver();
                }*/
            }
        }

    }

    void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over! The enemy has caught the player.");
    }

    public IEnumerator DisableTemporarily()
    {
        Debug.Log("hit");
        isDisabled = true; 
        gameObject.SetActive(false);

        yield return new WaitForSeconds(disableTime);

        gameObject.SetActive(true);
        enemyPool.ReturnToPool(gameObject); 
        isDisabled = false;
    }
}
