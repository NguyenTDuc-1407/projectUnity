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
    public Transform target;
    Path path;
    [SerializeField]float moveSpeed;

    [SerializeField]float nextWpDis;


    Coroutine move;
    void Start()
    {
        nowHpEnemy = maxHpEnemy;
        healthBar.hpEnemys(nowHpEnemy, maxHpEnemy);

        target = FindObjectOfType<player>().gameObject.transform;
        caculatePath();
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
        if (seeker.IsDone())
        {
            seeker.StartPath(transform.position, target.position, OnpathCallBack);

        }
    }
    void OnpathCallBack(Path p)
    {
        if (p.error)
        {
            return;
            path = p;
        }

    }
    void moveTager(){
        if (move!=null)
        {
            StopCoroutine(move);
        }
        move = StartCoroutine(moveTagerCoroutine());
    }
    IEnumerator moveTagerCoroutine(){
        int currentWp = 0;
        while (currentWp<path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWp]-(Vector2)transform.position).normalized;
            Vector3 force = direction * moveSpeed*Time.deltaTime;
            transform.position += force;

            float dis = Vector2.Distance(transform.position,path.vectorPath[currentWp]);
            if (dis<nextWpDis)
            {
                currentWp++;
            }
            yield return null;
            // new WaitForSeconds(2f)

        }
    }
    void Update()
    {

    }
}
