using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Omok
{
    public class Omok
    {
        private int[,] m_seat;
        private int m_size;
        public int Size
        {
            get { return m_size; }
        }
        private int m_curX;
        public int CurX
        {
            get { return m_curX; }
            set 
            { 
                m_curX = value;
                
                if (m_curX < 0)
                {
                    m_curX = 0;
                }
                else if (m_curX >= m_size - 1)
                {
                    m_curX = m_size - 1;
                }
            }
        }
        private int m_curY;
        public int CurY
        {
            get { return m_curY; }
            set
            { 
                m_curY = value;

                if (m_curY < 0)
                {
                    m_curY = 0;
                }
                else if (m_curY >= m_size - 1)
                {
                    m_curY = m_size - 1;
                }
            }
        }

        private bool m_isBlackTurn;
        private bool m_isPlaying;
        public bool IsPlaying
        {
            get { return m_isPlaying; }
        }

        public Omok(int _size = 19)
        {
            if (_size < 7)
            {
                _size = 7;
            }
            else if (_size > 19)
            {
                _size = 19;
            }

            m_seat = new int[_size, _size];
            m_size = _size;

            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    m_seat[y, x] = 0;
                }
            }

            CurX = _size / 2;
            CurY = _size / 2;

            m_isBlackTurn = true;
            m_isPlaying = true;
        }

        public void ShowScreen()
        {
            Console.Clear();

            for (int y = 0; y < m_seat.GetLength(0); y++)
            {
                for (int x = 0; x < m_seat.GetLength(1); x++)
                {
                    if (y == CurY && x == CurX)
                    {
                        Console.Write("C");
                    }
                    else if (m_seat[y, x] == 1)
                    {
                        Console.Write("B");
                    }
                    else if (m_seat[y, x] == 2)
                    {
                        Console.Write("W");
                    }
                    else
                    {
                        Console.Write("'");
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            if (m_isBlackTurn)
            {
                Console.WriteLine("흑돌 턴");
            }
            else
            {
                Console.WriteLine("백돌 턴");
            }
        }

        public void Input()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    CurY--;
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    CurY++;
                    break;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    CurX++;
                    break;

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    CurX--;
                    break;

                case ConsoleKey.Spacebar:
                    InputStone();
                    break;

                default:
                    break;
            }
        }

        public void InputStone()
        {
            if (m_seat[CurY, CurX] == 0)
            {
                if (m_isBlackTurn)
                {
                    m_seat[CurY, CurX] = 1;
                }
                else
                {
                    m_seat[CurY, CurX] = 2;
                }

                if (!RuleCheck())
                {
                    m_isBlackTurn = !m_isBlackTurn;
                }
                else
                {
                    m_isPlaying = false;
                    Console.WriteLine("승리!");
                }
            }
        }

        public bool RuleCheck()
        {
            int count = 1;
            int x = CurX;
            int y = CurY;

            int checkNum = m_seat[CurY, CurX];

            for (int i = 1; i <= 4; i++)
            {
                int xDt = CurX - i;

                if (xDt < 0)
                {
                    break;
                }

                if (m_seat[y, xDt] == checkNum)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 4; i++)
            {
                int xDt = CurX + i;

                if (xDt >= m_size)
                {
                    break;
                }

                if (m_seat[y, xDt] == checkNum)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 4; i++)
            {
                int yDt = CurY - i;

                if (yDt < 0)
                {
                    break;
                }

                if (m_seat[yDt, x] == checkNum)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 4; i++)
            {
                int yDt = CurY + i;

                if (yDt >= m_size)
                {
                    break;
                }

                if (m_seat[yDt, x] == checkNum)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 4; i++)
            {
                int xDt = CurX + i;
                int yDt = CurY - i;

                if (xDt < 0 || yDt < 0 || xDt >= m_size || yDt >= m_size)
                {
                    break;
                }

                if (m_seat[yDt, xDt] == checkNum)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 4; i++)
            {
                int xDt = CurX - i;
                int yDt = CurY + i;

                if (xDt < 0 || yDt < 0 || xDt >= m_size || yDt >= m_size)
                {
                    break;
                }

                if (m_seat[yDt, xDt] == checkNum)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 4; i++)
            {
                int xDt = CurX - i;
                int yDt = CurY - i;

                if (xDt < 0 || yDt < 0 || xDt >= m_size || yDt >= m_size)
                {
                    break;
                }

                if (m_seat[yDt, xDt] == checkNum)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= 4; i++)
            {
                int xDt = CurX + i;
                int yDt = CurY + i;

                if (xDt < 0 || yDt < 0 || xDt >= m_size || yDt >= m_size)
                {
                    break;
                }

                if (m_seat[yDt, xDt] == checkNum)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count >= 5;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Omok omok = new Omok(13);

            while(omok.IsPlaying)
            {
                omok.ShowScreen();
                omok.Input();
            }
        }
    }
}

// 1. 오목판 만들기 - 2차원 배열
// 2. 가운데 커서 두기
// 3. 커서 이동
// 4. 커서가 맵 밖으로 탈출하는거 막기
// 5. 흑돌 백돌
// 6. 흑돌 백돌 위치 중복 방지
// 7. 룰 정리
//    - 가로 5개, 세로 5개, 대각선 5개