using Alex;
using UnityEngine;

namespace Cody
{
    public class ShipMovement : MonoBehaviour
    {
        public GameObject shipPrefab;
        public Transform screenEdgePoint;
        public Transform spawnPos;
        public float SpawnCurrency = 10;
        public GameObject shipParrent;
        public static int spawnAmount = 0;
        public ClickerScript clicky;
        public static float boatCurrency;
        private void Start()
        {
            spawnAmount = 0;
            SpawnCurrency = 15;
        }
        public void SpawnShip()
        {
            if (clicky.Currency % 10 == 0)
            {
                Instantiate(shipPrefab,(new Vector3(spawnPos.position.x, spawnPos.position.y +Random.Range(-0.5f,1.5f), spawnPos.position.z)),Quaternion.identity, shipParrent.transform);
            }
           

        }
        public void SpawnShipOverTime(int i)
        {
            Invoke("ShipWoop", i);
        }
      void ShipWoop()
        {
            Instantiate(shipPrefab, (new Vector3(spawnPos.position.x, spawnPos.position.y + Random.Range(-0.5f, 1.5f), spawnPos.position.z)), Quaternion.identity, shipParrent.transform);
        }

    }
}