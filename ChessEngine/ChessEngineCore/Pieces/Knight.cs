using ChessEngine.ChessEngineCore.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngine.ChessEngineCore.Pieces
{
    public class Knight : Piece
    {
        public Knight(pieceColorEnum pieceColorParam) : base(pieceColorParam)
        {
            pieceType = pieceTypeEnum.Knight;
        }
        public override void allPossibleMoves()
        {
            capturesPosArr = new List<string>();
            GetValidMoves();
        }
        public override void GetValidMoves()
        {
            validPosArr = new List<string>();
            checkUpRight();
            checkUpLeft();
            checkDownRight();
            checkDownLeft();
        }
        public void checkUpRight()
        {
            int newPosCol = posCol + 1;
            int newPosRow = posRow - 2;
            if (newPosCol <= 7 && newPosRow >= 0)
            {
                if(sameColorBlock(newPosRow, newPosCol))
                {
                    capturesPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                }
                else
                {
                    validPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                }
            }
        }
        public void checkUpLeft()
        {
            int newPosCol = posCol -1;
            int newPosRow = posRow - 2;
            if (newPosCol >= 0 && newPosRow >= 0)
            {
                if (sameColorBlock(newPosRow, newPosCol))
                {
                    capturesPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                }
                else
                {
                    validPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                }
            }
        }
        public void checkDownRight()
        {
            int newPosCol = posCol + 1;
            int newPosRow = posRow + 2;
            if (newPosCol <= 7 && newPosRow <= 7)
            {
                if (sameColorBlock(newPosRow, newPosCol))
                {
                    capturesPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                }
                else
                {
                    validPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                }
            }
        }
        public void checkDownLeft()
        {
            int newPosCol = posCol - 1;
            int newPosRow = posRow + 2;
            if (newPosCol >= 0 && newPosRow <= 7)
            {
                if (sameColorBlock(newPosRow, newPosCol))
                {
                    capturesPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                }
                else
                {
                    validPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                }
            }
        }
    }
}
