using ChessEngine.ChessEngineCore.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessEngine.ChessEngineCore.Piece;

namespace ChessEngine.ChessEngineCore.Board
{
    public static class placePiecesDefaultPosition
    {
        public static void _placePiecesDefaultPosition()
        {
            createBlackPawns();
        }
        public static void createBlackPawns()
        {
            for (int i = 0; i < 8; i++)
            {
                Pawn pawn = new Pawn(pieceColorEnum.Black, pieceTypeEnum.Pawn);
                int pawnIndex=Convert.ToInt32($"1{i}");
                pawn.pieceId = pawnIndex;
                boardData.piecesBoardData[1, i] = pawn;
            }
        }
    }
}
