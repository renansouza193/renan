using System;
using UnityEngine;

namespace BitWar
{
    [Serializable]
    public class LocalizationEntry
    {
        public string Key;
        [TextArea(1, 4)]
        public string Value;
    }
}
