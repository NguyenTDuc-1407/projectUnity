using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemy : MonoBehaviour
{
    [SerializeField] int maxHpEnemy;
    [SerializeField] int nowHpEnemy;
    [SerializeField] health healthBar;
    public Seeker seeker;
    Path path;
    [SerializeField] float moveSpeed;

    [SerializeField] float nextWpDis;

   [SerializeField] bool roaming = true;


    Coroutine move;
    void Start()
    {
        nowHpEnemy = maxHpEnemy;
        healthBar.hpEnemys(nowHpEnemy, maxHpEnemy);

        InvokeRepeating("caculatePath",0f,0.5f);
    }
    public void takeDamageEnemy(int damage)
    {
        nowHpEnemy = nowHpEnemy - damage;
        healthBar.hpEnemys(nowHpEnemy, maxHpEnemy);
        if (nowHpEnemy < 0)
        {

        }

    }
    void caculatePath()
    {
        Vector2 target = findTarget();
        if (seeker.IsDone())
        {
            seeker.StartPath(transform.position, target, OnpathCallBack);
        }
    }
    Vector2 findTarget(){
        Vector3 playPos = FindObjectOfType<player>().transform.position;
        if (roaming == true)
        {
            return (Vector2)playPos + (Random.Range(10f,50f) * new Vector2(Random.Range(-1,1),Random.Range(-1,1)).normalized);
            
        }else
        {
            return playPos;
        }
    }
    void OnpathCallBack(Path p)
    {
        if (p.error)
        {
            return;
        }
        path = p;
        moveTager();

    }
    void moveTager()
    {
        if (move != null)
        {
            StopCoroutine(move);
        }
        move = StartCoroutine(moveTagerCoroutine());
    }
    IEnumerator moveTagerCoroutine()
    {
        int currentWp = 0;
        while (currentWp < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWp] - (Vector2)transform.position).normalized;
            Vector3 force = direction * moveSpeed * Time.deltaTime;
            transform.position += force;

            float dis = Vector2.Distance(transform.position, path.vectorPath[currentWp]);
            if (dis < nextWpDis)
            {
                currentWp++;
            }
            yield return null;
        }
    }
    void Update()
    {

    }
}
