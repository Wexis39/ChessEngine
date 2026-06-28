using ChessEngine.ChessEngineCore.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngine.ChessEngineCore.Pieces
{
    public class Rook : Piece
    {
        public Rook(pieceColorEnum pieceColorParam) : base(pieceColorParam)
        {
            pieceType = pieceTypeEnum.Rook;
        }
        public override void allPossibleMoves(Piece[,] board = null)
        {
            capturesPosArr = new List<string>();
            GetValidMoves();
        }
        public override void GetValidMoves()
        {
            validPosArr = new List<string>();
            checkColRight();
            checkColLeft();
            checkRowUp();
            checkRowDown();
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
                if (boardData.isBlockingAnyPiece(newPos,posCol))
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
                    if(sameColorBlock(newPos, posCol))
                    {
                        capturesPosArr.Add(newPos.ToString() + posCol.ToString());
                    }
                    break;
                }
            }
        }
    }
}
