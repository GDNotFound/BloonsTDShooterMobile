using UnityEngine;

public class Dart : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Balloon balloon = other.GetComponent<Balloon>();

        if (balloon != null)
        {
            balloon.TakeDamage(1);
            Destroy(gameObject); 
        }
    }
}

