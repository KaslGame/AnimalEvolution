using CommonInterfaces;
using Map;
using System;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace ItemScripts
{
    public class MapStorage : ISubscribable
    {
        private List<NameScene> _mapNames;

        public MapStorage(List<NameScene> paidMapNames)
        {
            _mapNames = paidMapNames ?? throw new ArgumentNullException(nameof(paidMapNames));
        }

        public void Subscribe()
        {
            YG2.onDefaultSaves += SetDefault;
        }

        public void Unsubscribe()
        {
            YG2.onDefaultSaves -= SetDefault;
        }

        public int GetLevelMap()
        {
            return YG2.saves.LevelMap;
        }

        public bool TryBuyMap(NameScene name)
        {
            List<PaidMapData> paidMapDatas = YG2.saves.PaidMaps;

            if (paidMapDatas.Count == 0)
                Debug.Log("MAPs = 0");

            foreach (var mapData in paidMapDatas)
            {
                if (mapData.Name == name)
                {
                    mapData.IsPurchased = true;
                    YG2.SaveProgress();

                    return true;
                }
            }

            return false;
        }

        public bool IsMapPurchased(NameScene name)
        {
            List<PaidMapData> paidMapDatas = YG2.saves.PaidMaps;

            foreach (var mapData in paidMapDatas)
            {
                if (mapData.Name == name)
                    return mapData.IsPurchased;
            }

            return false;
        }

        private void SetDefault()
        {
            List<PaidMapData> paidMapDatas = YG2.saves.PaidMaps;

            paidMapDatas.Clear();

            for (int i = 0; i < _mapNames.Count; i++)
            {
                var newPaidMap = new PaidMapData(_mapNames[i], false);

                paidMapDatas.Add(newPaidMap);
            }

            if (YG2.isSDKEnabled)
                YG2.SaveProgress();
        }
    }
}