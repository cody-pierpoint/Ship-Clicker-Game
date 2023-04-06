using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Alex;

namespace Cody
{
    public class ShipsClicker : MonoBehaviour
    {
        
        public float shipsPerTick = 0;
        public float shipsPerClick = 0;
        public float upgradeCost = 10;
        public float autoClickUpgradeCost = 20;
        public ClickerScript clickerScript;

        public Button upgradeButton;
        public Button autoClickUpgrade;
        public TextMeshProUGUI currencyTextDisplay;
        public TextMeshProUGUI autoClickUpgradeText;
        public TextMeshProUGUI clickUpgradeText;


        // Start is called before the first frame update
        void Start()
        {
            upgradeButton.interactable = false;
            autoClickUpgrade.interactable = false;
            autoClick();

            StartCoroutine(autoClick());
            UpdatePointsText();
        }



        // Update is called once per frame
        void Update()
        {
            UpgradeInteractable();
            //Mathf.RoundToInt(clickerScript.Currency);

        }


        public void Click()
        {
            clickerScript.ClickerButton();
            clickerScript.Currency += shipsPerClick;
            UpdatePointsText();
            //Mathf.RoundToInt(clickerScript.Currency);

        }

        public void UpgradeInteractable()
        {
            if (clickerScript.Currency >= autoClickUpgradeCost)
            {
                autoClickUpgrade.interactable = true;

            }

            else
            {
                autoClickUpgrade.interactable = false;
            }
            if (clickerScript.Currency >= upgradeCost)
            {
                upgradeButton.interactable = true;

            }
            else
            {
                upgradeButton.interactable = false;

            }
        }

        public void UpgradeClicks()
        {
            if (clickerScript.Currency >= upgradeCost)
            {

                clickerScript.Currency -= upgradeCost;

                shipsPerClick++;

                upgradeCost = upgradeCost * 2;
                //Mathf.RoundToInt(upgradeCost);

            }
            upgradeButton.interactable = true;
            UpdatePointsText();

        }

        public void updateShipsPerTick()
        {
            if (clickerScript.Currency >= autoClickUpgradeCost)
            {

                clickerScript.Currency -= autoClickUpgradeCost;
                shipsPerTick++;
                autoClickUpgradeCost = autoClickUpgradeCost * 2f;
                //Mathf.RoundToInt(autoClickUpgradeCost);

            }
            autoClickUpgrade.interactable = true;
            UpdatePointsText();
        }


        private void UpdatePointsText()
        {

            currencyTextDisplay.text = "Ships: " + clickerScript.Currency;
            autoClickUpgradeText.text = "Auto Click Upgrade Cost: " + autoClickUpgradeCost;
            clickUpgradeText.text = "Click Upgrade Cost: " + upgradeCost;
            
        }
        public IEnumerator autoClick()
        {
            while (true)
            {
                Debug.Log("autoclick Added" + shipsPerTick);
                yield return new WaitForSeconds(1.5f);
                clickerScript.Currency += shipsPerTick;
                UpdatePointsText();
            }


        }
        
    }
}