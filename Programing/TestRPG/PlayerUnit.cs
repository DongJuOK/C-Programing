using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRPG
{
    public class PlayerUnit : Unit, IMoveController
    {
        public void InputMove(ConsoleKeyInfo _keyInfo, int _sizeX, int _sizeY)
        {
            switch (_keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    {
                        MoveUp();
                        break;
                    }
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    {
                        MoveDown();
                        break;
                    }
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    {
                        MoveLeft();
                        break;
                    }
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    {
                        MoveRight();
                        break;
                    }
                default:
                    break;
            }
        }

        public void MoveFunc(int _dtx, int _dty)
        {
            CurX += _dtx;
            CurY += _dty;
        }
    }
}
