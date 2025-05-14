using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject startScreenTittle; 
    public GameObject startScreenAdvice; 
    public GameObject balloonPrefab;
    public Transform spawnPoint;

    public GameObject endScreen; 
    public TMPro.TextMeshProUGUI balloonCounterText;
    public TMPro.TextMeshProUGUI balloonHPText;

    private int currentBalloonHP = 1;
    private int balloonsPopped = 0;
    private GameObject currentBalloon;
    private bool gameStarted = false;


    void Update()
    {
        if (gameStarted)
        {
            UpdateBalloonLife();
        }
    }

    public void StartGame()
    {
        gameStarted = true;
        startScreenTittle.SetActive(false);
        startScreenAdvice.SetActive(false);

        SpawnNextBalloon();
    }

    public void OnBalloonPopped()
    {
        balloonsPopped++;

        if (balloonsPopped >= 50)
        {
            EndGame();
        }
        else
        {
            SpawnNextBalloon();
        }
    }

    void SpawnNextBalloon()
    {
        currentBalloonHP = balloonsPopped + 1;

        currentBalloon = Instantiate(balloonPrefab, spawnPoint.position, Quaternion.identity);
        Balloon balloon = currentBalloon.GetComponent<Balloon>();
        balloon.Setup(currentBalloonHP, this);
        Color randomColor = Color.HSVToRGB(Random.value, 0.8f, 1f);
        Color balloonColor = currentBalloon.GetComponent<SpriteRenderer>().color = randomColor;
        Debug.Log("Nuevo globo con vida: " + currentBalloonHP);

        if (balloonCounterText != null)
        {
            balloonCounterText.text = "Globos: " + balloonsPopped + "/50";
        }
    }
    void UpdateBalloonLife()
    {
        Balloon balloonHp = currentBalloon.GetComponent<Balloon>();
        if (balloonHPText != null)
        {
            balloonHPText.text = balloonHp.hp + "/" + currentBalloonHP;
        }
    }

    void EndGame()
    {
        if (currentBalloon != null)
            Destroy(currentBalloon);

        endScreen.SetActive(true);
    }
}

