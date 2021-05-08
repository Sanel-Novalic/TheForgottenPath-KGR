using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
	[SerializeField]
	private int MaxHealth = 100;
	private int CurrentHealth;
	[SerializeField]
	private HealthBar HealthBar;

    // Start is called before the first frame update
    void Start()
    {
		CurrentHealth = MaxHealth;
		HealthBar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(20);
		}
    }

	public void TakeDamage(int damage)
	{
		CurrentHealth -= damage;
		HealthBar.SetHealth(CurrentHealth);
		if (CurrentHealth <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
