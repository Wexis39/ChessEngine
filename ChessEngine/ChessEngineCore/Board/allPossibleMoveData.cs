using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngine.ChessEngineCore.Board
{
    public static class allPossibleMoveData
    {
        public static List<string> allValidMovesWhite;
        public static List<string> allCapturesMovesWhite;
        public static List<string> allValidMovesBlack;
        public static List<string> allCapturesMovesBlack;
        public static Piece[,] tempBoardData;
        public static void calculatePossibeMoves()
        {
            allValidMovesWhite = new List<string>();
            allCapturesMovesWhite = new List<string>();
            allValidMovesBlack = new List<string>();
            allCapturesMovesBlack = new List<string>();
            tempBoardData = boardData.piecesBoardData;
            for(int i=0; i <8; i++)
            {
                for(int j=0; j<8; j++)
                {
                    if(tempBoardData[i, j] != null)
                    {
                        if (tempBoardData[i, j].pieceColor == Piece.pieceColorEnum.White)
                        {
                            tempBoardData[i, j].allPossibleMoves();
                            allValidMovesWhite.AddRange(tempBoardData[i, j].validPosArr);
                            allCapturesMovesWhite.AddRange(tempBoardData[i, j].capturesPosArr);
                        }
                        else if (tempBoardData[i, j].pieceColor == Piece.pieceColorEnum.Black)
                        {
                            tempBoardData[i, j].allPossibleMoves();
                            allValidMovesBlack.AddRange(tempBoardData[i, j].validPosArr);
                            allCapturesMovesBlack.AddRange(tempBoardData[i, j].capturesPosArr);
                        }
                    }
                }
            }
        }
        //--- FOR IN CHECK ---
        public static bool controlNewPosCheck(Piece[,] tempBoard,Piece.pieceColorEnum color)
        {

        }
    }
}
