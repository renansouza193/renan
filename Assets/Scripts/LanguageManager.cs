using System.Collections.Generic;
using UnityEngine;

namespace BitWar
{
    public class LanguageManager : MonoBehaviour
    {
        [SerializeField] private string defaultLanguage = "pt-BR";
        [SerializeField] private string resourceFolder = "Localization";

        private readonly Dictionary<string, string> strings = new Dictionary<string, string>();
        private string currentLanguage;

        public string CurrentLanguage => currentLanguage;

        private void Awake()
        {
            SetLanguage(PlayerPrefs.GetString("BitWar.Language", defaultLanguage));
        }

        public void SetLanguage(string languageCode)
        {
            currentLanguage = languageCode;
            PlayerPrefs.SetString("BitWar.Language", languageCode);
            PlayerPrefs.Save();

            strings.Clear();

            TextAsset jsonAsset = Resources.Load<TextAsset>($"{resourceFolder}/{languageCode}");
            if (jsonAsset == null)
            {
                Debug.LogWarning($"BitWar: localization not found for {languageCode}");
                return;
            }

            LocalizationEntryList wrapper = JsonUtility.FromJson<LocalizationEntryList>(jsonAsset.text);
            if (wrapper?.Entries == null)
            {
                Debug.LogWarning("BitWar: failed to parse localization data.");
                return;
            }

            foreach (LocalizationEntry entry in wrapper.Entries)
            {
                strings[entry.Key] = entry.Value;
            }
        }

        public string Get(string key)
        {
            return strings.TryGetValue(key, out string value) ? value : key;
        }

        [System.Serializable]
        private class LocalizationEntryList
        {
            public LocalizationEntry[] Entries;
        }
    }
}
