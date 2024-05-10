using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    NavMeshAgent agent;


    Animator anim;
    public Animator BloodAnim;

    Vector3 destination;

    public GameObject Panel;

    public bool canMove = false;
    public bool canHit = true;

    public static PlayerScript Instance;

    public float Health = 100;
    public float MaxHealth = 100;

    public int Damage = 20;

    public int Money = 0;
    public int Potion = 0;

    public int BladeLevel = 1;
    public int ArmorLevel = 1;

    public UnityEngine.UI.Image HealthBar;
    public TMPro.TextMeshProUGUI PotionText;
    public TMPro.TextMeshProUGUI MoneyText;


    public float Exp;
    public int SkillPoint;
    public int DamagePoint;
    public int SpeedPoint;
    public int HealthPoint;

    public GameObject[] Enemies;

    public AudioSource Maim;
    public AudioSource Enemy;
    public AudioSource Deatho;
    public AudioSource Yes;

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();


        anim = GetComponent<Animator>();
        Instance = this;

        Maim.Play();

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canMove == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {





                if (hit.collider.gameObject.tag == "Terrain" && canHit)
                {
                    destination = hit.point;
                    agent.destination = destination;
                    anim.SetInteger("State", 1);
                }
                else if (hit.collider.gameObject.tag == "Enemy")
                {


                    if (3 > Vector3.Distance(hit.point, transform.position) && canHit)
                    {
                        MeleeEnemy melee = hit.collider.gameObject.GetComponent<MeleeEnemy>();
                        melee.Damage();

                        anim.SetInteger("State", 2);
                        Invoke("Refresh", 1);
                        canHit = false;

                        destination = hit.point;
                        agent.destination = destination;
                    }
                    else if (canHit)
                    {
                        destination = hit.point;
                        agent.destination = destination;
                        anim.SetInteger("State", 1);
                    }


                }
                else if (hit.collider.gameObject.tag == "Ranger")
                {


                    if (3 > Vector3.Distance(hit.point, transform.position) && canHit)
                    {
                        RangerScript ranger = hit.collider.gameObject.GetComponent<RangerScript>();
                        ranger.Damage();

                        anim.SetInteger("State", 2);
                        Invoke("Refresh", 1);
                        canHit = false;

                        destination = hit.point;
                        agent.destination = destination;
                    }
                    else if (canHit)
                    {
                        destination = hit.point;
                        agent.destination = destination;
                        anim.SetInteger("State", 1);
                    }


                }













                else if (hit.collider.gameObject.tag == "RedPortal")
                {
                    destination = hit.point;
                    agent.destination = destination;
                    anim.SetInteger("State", 1);

                    if (3 > Vector3.Distance(hit.point, transform.position))
                    {


                        agent.enabled = false;
                        gameObject.transform.position = new Vector3(1900, 0, 450);
                        agent.enabled = true;
                        anim.SetInteger("State", 0);

                        Maim.Stop();
                        Enemy.Play();

                    }

                }



                else if (hit.collider.gameObject.tag == "GreenPortal")
                {
                    destination = hit.point;
                    agent.destination = destination;
                    anim.SetInteger("State", 1);

                    if (3 > Vector3.Distance(hit.point, transform.position))
                    {

                        Yes.Play();
                        Enemy.Stop();
                       Maim.Play();

                        agent.enabled = false;
                        gameObject.transform.position = new Vector3(475, 0, 475);
                        agent.enabled = true;
                        anim.SetInteger("State", 0);


                        DialogueScript.Instance.heal = 2;
                        DialogueScript.Instance.seller = 2;
                        DialogueScript.Instance.smith = 2;
                        DialogueScript.Instance.guard = 3;



                        if (DialogueScript.Instance.execute != 11)
                        {
                            DialogueScript.Instance.execute = 10;
                        }



                        for (int i = 15; i < 30; i++)
                        {
                            Enemies[i].SetActive(true);
                            Enemies[i].GetComponent<MeleeEnemy>().ýsLive = true;
                        }

                        for (int i = 0; i < 15; i++)
                        {
                            Enemies[i].SetActive(true);
                            Enemies[i].GetComponent<RangerScript>().ýsLive = true;
                        }
                    }


                }





                if (hit.collider.gameObject.tag == "Executer")
                {
                    DialogueScript.Instance.Executer();

                }
                else if (hit.collider.gameObject.tag == "Smith")
                {
                    DialogueScript.Instance.Smith();

                }
                else if (hit.collider.gameObject.tag == "Healer")
                {
                    DialogueScript.Instance.Healer();

                }
                else if (hit.collider.gameObject.tag == "Guard")
                {
                    DialogueScript.Instance.Guard();

                }
                else if (hit.collider.gameObject.tag == "Seller")
                {
                    DialogueScript.Instance.Seller();

                }

            }
        }

        if (0.4f > Vector3.Distance(destination, transform.position) && canHit)
        {
            anim.SetInteger("State", 0);
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.F))
        {
            if (Potion > 0)
            {
                Potion--;
                Health = MaxHealth;
                HealthBar.fillAmount = 1;
                PotionText.text = Potion.ToString();

            }



        }









    }

    void Refresh()
    {
        anim.SetInteger("State", 0);
        canHit = true;
    }

    public void Death()
    {
        BloodAnim.SetInteger("State", 2);
        Invoke("AnimReset", 2);
        agent.enabled = false;
        gameObject.transform.position = new Vector3(495, 0, 480);
        agent.enabled = true;

        Enemy.Stop();
        Deatho.Play();
        Maim.Play();

        Health = 100;
        HealthBar.fillAmount = 100;

        Money -= 10;
        MoneyText.text = Money.ToString();

        DialogueScript.Instance.heal = 2;
        DialogueScript.Instance.seller = 2;
        DialogueScript.Instance.smith = 2;
        DialogueScript.Instance.guard = 3;

        anim.SetInteger("State", 0);


        DialogueScript.Instance.Healer();


        if (DialogueScript.Instance.execute == 2)
        {
            DialogueScript.Instance.execute = 3;
        }


        for (int i = 15; i < 30; i++)
        {
            Enemies[i].SetActive(true);
            Enemies[i].GetComponent<MeleeEnemy>().ýsLive = true;
        }

        for (int i = 0; i < 15; i++)
        {
            Enemies[i].SetActive(true);
            Enemies[i].GetComponent<RangerScript>().ýsLive = true;
        }
    }


    public void Hearth()
    {
        if (SkillPoint >= 1)
        {
            SkillPoint--;
            HealthPoint++;

            MaxHealth += 10;
            Health = MaxHealth;
            HealthBar.fillAmount = 1;

            DialogueScript.Instance.skill = 0;
            DialogueScript.Instance.SkillPanel();

        }
    }

    public void Arm()
    {
        if (SkillPoint >= 1)
        {
            SkillPoint--;
            DamagePoint++;
            Damage += 20;

            DialogueScript.Instance.skill = 0;
            DialogueScript.Instance.SkillPanel();
        }
    }

    public void Speed()
    {
        if (SkillPoint >= 1)
        {

            SkillPoint--;
            SpeedPoint++;

            agent.speed++;

            DialogueScript.Instance.skill = 0;
            DialogueScript.Instance.SkillPanel();
        }
    }

    public void HealthRefresh()
    {
        HealthBar.fillAmount = Health / MaxHealth;
    }

    public void AnimReset()
    {
        BloodAnim.SetInteger("State", 0);
    }

    public void BloodAnimo()
    {
        BloodAnim.SetInteger("State", 1);
        Invoke("AnimReset", 0.5f);

    }

    public void Save()
    {
        PlayerPrefs.SetFloat("maxHealth", MaxHealth);
        PlayerPrefs.SetInt("damage", Damage);
        PlayerPrefs.SetInt("money", Money);
        PlayerPrefs.SetInt("potion", Potion);
        PlayerPrefs.SetInt("bladeLevel", BladeLevel);
        PlayerPrefs.SetInt("armorLevel", ArmorLevel);
        PlayerPrefs.SetFloat("exp", Exp);
        PlayerPrefs.SetInt("skillPoint", SkillPoint);
        PlayerPrefs.SetInt("damagePoint", DamagePoint);
        PlayerPrefs.SetInt("speedPoint", SpeedPoint);
        PlayerPrefs.SetInt("healthPoint", HealthPoint);
    }

    public void Load()
    {
        MaxHealth = PlayerPrefs.GetFloat("maxHealth", MaxHealth);
        Damage = PlayerPrefs.GetInt("damage", Damage);
        Money = PlayerPrefs.GetInt("money", Money);
        Potion = PlayerPrefs.GetInt("potion", Potion);
        BladeLevel = PlayerPrefs.GetInt("bladeLevel", BladeLevel);
        ArmorLevel = PlayerPrefs.GetInt("armorLevel", ArmorLevel);
        Exp = PlayerPrefs.GetFloat("exp", Exp);
        SkillPoint = PlayerPrefs.GetInt("skillPoint", SkillPoint);
        DamagePoint = PlayerPrefs.GetInt("damagePoint", DamagePoint);
        SpeedPoint = PlayerPrefs.GetInt("speedPoint", SpeedPoint);
        HealthPoint = PlayerPrefs.GetInt("healthPoint", HealthPoint);

        MoneyText.text = Money.ToString();
        PotionText.text = Potion.ToString();


    }





}

