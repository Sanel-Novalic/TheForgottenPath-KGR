
using TMPro;

using Unity.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public int level = 1;
    public float maxLevel;
    public float currentXp = 0;
    public int nextLevelXp = 100;
    [Header("Multipliers")]
    [Range(1f, 300f)]
    public float additionMultiplier;
    [Range(2f, 4f)]
    public float powerMultiplier = 20f;
    [Range(7f, 14f)]
    public float divisionMultiplier = 7f;
    //public GameObject levelUpEffect;

    [Header("UI")]
    [SerializeField]
    private Image FrontXpBar;
    [SerializeField]
    private Image BackXpBar;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI XpText;

    [Header("Audio")]
    public AudioClip levelUpSound;
    [SerializeField]
    private AudioSource Source;
    //Timers
    private float lerpTimer;
    private float delayTimer;

    //Player parameters
    private 

    void Start()
    {
        levelText.text = "Level " + level;
        level = 1;
        XpText.text = Mathf.Round(currentXp) + "/" + Mathf.Round(nextLevelXp);
        FrontXpBar.fillAmount = currentXp / nextLevelXp;
        BackXpBar.fillAmount = currentXp / nextLevelXp;
        nextLevelXp = CalculateNextLevelXp();
    }
    private void UpdateXpUI() 
    {
        float xpFraction = currentXp / nextLevelXp;
        float fXP = FrontXpBar.fillAmount;
        if (fXP < xpFraction)
        {
            delayTimer += Time.deltaTime;
            BackXpBar.fillAmount = xpFraction;
            if (delayTimer > 3)
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / 5;
                percentComplete = percentComplete * percentComplete;
                FrontXpBar.fillAmount = Mathf.Lerp(fXP, BackXpBar.fillAmount, percentComplete);
            }

        }
        XpText.text = currentXp + "/" + nextLevelXp;
        if (level != maxLevel)
        {
            if (currentXp >= nextLevelXp)
            {
                LevelUp();
            }
        }
        else
        {
            currentXp = nextLevelXp;
            XpText.text = "MAX";
            FrontXpBar.fillAmount = currentXp / nextLevelXp;
            BackXpBar.fillAmount = currentXp / nextLevelXp;
        }
    }

    public void GainExperienceFlatRate(float xpGained)
    {
            currentXp += xpGained;
            lerpTimer = 0f;
            delayTimer = 0f;
    }
    public void IncreaseXP(int Amount)
    {
        currentXp += Amount;
        UpdateXpUI();
    }
    public void GainExperienceScalable(float xpGained, int passedLevel)
    {
        if (passedLevel < level)
        {
            float multiplier = 1 + (level - passedLevel) * 0.1f;
            currentXp += Mathf.Round(xpGained*multiplier);

        }
        else
        {
            currentXp += xpGained;

        }

        lerpTimer = 0f;
        delayTimer = 0f;

    }
    public void LevelUp() 
    {
        level += 1;
        BackXpBar.fillAmount = 0f;
        FrontXpBar.fillAmount = 0f;
        currentXp = Mathf.Round(currentXp-nextLevelXp);

        nextLevelXp = CalculateNextLevelXp();
        level = Mathf.Clamp(level,0, 50);

        XpText.text = Mathf.Round(currentXp) + "/" + nextLevelXp;
        levelText.text = "Level " + level;
        //Instantiate(levelUpEffect, transform.position, Quaternion.identity);
        GetComponent<Player>().IncreaseStats();
        Source.PlayOneShot(levelUpSound);
    }
    private int CalculateNextLevelXp() 
    {
        int solveForRequiredXp = 0;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForRequiredXp += (int)Mathf.Floor(levelCycle + additionMultiplier * Mathf.Pow(powerMultiplier, levelCycle / divisionMultiplier));
        }
        return solveForRequiredXp / 4;
    }
}
