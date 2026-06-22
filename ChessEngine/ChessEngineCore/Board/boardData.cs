using ChessEngine.ChessEngineCore.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngine.ChessEngineCore.Board
{
    public static class boardData
    {
        public static Piece[,] piecesBoardData = new Piece[8,8];
        public static void initBoardData()
        {
            for(int i=0; i<8; i++)
            {
                for(int j=0; j<8; j++)
                {
                    piecesBoardData[i,j] = null;
                }
            }
        }
    }
}
