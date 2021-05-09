using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
	[SerializeField]
	private int MaxHealth = 100;
	private int CurrentHealth;
	private float LerpTimer;
	[SerializeField]
	private float ChipSpeed = 1f;
	[SerializeField]
	private HealthBar HealthBar;
	[SerializeField]
	private Image FrontHealthBar;
	[SerializeField]
	private Image BackHealthBar;
	[SerializeField]
	private TextMeshProUGUI HealthText;
	// Start is called before the first frame update
	void Start()
    {
		CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
		UpdateHealthUI();
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(20);
		}
		if(Input.GetKeyDown(KeyCode.F))
        {
			RestoreHealth(20);
        }
    }

	public void TakeDamage(int damage)
	{
		CurrentHealth -= damage;
		LerpTimer = 0f;
		if (CurrentHealth <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	public void UpdateHealthUI()
    {
		float FillF = FrontHealthBar.fillAmount;
		float FillB = BackHealthBar.fillAmount;
		float HFraction = (float)CurrentHealth / MaxHealth;
		if(FillB > HFraction)
        {
			FrontHealthBar.fillAmount = HFraction;
			BackHealthBar.color = Color.red;
			LerpTimer += Time.deltaTime;
			float PercentComplete = LerpTimer / ChipSpeed;
			PercentComplete = PercentComplete * PercentComplete; // Smoother animation
			BackHealthBar.fillAmount = Mathf.Lerp(FillB, HFraction, PercentComplete);
        }
		if (FillF < HFraction)
		{
			BackHealthBar.color = Color.green;
			BackHealthBar.fillAmount = HFraction;
			LerpTimer += Time.deltaTime;
			float PercentComplete = LerpTimer / ChipSpeed;
			PercentComplete = PercentComplete * PercentComplete; // Smoother animation
			FrontHealthBar.fillAmount = Mathf.Lerp(FillF, HFraction, PercentComplete);
		}
		HealthText.text = CurrentHealth + "/" + MaxHealth;
	}
	public void IncreaseHealth(int level)
	{
		MaxHealth += Mathf.RoundToInt((CurrentHealth * 0.01f) * ((100 - level) * 0.1f));
		CurrentHealth = MaxHealth;
	}
	public void RestoreHealth(int HealAmount)
    {
		CurrentHealth += HealAmount;
		LerpTimer = 0f;

    }
}
