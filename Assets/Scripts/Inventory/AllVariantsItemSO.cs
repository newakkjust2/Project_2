using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "AllVariantSO", menuName = "Create Item Collection")]
    public class AllVariantsItemSO : ScriptableObject
    {
        public List<string> keys = new List<string>();
        public List<ItemSO> values = new List<ItemSO>();
        
        public void Refresh()
        {
            if (values.Count > 0)
            {
                foreach (var value in values)
                {
                    if (value == null)
                    {
                        values.Remove(value);
                        Refresh();
                        break;
                    }
                }
                keys.Clear();
                foreach (var value in values)
                {
                    keys.Add(value.ItemName);
                }
            }
        }
    }
