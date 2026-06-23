using ChessEngine.ChessEngineCore.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessEngine.ChessEngineCore.Board
{
    public static class boardData
    {
        public static Piece[,] piecesBoardData = new Piece[8,8];
        //---BUTTON---
        public static string selectedSquareIndex = null;
        public static Button selectedSquareButton = null;
        //---PIECE---
        public static string selectedPieceIndex = null;
        public static Piece selectedPiece = null;
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
