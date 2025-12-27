using System.Collections.Generic;
using UnityEngine;

namespace BitWar
{
    [CreateAssetMenu(menuName = "BitWar/Event Database")]
    public class EventDatabase : ScriptableObject
    {
        public List<EventDefinition> Events = new List<EventDefinition>();

        public EventDefinition GetById(string id)
        {
            return Events.Find(evt => evt.Id == id);
        }
    }
}
