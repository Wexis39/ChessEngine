using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessEngine.ChessEngineCore.Piece;

namespace ChessEngine.ChessEngineCore.Board
{
    public static class chessLogicFuncs
    {
        public static void isKingInCheck()
        {
            if (boardData.turnColor == pieceColorEnum.Black)
            {
                if (allPossibleMoveData.allCapturesMovesWhite.Contains(boardData.blackKingIndexX.ToString() + boardData.blackKingIndexY.ToString()))
                {
                    inCheckBlackKing = true;
                }
                else
                {
                    inCheckBlackKing = false;
                }
            }
            else if (boardData.turnColor == pieceColorEnum.White)
            {
                if (allPossibleMoveData.allCapturesMovesBlack.Contains(boardData.whiteKingIndexX.ToString() + boardData.whiteKingIndexY.ToString()))
                {
                    inCheckWhiteKing = true;
                }
                else
                {
                    inCheckWhiteKing = false;
                }
            }

        }
        public static void kingInCheckMoves(Piece piece)
        {
            controlValids(piece);
        }
        public static void controlValids(Piece piece)
        {
            Piece[,] tempBoard;
            List<string> currentValidMoves = piece.validPosArr;
            string piecePosXY = piece.pieceId;
            int piecePosX = Convert.ToInt32(piecePosXY[0].ToString());
            int piecePosY = Convert.ToInt32(piecePosXY[1].ToString());
            for (int i=0; i<currentValidMoves.Count; i++)
            {
                tempBoard = boardData.piecesBoardData;
                string validPosXY= currentValidMoves[i];
                int validPosX = Convert.ToInt32(validPosXY[0].ToString());
                int validPosY = Convert.ToInt32(validPosXY[1].ToString());
                piece.pieceId = validPosXY;
                tempBoard[validPosX, validPosY] = piece;
                tempBoard[piecePosX, piecePosY] = null;
                printTable(tempBoard);
            }
        }

        public static void printTable(Piece[,] board)
        {
            Console.WriteLine("------BOARD------");
            foreach (var item in board)
            {
                if (item != null)
                {

                    Console.WriteLine("item id: "+item.pieceId+" item type: "+item.pieceType);
                }
            }
        }

        public static bool inCheckWhiteKing = false;
        public static bool inCheckBlackKing = false;
        public static bool sameColorBlockLogic(int posX, int posY)
        {
            if (boardData.piecesBoardData[posX, posY] != null)
            {
                pieceColorEnum moveLocationColor = boardData.piecesBoardData[posX, posY].pieceColor;
                if (moveLocationColor != boardData.turnColor)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
