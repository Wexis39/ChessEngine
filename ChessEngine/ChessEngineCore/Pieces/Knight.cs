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
            checkLeftUp();
            checkLeftDown();
            checkRightUp();
            checkRightDown();
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
                    if (boardData.isBlockingAnyPiece(newPosRow, newPosCol))
                    {
                        validPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                    }
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
                    if (boardData.isBlockingAnyPiece(newPosRow, newPosCol))
                    {
                        validPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                    }
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
                    if (boardData.isBlockingAnyPiece(newPosRow, newPosCol))
                    {
                        validPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                    }
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
                    if (boardData.isBlockingAnyPiece(newPosRow, newPosCol))
                    {
                        validPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                    }
                }
            }
        }
        public void checkLeftUp()
        {
            int newPosCol = posCol - 2;
            int newPosRow = posRow -1;
            if (newPosCol >= 0 && newPosRow >= 0)
            {
                if (sameColorBlock(newPosRow, newPosCol))
                {
                    capturesPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                }
                else
                {
                    if (boardData.isBlockingAnyPiece(newPosRow, newPosCol))
                    {
                        validPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                    }
                }
            }
        }
        public void checkLeftDown()
        {
            int newPosCol = posCol - 2;
            int newPosRow = posRow + 1;
            if (newPosCol >= 0 && newPosRow <= 7)
            {
                if (sameColorBlock(newPosRow, newPosCol))
                {
                    capturesPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                }
                else
                {
                    if (boardData.isBlockingAnyPiece(newPosRow, newPosCol))
                    {
                        validPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                    }
                }
            }
        }
        public void checkRightUp()
        {
            int newPosCol = posCol + 2;
            int newPosRow = posRow - 1;
            if (newPosCol <= 7 && newPosRow >= 0)
            {
                if (sameColorBlock(newPosRow, newPosCol))
                {
                    capturesPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                }
                else
                {
                    if (boardData.isBlockingAnyPiece(newPosRow, newPosCol))
                    {
                        validPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                    }
                }
            }
        }
        public void checkRightDown()
        {
            int newPosCol = posCol + 2;
            int newPosRow = posRow + 1;
            if (newPosCol <= 7 && newPosRow <= 7)
            {
                if (sameColorBlock(newPosRow, newPosCol))
                {
                    capturesPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                }
                else
                {
                    if (boardData.isBlockingAnyPiece(newPosRow, newPosCol))
                    {
                        validPosArr.Add(newPosRow.ToString() + newPosCol.ToString());
                    }
                }
            }
        }
    }
}
