using UnityEngine;

namespace Character
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private Inventory playerInventory;
        
        private void Awake()
        {
            if (GlobalInventory.playerInventoryInstance == null)
            {
                GlobalInventory.playerInventoryInstance = playerInventory;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}