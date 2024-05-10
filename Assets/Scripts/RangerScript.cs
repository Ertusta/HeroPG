using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RangerScript : MonoBehaviour
{
    public Transform Player;

    NavMeshAgent agent;
    Animator anim;

    public UnityEngine.UI.Image HealthBar;

    public TMPro.TextMeshProUGUI MoneyText;


    public int Health = 75;

    public bool ýsLive = true;

    public GameObject Ball;

    Vector3 position;
    void Start()
    {
        InvokeRepeating("Move", 1, 1f);
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        position = transform.position;
    }






    private void Move()
    {
        if (15 > Vector3.Distance(Player.position, transform.position) && 10 < Vector3.Distance(Player.position, transform.position) && ýsLive)
        {
            agent.destination = Player.position;
            anim.SetInteger("State", 1);
            
        }
        else if (10 > Vector3.Distance(Player.position, transform.position) && ýsLive)
        {
            anim.SetInteger("State", 2);


            agent.destination = transform.position;


    


            Invoke("Attack", 0.4f);
            
        }
        else if(ýsLive)
        {
            
            anim.SetInteger("State", 0);
            agent.destination = position;
            Health = 75;

        }

    }

    public void Damage()
    {

        Invoke("Damager", 0.4f);
    }


    private void Attack()
    {
        Instantiate(Ball, transform.position + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0));
    }

    private void Damager()
    {

        Health -= PlayerScript.Instance.Damage + 20 * PlayerScript.Instance.BladeLevel;


        if (Health < 0)
        {
            Health = 100;
            gameObject.SetActive(false);
            ýsLive = false;
            PlayerScript.Instance.Money += 10;
            MoneyText.text = PlayerScript.Instance.Money.ToString();
            anim.SetInteger("State", 0);
            PlayerScript.Instance.Exp += 10;

            if (PlayerScript.Instance.Exp == 100)
            {
                PlayerScript.Instance.Exp = 0;
                PlayerScript.Instance.SkillPoint += 1;

            }

            if (DialogueScript.Instance.rangerCounter > 0)
            {
                DialogueScript.Instance.rangerCounter--;
            }

            if (DialogueScript.Instance.enemyCounter > 0)
            {
                DialogueScript.Instance.enemyCounter--;
            }



        }

    }
}