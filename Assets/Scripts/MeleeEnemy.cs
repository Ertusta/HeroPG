using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MeleeEnemy : MonoBehaviour
{
    public Transform Player;

    NavMeshAgent agent;
    Animator anim;
   

    public UnityEngine.UI.Image HealthBar;

    public TMPro.TextMeshProUGUI MoneyText;


    public int Health = 100;

    public bool ýsLive = true;

    Vector3 position;
    void Start()
    {
        InvokeRepeating("Move", 1, 1f);
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        position = transform.position;

    }

    //Health




    private void Move()
    {
        if (10 > Vector3.Distance(Player.position, transform.position) && 3 < Vector3.Distance(Player.position, transform.position) && ýsLive)
        {
            agent.destination = Player.position;
            anim.SetInteger("State", 1);
        }
        else if (3 > Vector3.Distance(Player.position, transform.position) && ýsLive)
        {

            agent.destination = Player.position;
            anim.SetInteger("State", 2);

            Invoke("Attack", 0.4f);
        }
        else if (ýsLive)
        {
            anim.SetInteger("State", 0);
            agent.destination = position;
            Health = 100;

        }

    }

    public void Damage()
    {
        Invoke("Damager", 0.4f);

    }

    public void Attack()
    {

        float damage;

        if (7 - PlayerScript.Instance.ArmorLevel > 0)
        {
            damage = 7 - PlayerScript.Instance.ArmorLevel;
        }
        else
        {
            damage = 1;
        }

        PlayerScript.Instance.Health -= damage;
        HealthBar.fillAmount -= damage / PlayerScript.Instance.MaxHealth;

        PlayerScript.Instance.BloodAnimo();



        if (PlayerScript.Instance.Health <= 0)
        {
            PlayerScript.Instance.Death();
        }



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

            if (DialogueScript.Instance.warriorCounter > 0)
            {
                DialogueScript.Instance.warriorCounter--;
            }

            if (DialogueScript.Instance.enemyCounter > 0)
            {
                DialogueScript.Instance.enemyCounter--;
            }



            
        }
    }

}

