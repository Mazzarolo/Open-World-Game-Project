using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private GameObject lifeBar;
    [SerializeField] private GameObject redLifeBar;
    private Animator animator;
    private Vector3 lifeBarSize;
    private float life;
    private float invincibleTime = 2;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        lifeBarSize = lifeBar.GetComponent<Transform>().localScale;
        life = 100;
    }

    private void Update()
    {
        ChangeElement();
        DamageBarAnimation();
        InvinsibleAnimation();
        Respawn();
    }

    public void TakeDamage (float damage)
    {
        if (invincibleTime > 2)
        {
            invincibleTime = 0;
            life -= damage;
            lifeBar.GetComponent<Transform>().localScale -= new Vector3(lifeBarSize.x * damage / 100, 0, 0);
            lifeBar.GetComponent<Transform>().localPosition -= new Vector3(lifeBarSize.x * damage / 200, 0, 0);
        }
    }

    private void Respawn ()
    {
        if (redLifeBar.GetComponent<Transform>().localScale.x <= 0)
            SceneManager.LoadScene("SampleScene");
    }

    private void InvinsibleAnimation ()
    {
        if (invincibleTime <= 2)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Mathf.Sin(invincibleTime * 30));
        } else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        invincibleTime += Time.deltaTime;
    }

    private void DamageBarAnimation ()
    {
        if (redLifeBar.GetComponent<Transform>().localScale.x > lifeBar.GetComponent<Transform>().localScale.x)
        {
            redLifeBar.GetComponent<Transform>().localScale -= new Vector3(Time.deltaTime * 20, 0, 0);
            redLifeBar.GetComponent<Transform>().localPosition -= new Vector3(Time.deltaTime * 20 / 2, 0, 0);
        }
    }

    private void ChangeElement ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetBool("OnFire", false);
            animator.SetBool("OnWater", false);
            animator.SetBool("OnLightning", false);
            animator.SetBool("Normal", true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetBool("OnFire", true);
            animator.SetBool("OnWater", false);
            animator.SetBool("OnLightning", false);
            animator.SetBool("Normal", false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.SetBool("OnFire", false);
            animator.SetBool("OnWater", true);
            animator.SetBool("OnLightning", false);
            animator.SetBool("Normal", false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            animator.SetBool("OnFire", false);
            animator.SetBool("OnWater", false);
            animator.SetBool("OnLightning", true);
            animator.SetBool("Normal", false);
        }
    }
}
