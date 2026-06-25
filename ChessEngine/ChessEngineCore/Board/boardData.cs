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
        public static bool isAnyPieceSelected = false;
        //---TURN---
        public static Piece.pieceColorEnum turnColor=Piece.pieceColorEnum.White;
        public static int whiteMoveCount = 0;
        public static int blackMoveCount = 0;
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
        public static bool isAnyDatasNull()
        {
            if(selectedSquareIndex==null || selectedSquareButton==null || selectedPieceIndex==null || selectedPiece == null)
            {
                return true;
            }
            return false;
        }
        public static void deleteByRowAndColId(int rowId,int colId)
        {
            piecesBoardData[rowId, colId] = null;
        }
        public static bool isBlockingAnyPiece(int x, int y)
        {
            if (piecesBoardData[x, y] == null){return true;}
            return false;
        }
        //---PAWN EN PASSANT PRIVATE----
        public static List<string> enPassantCapturesArr = new List<string>();
        public static void clearEnPassantCapturesArr()
        {
            if (enPassantCapturesArr.Count!=0)
            {
                string firstPos = enPassantCapturesArr[0];
                int posX = Convert.ToInt32(firstPos[0].ToString());
                int posY = Convert.ToInt32(firstPos[1].ToString());
                deleteByRowAndColId(posX, posY);
                enPassantCapturesArr = new List<string>();
            }
        }
    }
}
