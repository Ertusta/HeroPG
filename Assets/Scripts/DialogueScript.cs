using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    public GameObject Panel;
    public GameObject SmithPanel;
    public GameObject SkillTable;
    public GameObject Menu;

    public TMPro.TextMeshProUGUI Text;
    public TMPro.TextMeshProUGUI Name;

    public TMPro.TextMeshProUGUI ExecuteText;
    public TMPro.TextMeshProUGUI SmithText;
    public TMPro.TextMeshProUGUI HealerText;
    public TMPro.TextMeshProUGUI GuardText;
    public TMPro.TextMeshProUGUI SellerText;

    public TMPro.TextMeshProUGUI ArmorMoney;
    public TMPro.TextMeshProUGUI BladeMoney;
    public TMPro.TextMeshProUGUI BladeLevel;
    public TMPro.TextMeshProUGUI ArmorLevel;

    public TMPro.TextMeshProUGUI SmithMoney;

    public GameObject ExecuteButton;
    public GameObject SmithButton;
    public GameObject HealerButton;
    public GameObject GuardButton;
    public GameObject SellerButton;
    public GameObject BadButton;

    public int execute;
    public int smith;
    public int heal;
    public int guard;
    public int seller;

    public GameObject RedPortal;

    public GameObject Player;

    //health

    public static DialogueScript Instance;
    public TMPro.TextMeshProUGUI MoneyText;
    public UnityEngine.UI.Image HealthBar;
    public TMPro.TextMeshProUGUI PotionText;

    public Image SkillBar;
    public TMPro.TextMeshProUGUI SkillText;
    public TMPro.TextMeshProUGUI ArmText;
    public TMPro.TextMeshProUGUI HealthText;
    public TMPro.TextMeshProUGUI SpeedText;

    public int warriorCounter=-75;
    public int rangerCounter=-75;
    public int enemyCounter = -75;

    int executeram = 0;

    public void Start()
    {


        Instance = this;
    }
    //Skill
    public void Executer()
    {
          
        
        PlayerScript.Instance.canMove = false;
        Name.text = "Executer:";

        Panel.SetActive(true);
        ExecuteButton.SetActive(true);

        if (execute == 0)
        {
            Text.text = "Go north and talk to the guard ";
            ExecuteText.text = "Oki Doki";
            execute = 1;


        }
        else if (execute == 1)
        {
            ExecuteButton.SetActive(false);
            Panel.SetActive(false);
            execute = 2;
            PlayerScript.Instance.canMove = true;

        }
        else if (execute == 2)
        {

            Text.text = "I told you go";
            ExecuteText.text = "uhh";
            execute = 1;
        }
        else if (execute == 3)
        {
            
            executeram = execute;
            execute = 75;

            if(warriorCounter == -75)
            {
                warriorCounter = 10;
            }


            Text.text = "Kill "+ warriorCounter + " warrior.There will be reward";
            ExecuteText.text = "oke";



            if (warriorCounter == 0)
            {
                Text.text = "Good job you deserve it now kill 25 ranger";
                ExecuteText.text = "oke";
                PlayerScript.Instance.Money += 250;
                MoneyText.text = PlayerScript.Instance.Money.ToString();
                execute = 4;


            }

        }
        else if(execute==4)
        {
            
            executeram = execute;
            execute = 75;

            if (rangerCounter == -75)
            {
                rangerCounter = 25;
            }

            Text.text = "Kill "+ rangerCounter +" ranger.There will be reward";
            ExecuteText.text = "oke";

            if (rangerCounter == 0)
            {
                Text.text = "Good job you deserve it now kill 100 enemy";
                ExecuteText.text = "oke";
                PlayerScript.Instance.Money += 500;
                MoneyText.text = PlayerScript.Instance.Money.ToString();
                execute = 5;


            }
        }
        else if (execute == 5)
        {
            
            executeram = execute;
            execute = 75;

            if (enemyCounter == -75)
            {
                enemyCounter = 100;
            }

            Text.text = "Kill "+ enemyCounter +" enemy.There will be reward";
            ExecuteText.text = "oke";

            if (enemyCounter == 0)
            {
                Text.text = "Good job you deserve it now find green portal";
                ExecuteText.text = "oke";
                PlayerScript.Instance.Money += 1000;
                MoneyText.text = PlayerScript.Instance.Money.ToString();
                execute=9;
                


            }
        }
        else if(execute==9)
        {
            Text.text = "Good job you deserve it now find green portal";
            ExecuteText.text = "oke";



        }
        else if (execute == 10)
        {
            Text.text = "You really did it, you are the true hero";
            ExecuteText.text = "ehm";
            PlayerScript.Instance.Money += 2500;
            MoneyText.text = PlayerScript.Instance.Money.ToString();
            execute = 11;
        }
        else if (execute == 11)
        {
            Text.text = "You really did it, you are the true hero";
            ExecuteText.text = "ehm";
           executeram=execute;
            execute = 75;
        }
        else if (execute == 75)
        {
            ExecuteButton.SetActive(false);
            Panel.SetActive(false);
            execute = executeram;
            PlayerScript.Instance.canMove = true;
        }




    }

    public void Smith()
    {
        Name.text = "Smith:";
        PlayerScript.Instance.canMove = false;


        if (smith == 0)
        {
            Panel.SetActive(true);
            SmithButton.SetActive(true);

            Text.text = "Firstly prove your worth";
            SmithText.text = "aww";
            smith = 1;
        }
        else if (smith == 1)
        {
            SmithButton.SetActive(false);
            Panel.SetActive(false);
            smith = 0;
            PlayerScript.Instance.canMove = true;
        }
        else if (smith == 2)
        {
            SmithPanel.SetActive(true);
            SmithMoney.text = PlayerScript.Instance.Money.ToString();
            smith = 3;

            ArmorLevel.text = "+" + PlayerScript.Instance.ArmorLevel.ToString();
            ArmorMoney.text = (100 * PlayerScript.Instance.ArmorLevel).ToString();
            BladeLevel.text = "+" + PlayerScript.Instance.BladeLevel.ToString();
            BladeMoney.text = (100 * PlayerScript.Instance.BladeLevel).ToString();
 
          
        }
        else if (smith == 3)
        {
            smith = 2;
            SmithPanel.SetActive(false);
            PlayerScript.Instance.canMove = true;
        }





    }

    public void Healer()
    {
        Name.text = "Healer:";
        PlayerScript.Instance.canMove = false;

        Panel.SetActive(true);
        HealerButton.SetActive(true);

        if (heal == 0)
        {

            Text.text = "Firstly prove your worth";
            HealerText.text = "aww";
            heal = 1;
        }
        else if (heal == 1)
        {
            HealerButton.SetActive(false);
            Panel.SetActive(false);
            heal = 0;
            PlayerScript.Instance.canMove = true;
        }
        else if (heal == 2)
        {

            Text.text = "Did you death? Do not worry I can revive you whenever you die for a little gold";
            HealerText.text = "Ehh Thanks";
            heal = 3;


        }
        else if (heal == 3)
        {
            HealerButton.SetActive(false);
            Panel.SetActive(false);
            heal = 4;
            PlayerScript.Instance.canMove = true;
        }
        else if (heal == 4)
        {
            Text.text = "Are you hurt? Can I help you?";
            HealerText.text = "please";
            heal = 5;
            BadButton.SetActive(true);
        }
        else if (heal == 5)
        {
            if (PlayerScript.Instance.Money >= 20)
            {

                PlayerScript.Instance.Money -= 5;
                MoneyText.text = PlayerScript.Instance.Money.ToString();

                PlayerScript.Instance.Health = PlayerScript.Instance.MaxHealth;
                HealthBar.fillAmount = 1;

                heal = 4;

                HealerButton.SetActive(false);
                Panel.SetActive(false);
                PlayerScript.Instance.canMove = true;

            }
            else
            {
                Text.text = "not enough money";
                HealerText.text = "please";


            }


        }
        else if (heal == 6)
        {
            heal = 4;

            HealerButton.SetActive(false);
            Panel.SetActive(false);
            BadButton.SetActive(false);
            PlayerScript.Instance.canMove = true;

        }


    }

    public void Guard()
    {
        Name.text = "Guard:";
        PlayerScript.Instance.canMove = false;

        Panel.SetActive(true);
        GuardButton.SetActive(true);

        if (guard == 0)
        {


            Text.text = "Welcome your first challenge";
            GuardText.text = "Thanks";
            guard = 1;
        }
        else if (guard == 1)
        {


            Text.text = "Go to the portal do not shy";
            GuardText.text = "Oki doki";
            RedPortal.SetActive(true);



            guard = 2;

        }
        else if (guard == 2)
        {
            GuardButton.SetActive(false);
            Panel.SetActive(false);
            PlayerScript.Instance.canMove = true;
            guard = 1;
            RedPortal.SetActive(true);
        }
        else if (guard == 3)
        {
            Text.text = "Again? GO GO";
            GuardText.text = "Oki doki";
            guard = 4;
            RedPortal.SetActive(true);
        }
        else if (guard == 4)
        {
            GuardButton.SetActive(false);
            Panel.SetActive(false);
            PlayerScript.Instance.canMove = true;
            guard = 3;
            RedPortal.SetActive(true);

        }



    }

    public void Seller()
    {
        Name.text = "Seller:";
        PlayerScript.Instance.canMove = false;

        Panel.SetActive(true);
        SellerButton.SetActive(true);

        if (seller == 0)
        {

            Text.text = "Firstly prove your worth";
            SellerText.text = "aww";
            seller = 1;
        }
        else if (seller == 1)
        {
            SellerButton.SetActive(false);
            Panel.SetActive(false);
            seller = 0;
            PlayerScript.Instance.canMove = true;
        }
        else if (seller == 2)
        {
            Text.text = "I am selling health potion. Do you interest";
            SellerText.text = "Would be good";
            seller = 3;

            BadButton.SetActive(true);

        }
        else if (seller == 3)
        {
            if (PlayerScript.Instance.Money >= 50)
            {
                PlayerScript.Instance.Money -= 50;
                MoneyText.text = PlayerScript.Instance.Money.ToString();

                PlayerScript.Instance.Potion += 1;
                PotionText.text = PlayerScript.Instance.Potion.ToString();

                Text.text = "if you want to use just press 'f' ";
            }
            else
            {
                Text.text = "not enough money";
                SellerText.text = "please";




            }


        }
        else if (seller == 4)
        {
            BadButton.SetActive(false);
            SellerButton.SetActive(false);
            Panel.SetActive(false);
            seller = 2;
            PlayerScript.Instance.canMove = true;
        }


    }

    public void Bad()
    {
        if (heal == 5)
        {

            heal = 6;
            Healer();
        }

        if (seller == 3)
        {
            seller = 4;
            Seller();
        }




        BadButton.SetActive(false);

        PlayerScript.Instance.canMove = true;
    }

    public void Armor()
    {
        if (PlayerScript.Instance.Money >= 100 * PlayerScript.Instance.ArmorLevel)
        {
            PlayerScript.Instance.Money -= 100 * PlayerScript.Instance.ArmorLevel;
            PlayerScript.Instance.ArmorLevel += 1;
            ArmorLevel.text = "+" + PlayerScript.Instance.ArmorLevel.ToString();
            ArmorMoney.text = (100 * PlayerScript.Instance.ArmorLevel).ToString();
            MoneyText.text = PlayerScript.Instance.Money.ToString();
            SmithMoney.text = PlayerScript.Instance.Money.ToString();
        }       
    }

    public void Blade()
    {

        if (PlayerScript.Instance.Money >= 100 * PlayerScript.Instance.BladeLevel)
        {
            PlayerScript.Instance.Money -= 100 * PlayerScript.Instance.BladeLevel;
            PlayerScript.Instance.BladeLevel += 1;
            BladeLevel.text = "+" + PlayerScript.Instance.BladeLevel.ToString();
            BladeMoney.text = (100 * PlayerScript.Instance.BladeLevel).ToString();
            MoneyText.text = PlayerScript.Instance.Money.ToString();
            SmithMoney.text = PlayerScript.Instance.Money.ToString();
        }

    }


   public int skill = 0;
    public void SkillPanel()
    {
        


        if (skill == 1)
        {
            skill = 0;
            SkillTable.SetActive(false);
            PlayerScript.Instance.canMove = true;
        }
        else
        {
            skill = 1;
            SkillTable.SetActive(true);
            PlayerScript.Instance.canMove = false;
        }



        

        SkillBar.fillAmount = PlayerScript.Instance.Exp/100;

        SkillText.text =PlayerScript.Instance.SkillPoint.ToString();
        ArmText.text="+"+ PlayerScript.Instance.DamagePoint.ToString();
        HealthText.text = "+" + PlayerScript.Instance.HealthPoint.ToString();
        SpeedText.text = "+" + PlayerScript.Instance.SpeedPoint.ToString();


       
        
        

    }




    public void Save()
    {
        PlayerPrefs.SetInt("execute", execute);
        PlayerPrefs.SetInt("smith", smith);
        PlayerPrefs.SetInt("heal", heal);
        PlayerPrefs.SetInt("guard", guard);
        PlayerPrefs.SetInt("seller", seller);
        PlayerPrefs.SetInt("warriorCounter", warriorCounter);
        PlayerPrefs.SetInt("rangerCounter", rangerCounter);
        PlayerPrefs.SetInt("EnemyCounter", enemyCounter);
       
    }

    public void Load()
    {
        execute=PlayerPrefs.GetInt("execute", execute);
        smith=PlayerPrefs.GetInt("smith", smith);
        heal=PlayerPrefs.GetInt("heal", heal);
        guard=PlayerPrefs.GetInt("guard", guard);
        seller=PlayerPrefs.GetInt("seller", seller);
        warriorCounter=PlayerPrefs.GetInt("warriorCounter", warriorCounter);
        rangerCounter=PlayerPrefs.GetInt("rangerCounter", rangerCounter);
        enemyCounter=PlayerPrefs.GetInt("EnemyCounter", enemyCounter);


    }


    public void Quit()
    {   
        Save();
        PlayerScript.Instance.Save();
        Application.Quit();
       
    }

    public void Resume()
    {
        Menu.SetActive(false);
    }

    public void Menus()
    {
        Menu.SetActive(true);

    }



    public void Reset0()
    {


        PlayerPrefs.SetInt("execute", 0);
        PlayerPrefs.SetInt("smith", 0);
        PlayerPrefs.SetInt("heal", 0);
        PlayerPrefs.SetInt("guard", 0);
        PlayerPrefs.SetInt("seller", 0);
        PlayerPrefs.SetInt("warriorCounter", -75);
        PlayerPrefs.SetInt("rangerCounter", -75);
        PlayerPrefs.SetInt("EnemyCounter", -75);

        PlayerScript.Instance.Reset0();

        Application.Quit();
    }
}
