using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using System;

public class Player : MonoBehaviourPun,IPunObservable
{
	[SerializeField]
	private int MaxHealth = 100;
	[HideInInspector]
	public int CurrentHealth;
	private float LerpTimer;
	[SerializeField]
	private float ChipSpeed = 1f;
	[SerializeField]
	private Image FrontHealthBar;
	[SerializeField]
	private Image BackHealthBar;
	[SerializeField]
	private TextMeshProUGUI HealthText;
	protected Rigidbody Rigidbody;
	protected Animator Animator;
	private int AttackDamage = 100;
	// Start is called before the first frame update
	void Start()
    {
		CurrentHealth = MaxHealth;
		
    }
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		Rigidbody = GetComponent<Rigidbody>();
		Animator = GetComponent<Animator>();
		if (!photonView.IsMine && this.gameObject.GetComponent<Invector.vCharacterController.vThirdPersonInput>()!=null )
		{
			this.gameObject.GetComponent<Invector.vCharacterController.vThirdPersonInput>().enabled = false;
			

		}
		
		
	}

    public int GetAttackDamage()
    {
		return AttackDamage;
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
			
			transform.position = Vector3.zero;
			transform.rotation = Quaternion.identity;
			CurrentHealth = MaxHealth;
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
	public static void RefreshInstance(ref Player player, Player Prefab)
	{
		var position = Vector3.zero;
		var rotation = Quaternion.identity;
		if (player != null)
		{
			position = player.transform.position;
			rotation = player.transform.rotation;
			PhotonNetwork.Destroy(player.gameObject);
		}

		player = PhotonNetwork.Instantiate(Prefab.gameObject.name, position, rotation).GetComponent<Player>();
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
			
		}
		else
		{
			transform.position = (Vector3)stream.ReceiveNext();
			transform.rotation = (Quaternion)stream.ReceiveNext();
			
		}
	}

    public void IncreaseStats()
    {
		AttackDamage += 50;
		MaxHealth += 50;
		CurrentHealth = MaxHealth;
    }
}
