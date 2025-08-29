using CommonInterfaces;
using System.Collections.Generic;
using System;
using YG;

namespace ItemScripts
{
    public class MapStorage : ISubscribable
    {
        private List<string> _mapNames;

        public MapStorage(List<string> paidMapNames)
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

        public bool TryBuyMap(string name)
        {
            List<PaidMapData> paidMapDatas = YG2.saves.PaidMaps;

            foreach (var mapData in paidMapDatas)
            {
                if (mapData.Name == name)
                {
                    mapData.IsPurchased = true;
                    return true;
                }
            }

            return false;
        }

        public bool IsMapPurchased(string name)
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

            YG2.SaveProgress();
        }
    }
}