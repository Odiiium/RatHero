using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShot : MonoBehaviour
{
    protected Rigidbody rigidBody;
    protected Character player;

    protected float speed;

    private void Awake()
    {
        player = FindObjectOfType<Character>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            DoEnemyCollision(collision, enemy);
            Destroy(gameObject);
        }
        else Destroy(gameObject); 
    }

    protected virtual void DoEnemyCollision(Collision collision, Enemy enemy)
    {
        
    }

    protected void MoveToDirection()
    {
        Vector3 moveDirection = new Vector3(transform.position.x - player.transform.position.x, 0, transform.position.z - player.transform.position.z);
        rigidBody.AddForce(moveDirection * speed, ForceMode.Impulse);
    }

}
