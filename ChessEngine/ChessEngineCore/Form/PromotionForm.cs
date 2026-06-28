using System;
using System.Drawing;
using System.Windows.Forms;
using static ChessEngine.ChessEngineCore.Piece;

namespace ChessEngine.ChessEngineCore
{
    public partial class PromotionForm : Form
    {
        public pieceTypeEnum selectedType;
        private pieceColorEnum color;

        public PromotionForm(pieceColorEnum color)
        {
            this.color = color;
            this.Size = new Size(330, 150);
            this.Text = "Pawn Promotion";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            createButton(pieceTypeEnum.Queen, 20);
            createButton(pieceTypeEnum.Rook, 90);
            createButton(pieceTypeEnum.Bishop, 160);
            createButton(pieceTypeEnum.Knight, 230);
        }

        private void createButton(pieceTypeEnum type, int x)
        {
            Button btn = new Button();
            string colorPrefix = (color == pieceColorEnum.Black) ? "black" : "white";
            string imageName = $"{colorPrefix}-{type.ToString().ToLower()}";
            btn.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            btn.BackgroundImageLayout = ImageLayout.Stretch;
            btn.Size = new Size(70, 70);
            btn.Location = new Point(x, 20);
            btn.Cursor = Cursors.Hand;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(239, 206, 161);
            btn.Click += (s, e) => {
                selectedType = type;
                this.Close();
            };

            this.Controls.Add(btn);
        }
    }
}