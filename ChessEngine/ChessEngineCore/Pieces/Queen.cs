using ChessEngine.ChessEngineCore.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngine.ChessEngineCore.Pieces
{
    public class Queen : Piece
    {
        public Queen(pieceColorEnum pieceColorParam) : base(pieceColorParam)
        {
            pieceType = pieceTypeEnum.Queen;
        }
        public override void allPossibleMoves(Piece[,] board = null)
        {
            capturesPosArr = new List<string>();
            GetValidMoves();
        }
        public override void GetValidMoves()
        {
            validPosArr = new List<string>();
            crossMoves();
            lineMoves();
        }
        public void lineMoves()
        {
            checkColRight();
            checkColLeft();
            checkRowUp();
            checkRowDown();
        }
        public void crossMoves()
        {
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
            while (newPosRow > 0 && newPosCol < 7)
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
        public void checkColRight()
        {
            int oldPosCol = posCol;
            int newPos = posCol;
            for (int i = oldPosCol; i < 7; i++)
            {
                newPos += 1;
                if (boardData.isBlockingAnyPiece(posRow, newPos))
                {
                    validPosArr.Add(posRow.ToString() + newPos.ToString());
                }
                else
                {
                    if (sameColorBlock(posRow, newPos))
                    {
                        capturesPosArr.Add(posRow.ToString() + newPos.ToString());
                    }
                    break;
                }
            }
        }
        public void checkColLeft()
        {
            int oldPosCol = posCol;
            int newPos = posCol;
            for (int i = oldPosCol; i > 0; i--)
            {
                newPos -= 1;
                if (boardData.isBlockingAnyPiece(posRow, newPos))
                {
                    validPosArr.Add(posRow.ToString() + newPos.ToString());
                }
                else
                {
                    if (sameColorBlock(posRow, newPos))
                    {
                        capturesPosArr.Add(posRow.ToString() + newPos.ToString());
                    }
                    break;
                }
            }
        }
        public void checkRowUp()
        {
            int oldPosCol = posRow;
            int newPos = posRow;
            for (int i = oldPosCol; i < 7; i++)
            {
                newPos += 1;
                if (boardData.isBlockingAnyPiece(newPos, posCol))
                {
                    validPosArr.Add(newPos.ToString() + posCol.ToString());
                }
                else
                {
                    if (sameColorBlock(newPos, posCol))
                    {
                        capturesPosArr.Add(newPos.ToString() + posCol.ToString());
                    }
                    break;
                }
            }
        }
        public void checkRowDown()
        {
            int oldPosCol = posRow;
            int newPos = posRow;
            for (int i = oldPosCol; i > 0; i--)
            {
                newPos -= 1;
                if (boardData.isBlockingAnyPiece(newPos, posCol))
                {
                    validPosArr.Add(newPos.ToString() + posCol.ToString());
                }
                else
                {
                    if (sameColorBlock(newPos, posCol))
                    {
                        capturesPosArr.Add(newPos.ToString() + posCol.ToString());
                    }
                    break;
                }
            }
        }
    }
}
