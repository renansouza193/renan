using System.Collections.Generic;
using UnityEngine;

namespace BitWar
{
    public class EventDatabaseLoader : MonoBehaviour
    {
        [SerializeField] private string resourcePath = "Data/bitwar_events";
        [SerializeField] private EventDatabase eventDatabase;

        public EventDatabase Database => eventDatabase;

        private void Awake()
        {
            LoadFromResources();
        }

        public void LoadFromResources()
        {
            if (eventDatabase == null)
            {
                eventDatabase = ScriptableObject.CreateInstance<EventDatabase>();
            }

            TextAsset jsonAsset = Resources.Load<TextAsset>(resourcePath);
            if (jsonAsset == null)
            {
                Debug.LogWarning($"BitWar: missing event data at Resources/{resourcePath}.json");
                return;
            }

            EventDefinitionList wrapper = JsonUtility.FromJson<EventDefinitionList>(jsonAsset.text);
            if (wrapper?.Events == null)
            {
                Debug.LogWarning("BitWar: failed to parse event data.");
                return;
            }

            eventDatabase.Events = new List<EventDefinition>(wrapper.Events);
        }

        [System.Serializable]
        private class EventDefinitionList
        {
            public EventDefinition[] Events;
        }
    }
}
