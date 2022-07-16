using UnityEngine;
using System.Collections;

public abstract class EnemyShot : MonoBehaviour
{
    internal Enemy parentEnemy;
    internal Transform playerTransform;
    protected virtual float SpeedModifier { get; }
    protected virtual void Awake()
    {
        playerTransform = FindObjectOfType<Skin>().transform;
        GetComponent<Rigidbody>().AddForce((playerTransform.position - transform.position) * SpeedModifier, ForceMode.Impulse);
        StartCoroutine(StartLifeTime());
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            ApplyDamageToPlayer(parentEnemy);
        }
        else
        {
            DoDestroyAction();
        }
    }

    protected virtual void ApplyDamageToPlayer(Enemy enemy)
    {
        if (enemy)
        {
            DoDamageAction(enemy);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected virtual void DoDestroyAction()
    {
        Destroy(this.gameObject);
    }

    protected virtual void DoDamageAction(Enemy enemy)
    {
        ChangePlayerHealthPoints(enemy.damage);
    }

    protected void ChangePlayerHealthPoints(float damage)
    {
        Enemy.OnApplyDamage?.Invoke(damage);
        Character.onHealthChanged?.Invoke();
    }
    protected virtual IEnumerator StartLifeTime()
    {
        yield return new WaitForSeconds(2);
        DoDestroyAction();
    }
}