using System;
using UnityEngine;

namespace BitWar
{
    [Serializable]
    public class EventDefinition
    {
        public string Id;
        public string Title;
        [TextArea(2, 4)]
        public string Description;
        public string Category;
        public int MoraleDelta;
        public int SupplyDelta;
        public int TerritoryDelta;
    }
}
