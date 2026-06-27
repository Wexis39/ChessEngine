using ChessEngine.ChessEngineCore.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngine.ChessEngineCore.Pieces
{
    public class King : Piece
    {
        public King(pieceColorEnum pieceColorParam) : base(pieceColorParam)
        {
            pieceType = pieceTypeEnum.King;
        }
        public override void allPossibleMoves()
        {
            capturesPosArr = new List<string>();
            GetValidMoves();
        }
        public override void GetValidMoves()
        {
            validPosArr = new List<string>();
            sendAllMovesToFunc();
        }
        public void sendAllMovesToFunc()
        {
            checkMoveFunction(-1,0);
            checkMoveFunction(-1,1);
            checkMoveFunction(0,1);
            checkMoveFunction(1,1);
            checkMoveFunction(1,0);
            checkMoveFunction(1,-1);
            checkMoveFunction(0,-1);
            checkMoveFunction(-1,-1);
        }
        public void checkMoveFunction(int indexRow,int indexCol)
        {
            int newRow = posRow + indexRow;
            int newCol = posCol + indexCol;
            if ((newRow<=7&&newRow>=0)&&(newCol<=7&&newCol>=0))
            if (boardData.isBlockingAnyPiece(newRow, newCol))
            {
                validPosArr.Add(newRow.ToString() + newCol.ToString());
            }
            else
            {
                if (sameColorBlock(newRow, newCol))
                {
                    capturesPosArr.Add(newRow.ToString() + newCol.ToString());
                }
            }
        }
    }
}
