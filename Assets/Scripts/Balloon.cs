using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int hp = 1;
    private GameManager gameManager;
    private bool isPopped = false; 
    public void Setup(int health, GameManager manager)
    {
        hp = Mathf.Max(health, 1); 
        gameManager = manager;

        Debug.Log("Globo creado con HP: " + hp);
    }

    void OnMouseDown()
    {
        TakeDamage(1);
    }
    public void TakeDamage(int amount)
    {
        if (isPopped) return;

        hp -= amount;
        Debug.Log(hp);

        if (hp <= 0)
        {
            isPopped = true;
            gameManager.OnBalloonPopped();
            Destroy(gameObject);

        }
    }
}


