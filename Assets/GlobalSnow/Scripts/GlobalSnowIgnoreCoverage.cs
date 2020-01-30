using UnityEngine;
using System.Collections;

namespace GlobalSnowEffect
{
    [ExecuteInEditMode]
    public class GlobalSnowIgnoreCoverage : MonoBehaviour
    {
        GlobalSnow snow;

        [HideInInspector]
        public int layer;

        void OnEnable()
        {
            snow = GlobalSnow.instance;
            AddToExclusionList();
        }

        void Update()
        {
            if (snow == null)
            {
                snow = GlobalSnow.instance;
                AddToExclusionList();
            }
            this.layer = gameObject.layer;
        }

        private void OnDisable()
        {
            if (snow != null)
                snow.UseGameObject(this);
        }


        void AddToExclusionList()
        {
            if (snow != null)
                snow.IgnoreGameObject(this);
        }
    }
}