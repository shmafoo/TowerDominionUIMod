using System.Collections.Generic;
using Nvizzio.Game.GamePlay.DataStructure.Characters;
using Nvizzio.Game.GamePlay.DataStructure.Zones;
using Nvizzio.Game.GamePlay.GameEntities;
using Nvizzio.Game.GamePlay.Weapons;
using Nvizzio.Game.UI.Views;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Nvizzio.Game.UI.Tooltip
{
    public class UniversalTooltipTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
    {
        public delegate TooltipData GetTooltipData();

        [SerializeField] private float maxWidth;

        [SerializeField] private float offset;

        [SerializeField] private Color color;

        [SerializeField] private TooltipAlignment autoAlignment;

        public GetTooltipData getTooltipData;

        private bool active;

        public TooltipData TooltipData { get; set; }

        public TooltipStyle TooltipStyle { get; set; }

        public void SetActive(bool active)
        {
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }

        private void OnDisable()
        {
        }

        public bool HasKeyword(string description)
        {
            return false;
        }

        public List<string> GetKeywordDefinitions(string description)
        {
            return null;
        }

        public List<string> GetCharacterProperties(CharacterData data)
        {
            return null;
        }

        public List<string> GetWeaponProperties(WeaponData data, BulletEntity dummyBullet)
        {
            return null;
        }

        private string GetPropertyText(string titleKey, string descriptionKey, string arg0 = "", string arg1 = "")
        {
            return null;
        }

        public List<string> GetWeaponBaseStats(WeaponData data)
        {
            return null;
        }

        public List<string> GetWeaponLiveStats(Weapon weapon, WeaponData data, BulletEntity dummyBullet)
        {
            return null;
        }

        private float ApplyModifier(float value, float modifier)
        {
            return 0f;
        }

        private float Round(float value, int digits)
        {
            return 0f;
        }

        public string GetDiff(float baseValue, float modifiedValue, bool isPercentage = true)
        {
            return null;
        }

        public string GetUIText(string key)
        {
            return null;
        }
    }
}