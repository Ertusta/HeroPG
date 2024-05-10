using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public Transform Player;
    public float Speed;
    public Image HealthBar;
    

    private void Start()
    {
       Player=GameObject.Find("Player").transform;
    }
    void Update()
    {
        Vector3 desiredPosition = Player.position + new Vector3(0, 1, 0);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Speed * Time.deltaTime);
        
        transform.position = smoothedPosition;

        if(Vector3.Distance(Player.position, transform.position)<1.3f)
        {
            float damage;

            PlayerScript.Instance.BloodAnimo();

            if (5 - PlayerScript.Instance.ArmorLevel > 0)
            {
                damage = 5 - PlayerScript.Instance.ArmorLevel;
            }
            else
            {
                damage = 1;
            }

            PlayerScript.Instance.Health -= damage;
            PlayerScript.Instance.HealthRefresh();

            


            if (PlayerScript.Instance.Health <= 0)
            {
                PlayerScript.Instance.Death();
            }


            Destroy(gameObject);


           
            


        }
    }




}
