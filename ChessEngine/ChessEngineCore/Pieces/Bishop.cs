using ChessEngine.ChessEngineCore.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngine.ChessEngineCore.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(pieceColorEnum pieceColorParam) : base(pieceColorParam)
        {
            pieceType = pieceTypeEnum.Bishop;
        }
        public override void allPossibleMoves(Piece[,] board = null)
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
            int oldPosCol = posCol;
            int oldPosRow = posRow;
            int newPosCol = posCol;
            int newPosRow = posRow;
            while(newPosRow > 0 && newPosCol < 7)
            {
                newPosRow -= 1;
                newPosCol += 1;
                if (boardData.isBlockingAnyPiece(newPosRow, newPosCol))
                {
                    validPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                }
                else
                {
                    if (sameColorBlock(newPosRow, newPosCol))
                    {
                        capturesPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                    }
                    break;
                }
            }
        }
        public void checkUpLeft()
        {
            int oldPosCol = posCol;
            int oldPosRow = posRow;
            int newPosCol = posCol;
            int newPosRow = posRow;
            while (newPosRow > 0 && newPosCol > 0)
            {
                newPosRow -= 1;
                newPosCol -= 1;
                if (boardData.isBlockingAnyPiece(newPosRow, newPosCol))
                {
                    validPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                }
                else
                {
                    if (sameColorBlock(newPosRow, newPosCol))
                    {
                        capturesPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                    }
                    break;
                }
            }
        }
        public void checkDownRight()
        {
            int oldPosCol = posCol;
            int oldPosRow = posRow;
            int newPosCol = posCol;
            int newPosRow = posRow;
            while (newPosRow < 7 && newPosCol < 7)
            {
                newPosRow += 1;
                newPosCol += 1;
                if (boardData.isBlockingAnyPiece(newPosRow, newPosCol))
                {
                    validPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                }
                else
                {
                    if (sameColorBlock(newPosRow, newPosCol))
                    {
                        capturesPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                    }
                    break;
                }
            }
        }
        public void checkDownLeft()
        {
            int oldPosCol = posCol;
            int oldPosRow = posRow;
            int newPosCol = posCol;
            int newPosRow = posRow;
            while (newPosRow < 7 && newPosCol > 0)
            {
                newPosRow += 1;
                newPosCol -= 1;
                if (boardData.isBlockingAnyPiece(newPosRow, newPosCol))
                {
                    validPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                }
                else
                {
                    if (sameColorBlock(newPosRow, newPosCol))
                    {
                        capturesPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                    }
                    break;
                }
            }
        }
    }
}
