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
        #region Currency Variables
        public float shipsPerTick = 0;
        public float shipsPerClick = 0;
        public float upgradeCost = 10;
        public float autoClickUpgradeCost = 20;
        #endregion
        #region instance of other scripts
        public ClickerScript clickerScript;
        //Refferece to ShipMovement Method.
        public ShipMovement spawnShips;
        #endregion
        #region UI Variables
        public Button upgradeButton;
        public Button autoClickUpgrade;
        public TextMeshProUGUI currencyTextDisplay;
        public TextMeshProUGUI autoClickUpgradeText;
        public TextMeshProUGUI clickUpgradeText;
        #endregion
        
        private float timer;
        #region Start
        void Start()
        {
            //make upgrade button uninteractable
            upgradeButton.interactable = false;
            //make autoclick upgrade uninteractable
            autoClickUpgrade.interactable = false;
            //run autoclick
            AutoClick();
            //run autoclick coroutine
            StartCoroutine(AutoClick());
            //update Texts;
            UpdatePointsText();
        }
        #endregion


        void Update()
        {
            //run upgrade interactable method
            UpgradeInteractable();
            //if auto click has been purchased at least once
            if (shipsPerTick > 0)
            {
                //create timer based on time.deltatime
                timer += Time.deltaTime;
                //if timer >= times upgradecose purchased +1
                if (timer >= shipsPerTick+1)
                {
                    for (int i = 0; i < shipsPerTick; i++)
                    {
                        //store the range of 0 - Shipspertick+1 within temp
                       int temp = Random.RandomRange(0, (int)shipsPerTick+1);
                        //if temp >= half ships per tick
                        if (temp >= shipsPerTick/2)
                        {
                            //spawn ships * number of times ships per tick was purchased
                            spawnShips.SpawnShipOverTime(i);
                        }
                    }
                    //Reset timer
                    timer = 0;
                }
            }
        }
        public void Click()
        {
            //run Clickerbutton method from clickerScript
            clickerScript.ClickerButton();
            //add ships per click to currency per click
            clickerScript.Currency += shipsPerClick;
            //update currency text
            UpdatePointsText();
        }
        public void UpgradeInteractable()
        {
            //if currency is >= autoclick upgrade cost 
            if (clickerScript.Currency >= autoClickUpgradeCost)
            {
                //auto click upgrade is interactable.
                autoClickUpgrade.interactable = true;
            }
            else
            {
                // autoclick upgrade button is not interactable
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
            }
            upgradeButton.interactable = true;
            UpdatePointsText();
        }
        public void UpdateShipsPerTick()
        {
            if (clickerScript.Currency >= autoClickUpgradeCost)
            {

                clickerScript.Currency -= autoClickUpgradeCost;
                shipsPerTick++;
                autoClickUpgradeCost = autoClickUpgradeCost * 2f;
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
        public IEnumerator AutoClick()
        {
            while (true)
            {
                //Debug.Log("AutoClick Added" + shipsPerTick);
                yield return new WaitForSeconds(0.5f);
                clickerScript.Currency += shipsPerTick;
                UpdatePointsText();
            }
        }        
    }
}