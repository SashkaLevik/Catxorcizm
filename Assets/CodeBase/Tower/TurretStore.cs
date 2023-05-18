using UnityEngine;

namespace CodeBase.Tower
{
    public class TurretStore : MonoBehaviour
    {
        public TowerStaticData selectedTurret;    // Currently selected turret for purchase
        public Transform[] spawnPoints;      // Array of spawn points where the turret can be created

        private Transform selectedSpawnPoint; // The selected spawn point for turret creation

        public void SelectTurret(TowerStaticData turret)
        {
            selectedTurret = turret;
        }

        public void SelectSpawnPoint(int spawnPointIndex)
        {
            if (spawnPointIndex < 0 || spawnPointIndex >= spawnPoints.Length)
            {
                Debug.LogError("Invalid spawn point index!");
                return;
            }

            selectedSpawnPoint = spawnPoints[spawnPointIndex];
        }

        public void PurchaseTurret()
        {
            if (selectedTurret == null)
            {
                Debug.LogError("No turret selected for purchase!");
                return;
            }

            if (selectedSpawnPoint == null)
            {
                Debug.LogError("No spawn point selected for turret creation!");
                return;
            }

            // Perform checks for purchasing conditions (e.g., available currency, player level, etc.)
            // ...

            // Purchase successful, create the turret at the selected spawn point
            CreateTurret(selectedSpawnPoint.position);
        }

        private void CreateTurret(Vector3 position)
        {
            if (selectedTurret == null)
            {
                Debug.LogError("Turret is not selected!");
                return;
            }

            // Instantiate the turret prefab at the specified position
            GameObject newTurret = Instantiate(selectedTurret.Prefab, position, Quaternion.identity);

            // Optionally, you can customize the new turret's properties or add components here
        }
    }
}