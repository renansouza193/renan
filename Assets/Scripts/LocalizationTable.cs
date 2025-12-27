using System.Collections.Generic;
using UnityEngine;

namespace BitWar
{
    [CreateAssetMenu(menuName = "BitWar/Localization Table")]
    public class LocalizationTable : ScriptableObject
    {
        public string LanguageCode = "pt-BR";
        public List<LocalizationEntry> Entries = new List<LocalizationEntry>();

        public string Get(string key)
        {
            LocalizationEntry entry = Entries.Find(item => item.Key == key);
            return entry != null ? entry.Value : key;
        }
    }
}
