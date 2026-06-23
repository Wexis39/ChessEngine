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
            isFirstMove = true;
            validPosArr = new string[2];
        }
        public bool isFirstMove { get; set; } = true;
        public override void GetValidMoves()
        {
            moveCheck();
        }
        public void moveCheck()
        {
            string move1=null;
            string move2=null;
            if (pieceColor == pieceColorEnum.Black)
            {
                if (posRow == 1)
                {
                    move1 = (((posRow + 1).ToString()) + (posCol.ToString()));
                    move2 = (((posRow + 2).ToString()) + (posCol.ToString()));
                }
                else
                {
                    move1 = (((posRow + 1).ToString()) + (posCol.ToString()));
                }

            }
            else if (pieceColor == pieceColorEnum.White)
            {
                if (posRow == 6)
                {
                    move1 = (((posRow - 1).ToString()) + (posCol.ToString()));
                    move2 = (((posRow - 2).ToString()) + (posCol.ToString()));
                }
                else
                {
                    move1 = (((posRow - 1).ToString()) + (posCol.ToString()));
                }
            }
            validPosArr[0] = move1;
            validPosArr[1] = move2;
        }
    }
}
