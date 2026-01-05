using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRPG
{
    public enum Map
    {
        start,
        town,
        river
    }
    
    public class StageMap
    {
        public int[,] m_seat;  
    }

    public class WorldMap
    {
        private Dictionary<Map, StageMap> m_dicMap = new Dictionary<Map, StageMap>();

        private Map m_curMap;
        private StageMap m_curStageMap;

        public WorldMap(Map _map = Map.start)
        {
            InitMap(_map);
        }

        private void InitMap(Map _map)
        {
            StageMap startMap = new StageMap();
            startMap.m_seat = new int[,]
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            StageMap townMap = new StageMap();
            townMap.m_seat = new int[,]
            {
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
            };

            StageMap riverMap = new StageMap();
            riverMap.m_seat = new int[,]
            {
                { 0, 0, 0, 2, 2, 0, 0, 0 },
                { 0, 0, 0, 3, 3, 0, 0, 0 },
                { 0, 0, 0, 2, 2, 0, 0, 0 },
                { 0, 0, 0, 3, 3, 0, 0, 0 },
                { 0, 0, 0, 2, 2, 0, 0, 0 },
                { 0, 0, 0, 3, 3, 0, 0, 0 },
                { 0, 0, 0, 2, 2, 0, 0, 0 },
                { 0, 0, 0, 3, 3, 0, 0, 0 },
            };

            m_dicMap.Add(Map.start, startMap);
            m_dicMap.Add(Map.town, townMap);
            m_dicMap.Add(Map.river, riverMap);

            SetCurMap(_map);
        }

        public void SetCurMap(Map _map)
        {
            if (m_dicMap.TryGetValue(Map.start, out m_curStageMap))
            {
                m_curMap = _map;
            }
            else
            {
                Console.WriteLine("처음 초기화 하는 부분에서 맵을 가져오다가 실패했습니다.");
            }
        }

        private int[,] GetMap(Map _map)
        {
            StageMap getMap;
            if (m_dicMap.TryGetValue(_map, out getMap))
            {
                return getMap.m_seat;
            }

            // 맵을 제대로 전달하지 못한 경우
            return null;
        }

        public void ShowScreenMap(Unit _player)
        {
            int[,] curMap = GetMap(m_curMap);

            for (int y = 0; y < curMap.GetLength(0); y++)
            {
                for (int x = 0; x < curMap.GetLength(1); x++)
                {
                    if (_player.CurX == x && _player.CurY == y)
                    {
                        Console.Write("P ");
                    }
                    else if (curMap[y, x] == 0)
                    {
                        Console.Write("' ");
                    }
                    else if (curMap[y, x] == 1)
                    {
                        Console.Write("+ ");
                    }
                    else if (curMap[y, x] == 2)
                    {
                        Console.Write("/ ");
                    }
                    else if (curMap[y, x] == 3)
                    {
                        Console.Write("\\ ");
                    }
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// 현재 맵 사이즈를 가져오는 메서드
        /// </summary>
        /// <param name="dimension">0과 1만 넣으세요</param>
        /// <returns></returns>
        public int GetCurMapSize(int dimension)
        {
            return m_curStageMap.m_seat.GetLength(dimension);
        }
    }
}
