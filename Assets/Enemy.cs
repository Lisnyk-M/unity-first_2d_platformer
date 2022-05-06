using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Text))]
public class Enemy : MonoBehaviour
{
    private GameObject[] health;
    private Hero heroScript;
    public Text health2;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"Collision: {collision.gameObject.transform.position}");
     
        if (collision.gameObject.name == "Hero")
        {
            DecrementHealh();
        }
    }
    void Awake()
    {
        ShowHealth();
    }

    void ShowHealth()
    {
        health2.text = "Health: " + Hero.Health.ToString();
    }

    public void SceneLoad(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void DecrementHealh()
    {
        Hero.Health -= 1;
        if (Hero.Health <= 0)
        {
            SceneLoad(1);
            Hero.Health = Hero.HealtDefault;
        }
        ShowHealth();
    }
}
