using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private PlayerStats stats;

    [Header("Bar")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Image staminaBar;
    [SerializeField] private Image expBar;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI levelTMP;
    [SerializeField] private TextMeshProUGUI healthTMP;
    [SerializeField] private TextMeshProUGUI staminaTMP;
    [SerializeField] private TextMeshProUGUI expTMP;

    [Header("Stats Panel")]
    [SerializeField] private GameObject statsPanel;
    [SerializeField] private TextMeshProUGUI statLevelTMP;
    [SerializeField] private TextMeshProUGUI statHealthTMP;
    [SerializeField] private TextMeshProUGUI statStaminaTMP;
    [SerializeField] private TextMeshProUGUI statDamageTMP;
    [SerializeField] private TextMeshProUGUI statCriticalDamegeTMP;

    [SerializeField] private TextMeshProUGUI attPointTMP;
    [SerializeField] private TextMeshProUGUI strengthPointTMP;
    [SerializeField] private TextMeshProUGUI dexterityTMP;
    [SerializeField] private TextMeshProUGUI intelligenceTMP;

    private void Update()
    {
        UpdatePlayerUI();
    }

    public void OpenCloseStatsPanel()
    {
        statsPanel.SetActive(!statsPanel.activeSelf);
        if (statsPanel.activeSelf)
        {
            UpdateStatsPanel();
        }
    }

    private void UpdatePlayerUI()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, stats.Health / stats.MaxHealth, 10f * Time.deltaTime);
        staminaBar.fillAmount = Mathf.Lerp(staminaBar.fillAmount, stats.Stamina / stats.MaxStamina, 10f * Time.deltaTime);
        expBar.fillAmount = Mathf.Lerp(expBar.fillAmount, stats.CurrentExp / stats.NextLevelExp, 10f * Time.deltaTime);

        levelTMP.text = $"Level{stats.Level}";
        healthTMP.text = $"{stats.Health} / {stats.MaxHealth}";
        staminaTMP.text = $"{stats.Stamina} / {stats.MaxStamina}";
        expTMP.text = $"{stats.CurrentExp} / {stats.NextLevelExp}";

    }

    private void UpdateStatsPanel()
    {
        statLevelTMP.text = stats.Level.ToString();
        statHealthTMP.text = stats.MaxHealth.ToString();
        statStaminaTMP.text = stats.MaxStamina.ToString();
        statDamageTMP.text = stats.TotalDamage.ToString();
        statCriticalDamegeTMP.text = stats.CriticalDamage.ToString();

        attPointTMP.text = $"Points: {stats.AttributePoint}";
        strengthPointTMP.text = stats.Strength.ToString();
        dexterityTMP.text = stats.Dexterity.ToString();
        intelligenceTMP.text = stats.Intelligence.ToString();
    }

    private void UpgradeCallback()
    {
        UpdateStatsPanel();
    }

    private void OnEnable()
    {
        PlayerUpgrade.OnPlayerUpgradeEvent += UpgradeCallback;
    }

    private void OnDisable()
    {
        PlayerUpgrade.OnPlayerUpgradeEvent -= UpgradeCallback;
    }
}
