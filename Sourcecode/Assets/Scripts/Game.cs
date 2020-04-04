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
    public float FactoryUpgradeCost = 50000;
    public Text FactoryUpgradeButton;
    public float FactoryPerSec = 0;
    public float WorkerUpgradeCost = 500;
    public Text WorkerUpgradeButton;
    public float WorkerPerSec = 0;
    public Text UranPerSec;
    public float UranPS = 0;
    public float GrandmaUpgradeCost = 2000;
    public Text GrandmaUpgradeButton;
    public float GrandmaPerSec = 0;
    public float MineUpgradeCost = 10000;
    public Text MineUpgradeButton;
    public float MinePerSec = 0;
    public float AlienUpgradeCost = 500000;
    public Text AlienUpgradeButton;
    public float AlienPerSec = 0;
    public float PlutoniumCost = 100000;
    public float PlutoniumScore = 0;
    public Text PlutoniumText;
    public float BombCost = 3000;
    public float BombScore = 0;
    public Text BombText;
    public float EarthHealth = 4;
    public Image ZeroHit;
    public Image OneHit;
    public Image TwoHit;
    public Image ThreeHit;
    public Image FourHit;
    public Text Bombs2;
    public Text WinText;

    public void Start()
    {
        score = PlayerPrefs.GetFloat("CurrentScore");
        AddingScore = PlayerPrefs.GetFloat("AddingScore");
        ClickScoreUpgradeCost = PlayerPrefs.GetFloat("ClickScoreUpgradeCost");
        ClickScoreUpgradeButton.text = "Upgrade your production \n" + "Costs: " + ClickScoreUpgradeCost;
        FactoryPerSec = PlayerPrefs.GetFloat("FactoryPerSec");
        FactoryPerSec.ToString("F0");
        score.ToString("F0");
        WorkerPerSec.ToString("F0");
        WorkerPerSec = PlayerPrefs.GetFloat("WorkerPerSec");
        GrandmaPerSec.ToString("F0");
        GrandmaPerSec = PlayerPrefs.GetFloat("GrandmaPerSec");
        MinePerSec.ToString("F0");
        MinePerSec = PlayerPrefs.GetFloat("MinePerSec");
        AlienPerSec.ToString("F0");
        AlienPerSec = PlayerPrefs.GetFloat("AlienPerSec");
    }
    public void Update()
    {
        ScoreText.text = "You have \n" + score.ToString("F0") + "\n Uranium";
        score = PlayerPrefs.GetFloat("CurrentScore");
        FactoryPerSec = PlayerPrefs.GetFloat("FactoryPerSec");
        WorkerPerSec = PlayerPrefs.GetFloat("WorkerPerSec");
        PlayerPrefs.SetFloat("CurrentScore", score += UranPS * Time.deltaTime);
        UranPS = PlayerPrefs.GetFloat("UranPerSec");
        UranPerSec.text = "Uranium/s: " + UranPS;
        FactoryUpgradeButton.text = "Costs: " + FactoryUpgradeCost;
        WorkerUpgradeButton.text = "Costs: " + WorkerUpgradeCost;
        WorkerUpgradeCost = PlayerPrefs.GetFloat("WorkerUpgradeCost");
        FactoryUpgradeCost = PlayerPrefs.GetFloat("FactoryUpgradeCost");
        GrandmaUpgradeButton.text = "Costs: " + GrandmaUpgradeCost;
        GrandmaUpgradeCost = PlayerPrefs.GetFloat("GrandmaUpgradeCost");
        MineUpgradeButton.text = "Costs: " + MineUpgradeCost;
        MineUpgradeCost = PlayerPrefs.GetFloat("MineUpgradeCost");
        AlienUpgradeButton.text = "Costs: " + AlienUpgradeCost;
        AlienUpgradeCost = PlayerPrefs.GetFloat("AlienUpgradeCost");
        PlutoniumScore = PlayerPrefs.GetFloat("PlutoniumScore");
        PlutoniumText.text = PlutoniumScore.ToString();
        BombScore = PlayerPrefs.GetFloat("BombScore");
        BombText.text = BombScore.ToString();
        EarthHealth = PlayerPrefs.GetFloat("EarthHealth");
        Bombs2.text = BombScore.ToString();
        CheckHit();
        ClickScoreUpgradeButton.text = "Costs: " + ClickScoreUpgradeCost;
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
        PlayerPrefs.SetFloat("FactoryUpgradeCost", 50000);
        FactoryPerSec = 0;
        PlayerPrefs.SetFloat("WorkerPerSec", 0);
        PlayerPrefs.SetFloat("WorkerUpgradeCost", 500);
        WorkerPerSec = 0;
        PlayerPrefs.SetFloat("UranPerSec", 0);
        UranPS = 0;
        PlayerPrefs.SetFloat("GrandmaPerSec", 0);
        PlayerPrefs.SetFloat("GrandmaUpgradeCost", 2000);
        GrandmaPerSec = 0;
        PlayerPrefs.SetFloat("MinePerSec", 0);
        PlayerPrefs.SetFloat("MineUpgradeCost", 10000);
        MinePerSec = 0;
        PlayerPrefs.SetFloat("AlienPerSec", 0);
        PlayerPrefs.SetFloat("AlienUpgradeCost", 500000);
        AlienPerSec = 0;
        PlayerPrefs.SetFloat("PlutoniumScore", 0);
        PlayerPrefs.SetFloat("BombScore", 0);
        PlayerPrefs.SetFloat("BombScore", 0);
        PlayerPrefs.SetFloat("EarthHealth", 4);
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
            ClickScoreUpgradeButton.text = "Costs: " + ClickScoreUpgradeCost;
            AddingScore = PlayerPrefs.GetFloat("AddingScore");
        }
    }

    public void FactoryUpgrade()
    {
        if (FactoryUpgradeCost < PlayerPrefs.GetFloat("CurrentScore"))
        {
            PlayerPrefs.SetFloat("FactoryPerSec", FactoryPerSec + 1000);
            PlayerPrefs.SetFloat("CurrentScore", score -= FactoryUpgradeCost);
            PlayerPrefs.SetFloat("FactoryUpgradeCost", FactoryUpgradeCost + 50000);
            FactoryUpgradeCost = PlayerPrefs.GetFloat("FactoryUpgradeCost");
            FactoryUpgradeButton.text = "Costs: " + FactoryUpgradeCost;
            FactoryPerSec = PlayerPrefs.GetFloat("FactoryPerSec");
            PlayerPrefs.SetFloat("UranPerSec", UranPS + 1000);
        }
    }

    public void WorkerUpgrade()
    {
        if (WorkerUpgradeCost < PlayerPrefs.GetFloat("CurrentScore"))
        {
            PlayerPrefs.SetFloat("WorkerPerSec", WorkerPerSec + 5);
            PlayerPrefs.SetFloat("CurrentScore", score -= WorkerUpgradeCost);
            PlayerPrefs.SetFloat("WorkerUpgradeCost", WorkerUpgradeCost + 500);
            WorkerUpgradeCost = PlayerPrefs.GetFloat("WorkerUpgradeCost");
            WorkerUpgradeButton.text = "Costs: " + WorkerUpgradeCost;
            WorkerPerSec = PlayerPrefs.GetFloat("WorkerPerSec");
            PlayerPrefs.SetFloat("UranPerSec", UranPS + 5);
        }
    }

    public void GrandmaUpgrade()
    {
        if (GrandmaUpgradeCost < PlayerPrefs.GetFloat("CurrentScore"))
        {
            PlayerPrefs.SetFloat("GrandmaPerSec", GrandmaPerSec + 15);
            PlayerPrefs.SetFloat("CurrentScore", score -= GrandmaUpgradeCost);
            PlayerPrefs.SetFloat("GrandmaUpgradeCost", GrandmaUpgradeCost + 3000);
            GrandmaUpgradeCost = PlayerPrefs.GetFloat("GrandmaUpgradeCost");
            GrandmaUpgradeButton.text = "Costs: " + GrandmaUpgradeCost;
            GrandmaPerSec = PlayerPrefs.GetFloat("GrandmaPerSec");
            PlayerPrefs.SetFloat("UranPerSec", UranPS + 15);
        }
    }

    public void MineUpgrade()
    {
        if (MineUpgradeCost < PlayerPrefs.GetFloat("CurrentScore"))
        {
            PlayerPrefs.SetFloat("MinePerSec", MinePerSec + 100);
            PlayerPrefs.SetFloat("CurrentScore", score -= MineUpgradeCost);
            PlayerPrefs.SetFloat("MineUpgradeCost", MineUpgradeCost + 10000);
            MineUpgradeCost = PlayerPrefs.GetFloat("MineUpgradeCost");
            MineUpgradeButton.text = "Costs: " + MineUpgradeCost;
            MinePerSec = PlayerPrefs.GetFloat("MinePerSec");
            PlayerPrefs.SetFloat("UranPerSec", UranPS + 100);
        }
    }

    public void AlienUpgrade()
    {
        if (AlienUpgradeCost < PlayerPrefs.GetFloat("CurrentScore"))
        {
            PlayerPrefs.SetFloat("AlienPerSec", AlienPerSec + 10000);
            PlayerPrefs.SetFloat("CurrentScore", score -= AlienUpgradeCost);
            PlayerPrefs.SetFloat("AlienUpgradeCost", AlienUpgradeCost + 750000);
            AlienUpgradeCost = PlayerPrefs.GetFloat("AlienUpgradeCost");
            AlienUpgradeButton.text = "Costs: " + AlienUpgradeCost;
            AlienPerSec = PlayerPrefs.GetFloat("AlienPerSec");
            PlayerPrefs.SetFloat("UranPerSec", UranPS + 10000);
        }
    }

    //Plutonium Exchange
    public void Plutonium()
    {
        if (PlutoniumCost < PlayerPrefs.GetFloat("CurrentScore"))
        {
            PlayerPrefs.SetFloat("CurrentScore", score -= PlutoniumCost);
            PlayerPrefs.SetFloat("PlutoniumScore", PlutoniumScore += 1);
        }
    }

    //Build Bomb

    public void bomb()
    {
        if (3000 < PlayerPrefs.GetInt("PlutoniumScore"))
        {
            PlayerPrefs.SetFloat("PlutoniumScore", PlutoniumScore -= 3000);
            PlayerPrefs.SetFloat("BombScore", BombScore += 1);
        }
    }


    //bomb earth
    public void BombEarth()
    {
        if (PlayerPrefs.GetFloat("BombScore") > 0)
        {
            PlayerPrefs.SetFloat("EarthHealth", EarthHealth -= 1);
            EarthHealth = PlayerPrefs.GetFloat("EarthHealth");
        }
    }

    public void CheckHit()
    {
        if (EarthHealth == 4)
        {
            ZeroHit.enabled = true;
            OneHit.enabled = false;
            TwoHit.enabled = false;
            ThreeHit.enabled = false;
            FourHit.enabled = false;
            WinText.gameObject.SetActive(false);
        }
        else if(EarthHealth == 3)
        {
            ZeroHit.enabled = false;
            OneHit.enabled = true;
            TwoHit.enabled = false;
            ThreeHit.enabled = false;
            FourHit.enabled = false;
            WinText.gameObject.SetActive(false);
        }
        else if (EarthHealth == 2)
        {
            ZeroHit.enabled = false;
            OneHit.enabled = false;
            TwoHit.enabled = true;
            ThreeHit.enabled = false;
            FourHit.enabled = false;
            WinText.gameObject.SetActive(false);
        }
        else if (EarthHealth == 1)
        {
            ZeroHit.enabled = false;
            OneHit.enabled = false;
            TwoHit.enabled = false;
            ThreeHit.enabled = true;
            FourHit.enabled = false;
            WinText.gameObject.SetActive(false);
        }
        else if (EarthHealth == 0)
        {
            ZeroHit.enabled = false;
            OneHit.enabled = false;
            TwoHit.enabled = false;
            ThreeHit.enabled = false;
            FourHit.enabled = true;
            WinText.gameObject.SetActive(true);
        }
    }

}
