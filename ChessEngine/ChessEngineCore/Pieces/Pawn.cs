using ChessEngine.ChessEngineCore.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngine.ChessEngineCore.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(pieceColorEnum pieceColorParam) : base(pieceColorParam)
        {
            pieceType = pieceTypeEnum.Pawn;
        }
        public bool isFirstMove { get; set; }
        public override void GetValidMoves()
        {
            validPosArr = new List<string>();
            capturesPosArr = new List<string>();
            makeMove();
            GetCaptures();
        }
        public override void GetCaptures()
        {
            int colorToNumber = pieceColor == pieceColorEnum.Black ? 1 : -1;
            if (((posRow + colorToNumber) <= 7 && (posRow + colorToNumber) >= 0))
            {
                if((posCol + 1) <= 7)
                {
                    if (boardData.piecesBoardData[(posRow + colorToNumber), (posCol + 1)] != null && sameColorBlock(posRow + colorToNumber, posCol + 1))
                    {
                        capturesPosArr.Add((posRow + colorToNumber).ToString() + (posCol + 1).ToString());
                    }
                }
                if((posCol - 1) >= 0)
                {
                    if (boardData.piecesBoardData[(posRow + colorToNumber), (posCol - 1)] != null && sameColorBlock(posRow + colorToNumber, posCol - 1))
                    {
                        capturesPosArr.Add((posRow + colorToNumber).ToString() + (posCol - 1).ToString());
                    }
                }
            }
        }
        public void makeMove()
        {
            if (pieceColor == pieceColorEnum.Black)
            {
                if (isFirstMoveCheck())
                {
                    moveCheck(1);
                    moveCheck(2);
                }
                else
                {
                    moveCheck(1);
                }
            }
            else if (pieceColor == pieceColorEnum.White)
            {
                if (isFirstMoveCheck())
                {
                    moveCheck(-1);
                    moveCheck(-2);
                }
                else
                {
                    moveCheck(-1);
                }
            }
        }
        public bool isFirstMoveCheck()
        {
            if (pieceColor == pieceColorEnum.White)
            {
                if (posRow == 6){return true;}
            }
            else if (pieceColor == pieceColorEnum.Black)
            {
                if (posRow == 1){return true;}
            }
            return false;
        }
        public void moveCheck(int moveStep)
        {
            if ((posRow + moveStep) <= 7 && (posRow + moveStep) >= 0)
            {
                int moveTwo = pieceColor == pieceColorEnum.Black ? 2 : -2;
                int moveOne = pieceColor == pieceColorEnum.Black ? 1 : -1;
                if (moveStep == moveTwo)
                {
                    if (boardData.piecesBoardData[(posRow + moveTwo), posCol] == null)
                    {
                        if (boardData.piecesBoardData[(posRow + moveOne), posCol] == null)
                        {
                            validPosArr.Add((posRow + moveTwo).ToString() + posCol.ToString());
                        }
                    }
                }
                else if (moveStep == moveOne)
                {
                    if (boardData.piecesBoardData[(posRow + moveOne), posCol] == null)
                    {
                        validPosArr.Add((posRow + moveOne).ToString() + posCol.ToString());
                    }
                }
            }
        }
    }
}
