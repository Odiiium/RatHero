using UnityEngine;
using UnityEngine.Events;

public class Character : Unit
{
    [SerializeField] MobileController mobileJoystick;

    internal static bool isGrounded, isSlowed;

    public static UnityAction onHealthChanged;
    public static UnityAction onManaChanged;
    internal float defence { get; set; }
    internal float attackSpeed { get; set; }
    internal float criticalChance { get; set; }

    private void Awake()
    {
        PauseMenu.isGame = true;
        isGrounded = true;
        SetPlayerStats();
        Enemy.OnApplyDamage += GetDamage;
    }

    private void OnDisable()
    {
        Enemy.OnApplyDamage -= GetDamage;
    }

    private void Update()
    {
        if (PauseMenu.isGame)
        {
            PostGameMenu.timeAlived += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Run();
    }


    private void OnTriggerEnter(Collider other)
    {
        DetectBuffTrigger(other);
    }

    private void DetectBuffTrigger(Collider other)
    {
        if (BuffUI.currentBuffCount < 4 && other.gameObject.TryGetComponent(out Buff buff))
        {
            buff.DoBuff();
            (soundsEffects as CharacterSFX).OnGetBonusMakeSound(0.4f);
            if (buff is PassiveBuff)
            {
                buff.ShowBuffUI(other.name.Replace("(Clone)", ""));
                StartCoroutine((buff as PassiveBuff).WaitForBuffEnds());
            }
            buff.buffSpawnPoint.DoSpawn();
            Destroy(buff.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 6)
        {
            isGrounded = true;
        }
    }

    private void SetPlayerStats()
    {
        attackSpeed = PlayerStatsInitializer.InitializedPlayerAttackSpeed();
        speed = PlayerStatsInitializer.InitializedPlayerSpeed() / 60;
        damage = PlayerStatsInitializer.InitializedPlayerDamage();
        criticalChance = PlayerStatsInitializer.InitializedPlayerCriticalChance();
        defence = PlayerStatsInitializer.InitializedPlayerDefence();

        currentSpeed = speed;
        rotateSpeed = 1.7f;
    }

    protected override void Run()
    {
        if (mobileJoystick.yAxis() != 0 && isGrounded && PauseMenu.isGame)
        {
            rigidBody.velocity = mobileJoystick.yAxis() * transform.forward * currentSpeed;
            transform.Rotate(0, mobileJoystick.xAxis() * rotateSpeed, 0);
        }
            
    }

    protected override void GetDamage(float enemyDamage)
    {
        soundsEffects.OnGetDamagedMakeSound(1, 0.6f);
        HealthBar.healthPoints -= Mathf.Round(enemyDamage * blockModifier());
        onHealthChanged?.Invoke();
    }

    internal float Crit()
    {
        int randomInt = Random.Range(0, 100);
        if (randomInt < criticalChance)
        {
            return damage * 1.5f;
        }
        else return 0;
    }

    private float blockModifier()
    {
        return 1 - defence / 400;
    }
}
