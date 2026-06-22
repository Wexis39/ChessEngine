using ChessEngine.ChessEngineCore.Board;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessEngine.ChessEngineCore
{
    public static class initChessEngine
    {
        public static void _initChessEngine(Form frm)
        {
            createTopMenu._createTopMenu(frm);
            formSettings._formSettings(frm);
            createChessBoard._createChessBoard(frm);
            boardData.initBoardData();
            placePiecesDefaultPosition._placePiecesDefaultPosition();
            updateChessBoardUI._updateChessBoardUI();
        }
    }
}
