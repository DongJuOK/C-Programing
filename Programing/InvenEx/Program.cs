using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InvenEx
{
    public class Inven<T> where T : Item
    {
        T[] arrayItem;
        int selectNum;
        int x;
        int y;

        public Inven(int _length)
        {
            if (_length < 10)
            {
                _length = 10;
            }
            else if (_length > 50)
            {
                _length = 50;
            }
            selectNum = 0;
            arrayItem = new T[_length];
        }

        public Inven(int _x, int _y)
        {
            x = _x;
            y = _y;
            int _length = _x * _y;
            selectNum = 0;
            arrayItem = new T[_length];
        }


        public void AddItem(T _item)
        {
            for (int i = 0; i < arrayItem.Length; i++)
            {
                if (arrayItem[i] == null)
                {
                    arrayItem[i] = _item;
                    break;
                }
            }
        }

        public void AddItemAt(T _item, int _index)
        {

            if (_index < 0 || _index > arrayItem.Length)
            {
                Console.WriteLine($"입력한 인데스값이 : {_index} 자동으로 들어갑니다.");
                AddItem(_item);
            }
            else
            {
                for (int i = _index; i < arrayItem.Length; i++)
                {
                    if (arrayItem[i] == null)
                    {
                        arrayItem[i] = _item;
                        break;
                    }
                }
            }
        }

        public void RemoveItem()
        {
            arrayItem[selectNum] = null;
        }
        public void RemoveAllItem()
        {
            for (int i = 0; i < arrayItem.Length; i++)
            {
                if (arrayItem[i] != null)
                    arrayItem[i] = null;
            }
        }


        public void ShowInven()
        {
            for (int i = 0; i < arrayItem.Length; i++)
            {
                if (i != 0 && i % x == 0)
                    Console.WriteLine();

                if (i == selectNum)
                {
                    if (arrayItem[i] != null)
                        Console.Write("★");
                    else
                        Console.Write("☆");
                }
                else
                {
                    if (arrayItem[i] != null)
                        Console.Write("●");
                    else
                        Console.Write("○");
                }
            }
            Console.WriteLine();
        }

        public void SelectFunc()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            Console.Clear();

            switch (keyInfo.Key)
            {
                case ConsoleKey.A:
                    if (selectNum > 0)
                        selectNum--;
                    break;

                case ConsoleKey.D:
                    if (selectNum < arrayItem.Length - 1)
                        selectNum++;
                    break;

                case ConsoleKey.R:
                    RemoveItem();
                    break;

                default:
                    break;
            }
        }

        public void ShowItemInfo()
        {
            if (arrayItem[selectNum] != null)
            {
                Console.WriteLine("아이템 이름 : " + arrayItem[selectNum].Name);
                Console.WriteLine("아이템 가격 : " + arrayItem[selectNum].Price);
            }
            else
            {
                Console.WriteLine("빈공간");
            }

        }
        public void ShowAllItmeInfo()
        {
            for (int i = 0; i < arrayItem.Length; i++)
            {

            }
        }

    }

    public class Program
    {
        static void Main(string[] args)
        {
            //Inven<CashItem> cashInven = new Inven<CashItem>(5, 4);
            Inven<PlayerPet> cashInven = new Inven<PlayerPet>(5, 4);

            List<int> listA = new List<int>();

            PlayerPet itemA = new PlayerPet("단검", 100);
            PlayerPet itemB = new PlayerPet("장창", 500);
            PlayerPet itemC = new PlayerPet("지팡이", 1000);
            PlayerPet itemD = new PlayerPet("대검", 2500);
            PlayerPet itemE = new PlayerPet("방패", 700);


            cashInven.AddItem(itemA);
            cashInven.AddItem(itemB);
            cashInven.AddItem(itemC);
            cashInven.AddItemAt(itemD, 11);
            cashInven.AddItemAt(itemE, 11);

            while (true)
            {
                cashInven.ShowInven();
                cashInven.ShowItemInfo();
                cashInven.SelectFunc();
            }
        }
    }
}

