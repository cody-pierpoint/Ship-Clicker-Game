using Alex;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

namespace Cody
{
    public class ShipMovement : MonoBehaviour
    {
        public GameObject shipPrefab;
        public float speed;
        public Transform screenEdgePoint;
        public ClickerScript clicker;
        public Transform spawnPos;
        public float SpawnCurrency;
        public GameObject shipParrent;
        public int spawnAmount;
        public int spawnCost;
        // Start is called before the first frame update
        void Start()
        {
            spawnCost = 10;
        }

        // Update is called once per frame
        void Update()
        {
            MoveShip();
            //SpawnShip();
        }

        public void SpawnShip()
        {
            SpawnCurrency += clicker.Currency;
            if (SpawnCurrency == 10 && spawnAmount <= 5)
            {
                SpawnCurrency -= 10;
                spawnAmount++;
                Instantiate(shipPrefab,spawnPos);

            }
            MoveShip();
            if (shipPrefab.transform.position.x >= screenEdgePoint.position.x)
            {
                Destroy(shipPrefab);
                spawnAmount--;
            }

        }
        public void MoveShip()
        {
            shipPrefab.transform.Translate(-gameObject.transform.right * speed * Time.deltaTime);
        }
    }
}