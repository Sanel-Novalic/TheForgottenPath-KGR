using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace CodeMoney_HowToHealthSystem_1_Final {

    public class HealthBar : MonoBehaviour {

        [SerializeField]
        private Enemy Enemy;
        [SerializeField]
        private Image fill;
        public void Start() {
            Enemy.OnHealthChanged += Enemy_OnHealthChanged;
            UpdateHealthBar();
        }

        private void Enemy_OnHealthChanged(object sender, System.EventArgs e) {
            UpdateHealthBar();
        }
        private void UpdateHealthBar() {
            fill.fillAmount = Enemy.GetHealthPercent();
        }

    }

}