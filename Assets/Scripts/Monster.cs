using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Monster : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    [SerializeField] EnemyScriptableObject enemyScriptable;
    public Slider slider;
    public int hp = 100;
    int damage, fireTime;
    float freezeTime;
    float attackDelay = 2f, attackRange;
    bool attacked, inAttackRange, onFire, onFreeze;
    Animator animator;
    Drop drop;
    public ParticleSystem fireEffect,freezeEffect;
    public SpawnManager spawn;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        drop = GetComponent<Drop>();
        animator = GetComponent<Animator>();
        spawn = GameObject.Find("Spawn").GetComponent<SpawnManager>();
        AgentConfig();
        if (spawn.boostCount > 0)
            hp = (int)(enemyScriptable.health * spawn.boost);
        else
            hp = enemyScriptable.health;
        damage = enemyScriptable.damage;
        this.slider.minValue = 0;
        this.slider.maxValue= hp;
        this.slider.value = slider.maxValue;
        attackRange = enemyScriptable.radius * 2;
        animator.speed = enemyScriptable.animSpeed;
        animator.Rebind();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn.start)
        {
            if (hp <= 0f)
            {
                Dead();
            }
            else
            {
                inAttackRange = Vector3.Distance(transform.position, player.position) < attackRange;
                //Debug.Log(inAttackRange);
                if (inAttackRange)
                {
                    agent.SetDestination(transform.position);
                    transform.LookAt(new Vector3(player.position.x, player.position.y - 1, player.position.z));
                    if (animator != null)
                        animator.SetBool("Move", false);
                    Attack();
                }
                else
                {
                    Move();
                }
            }
        }
        else
            agent.SetDestination(transform.position);

        OnFreeze();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hp -= 10;
            this.slider.value = hp;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeFire(5);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeFreeze(5);
        }
    }

    void Move()
    {
        //Debug.Log("move");
        agent.SetDestination(player.position);
        if (animator != null)
        {
            animator.SetBool("Move", true);
        }
    }
    void Attack()
    {       
        if (!attacked)
        {
            if (animator != null)
                animator.SetTrigger("Attack");  
            Debug.Log(this.name + "Hit");
            //player.GetComponent<Player>().TakeDamage(damage);
            attacked = true;
            Invoke("ResetAttack", attackDelay);
        }
        else
        {
            if (animator != null)
              animator.SetBool("Move", false);
        }
    }

    void ResetAttack()
    {
        attacked = false;
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        this.slider.value = hp;
    }

    void Dead()
    {
        if (this.gameObject.name.Equals("Boss"))
        {
            this.gameObject.SetActive(false);
            this.Start();
            drop.DropLoot();
        }
        else
        {
            Destroy(this.gameObject);
            drop.DropLoot();
        }
        
    }

    void AgentConfig()
    {
        agent.baseOffset = enemyScriptable.baseOffset;
        agent.speed = enemyScriptable.speed;
        agent.angularSpeed = enemyScriptable.angularSpeed;
        agent.acceleration = enemyScriptable.acceleration;
        agent.stoppingDistance = enemyScriptable.stoppingDistance;
        agent.radius = enemyScriptable.radius;
        agent.height = enemyScriptable.height;    
        agent.obstacleAvoidanceType = enemyScriptable.obstacleAvoidance;
        agent.avoidancePriority = enemyScriptable.avoidancePriority;
        agent.areaMask = enemyScriptable.areaMask;
        //agent.velocity = enemyScriptable.velocity;
    }

    public void TakeFire(int dmg)
    {
        hp -= dmg;
        this.slider.value = hp;
        if (!onFire)
        {
            fireTime = 0;
            InvokeRepeating("OnFire", 1f, 1f);
            fireEffect.Play();
            onFire= true;
        }
    }

    void OnFire()
    {
        fireTime++;
        hp -= 25;
        this.slider.value = hp;
        if (fireTime == 3 || hp <= 0)
        {
            Debug.Log("stop");
            CancelInvoke("OnFire");
            fireEffect.Stop();
            onFire= false;
        }
    }

    public void TakeFreeze(int dmg)
    {
        hp -= dmg;
        this.slider.value = hp;
        if (!onFreeze)
        {
            freezeEffect.Play();
            onFreeze = true;
            freezeTime = 0;
        }
    }

    void OnFreeze()
    {
        if (onFreeze)
        {
            freezeTime += Time.deltaTime;           
            if(freezeTime < 5)
            {              
                agent.speed = enemyScriptable.speed / 2;               
            }
            else
            {
                freezeEffect.Stop();
                agent.speed = enemyScriptable.speed;
                onFreeze = false;
            }
        }       
    }
}
