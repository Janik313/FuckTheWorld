using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text ScoreText;
    public float score;
    public float AddingScore = 1;
    public float ClickScoreUpgradeCost = 100;
    public Text ClickScoreUpgradeButton;
    public float FactoryUpgradeCost = 500;
    public Text FactoryUpgradeButton;
    public float FactoryPerSec = 0;

    public void Start()
    {
        score = PlayerPrefs.GetFloat("CurrentScore");
        AddingScore = PlayerPrefs.GetFloat("AddingScore");
        ClickScoreUpgradeCost = PlayerPrefs.GetFloat("ClickScoreUpgradeCost");
        ClickScoreUpgradeButton.text = "Upgrade your production \n" + "Costs: " + ClickScoreUpgradeCost;
        FactoryPerSec = PlayerPrefs.GetFloat("FactoryPerSec");
        FactoryUpgradeButton.text = "Build a new Facotry\n" + "Costs: " + FactoryUpgradeCost;
        FactoryPerSec.ToString("F0");
        score.ToString("F0");
    }
    public void Update()
    {
        ScoreText.text = "You have \n" + score.ToString("F0") + "\n uranium";
        score = PlayerPrefs.GetFloat("CurrentScore");
        FactoryPerSec = PlayerPrefs.GetFloat("FactoryPerSec");
        PlayerPrefs.SetFloat("CurrentScore", score += FactoryPerSec * Time.deltaTime);
    }

    public void AddUran()
    {
        score += AddingScore;
        PlayerPrefs.SetFloat("CurrentScore", score);
    }

    

    public void Reset()
    {
        PlayerPrefs.SetFloat("CurrentScore", 0);
        PlayerPrefs.SetFloat("AddingScore", 1);
        PlayerPrefs.SetFloat("ClickScoreUpgradeCost", 50);
        score = 0;
        AddingScore = 1;
        ClickScoreUpgradeCost = PlayerPrefs.GetFloat("ClickScoreUpgradeCost");
        ClickScoreUpgradeButton.text = "Upgrade your production \n" + "Costs: " + ClickScoreUpgradeCost;
        PlayerPrefs.SetFloat("FactoryPerSec", 0);
        PlayerPrefs.SetFloat("FactoryUpgradeCost", FactoryUpgradeCost);
        FactoryPerSec = 0;
    }

    //Upgrades
    public void ClickScoreUpgrade()
    {
        if (ClickScoreUpgradeCost < PlayerPrefs.GetFloat("CurrentScore"))
        {
            PlayerPrefs.SetFloat("AddingScore", PlayerPrefs.GetFloat("AddingScore") + 5);
            PlayerPrefs.SetFloat("CurrentScore", score -= ClickScoreUpgradeCost);
            PlayerPrefs.SetFloat("ClickScoreUpgradeCost", ClickScoreUpgradeCost + 50);
            ClickScoreUpgradeCost = PlayerPrefs.GetFloat("ClickScoreUpgradeCost");
            ClickScoreUpgradeButton.text = "Upgrade your production \n" + "Costs: " + ClickScoreUpgradeCost;
            AddingScore = PlayerPrefs.GetFloat("AddingScore");
        }
    }

    public void FactoryUpgrade()
    {
        if (FactoryUpgradeCost < PlayerPrefs.GetFloat("CurrentScore"))
        {
            PlayerPrefs.SetFloat("FactoryPerSec", FactoryPerSec + 5);
            PlayerPrefs.SetFloat("CurrentScore", score -= FactoryUpgradeCost);
            PlayerPrefs.SetFloat("FactoryUpgradeCost", FactoryUpgradeCost + 500);
            FactoryUpgradeCost = PlayerPrefs.GetFloat("FactoryUpgradeCost");
            FactoryUpgradeButton.text = "Build a new Facotry\n" + "Costs: " + FactoryUpgradeCost;
            FactoryPerSec = PlayerPrefs.GetFloat("FactoryPerSec");
        }
    }
}
