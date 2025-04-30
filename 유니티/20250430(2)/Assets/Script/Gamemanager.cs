using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] private GameObject gameoverText;  //���ӿ��� �ؽ�Ʈ
    [SerializeField] private TextMeshProUGUI timeText;  //�����ð��� �ؽ�Ʈ
    [SerializeField] private TextMeshProUGUI recordText; //�ְ��� �ؽ�Ʈ

    private float surviveTime;
    private bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0.0f;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //���� �������
        if (isGameOver)
        {
            CheckRestart(); //����� üũ
            return;
        }
        surviveTime += Time.deltaTime; //�����ð� ����
        timeText.text = "Time :" + (int)surviveTime;
    }

    private void CheckRestart()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void EndGame()
    {
        isGameOver = true;//���ӿ������·� ����
        StartCoroutine(FadeInGameoverTextCo());

        float bestTime = PlayerPrefs.GetFloat("Best Time");

        if (surviveTime>bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime); //����
        }
        recordText.text = "Best Time : " + (int)bestTime;
    }

    IEnumerator FadeInGameoverTextCo()
    {
        if (!gameoverText.TryGetComponent(out TextMeshProUGUI text))
        {
            yield break;
        }
        gameoverText.SetActive(true);

        Color color = text.color;
        color.a = 0.0f;
        text.color = color;

        float alpha = 0.0f;
        while (alpha<1.0f)
        {
            alpha += Time.deltaTime * 2.0f;
            text.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
        text.color = new Color();///////
    }
}
