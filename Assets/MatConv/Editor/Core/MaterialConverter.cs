using UnityEngine;

namespace MatConv
{
    public abstract class MaterialConverter
    {
        public abstract string Id { get; }

        public abstract Material Convert(Material material);
    }
}