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
            this.Size = new Size(330, 150); // Pencere boyutunu butonlara tam oturacak şekilde hafif güncelledim
            this.Text = "Pawn Promotion"; // İngilizce başlık
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            // Butonları oluştur (Artık sadece taş tipini ve X koordinatını gönderiyoruz)
            createButton(pieceTypeEnum.Queen, 20);
            createButton(pieceTypeEnum.Rook, 90);
            createButton(pieceTypeEnum.Bishop, 160);
            createButton(pieceTypeEnum.Knight, 230);
        }

        private void createButton(pieceTypeEnum type, int x)
        {
            Button btn = new Button();

            // 1. Resim ismini tam senin property mantığındaki gibi dinamik oluşturuyoruz
            string colorPrefix = (color == pieceColorEnum.Black) ? "black" : "white";
            string imageName = $"{colorPrefix}-{type.ToString().ToLower()}";

            // 2. Resmi projenin Resource'larından (kaynaklarından) çekip arka plana atıyoruz
            btn.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            btn.BackgroundImageLayout = ImageLayout.Stretch; // Resim 70x70 butona tam sığsın

            // 3. Butonun standart görsel ayarları
            btn.Size = new Size(70, 70);
            btn.Location = new Point(x, 20);
            btn.Cursor = Cursors.Hand; // Üzerine gelince fare imleci el işaretine dönsün (tatlı bir detay)

            // 4. (Opsiyonel) Etrafındaki çirkin Windows buton kenarlıklarını kaldırıp şıklaştırıyoruz
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(239, 206, 161); // Tahtanın açık renkli karesinin rengi

            // 5. Tıklanma olayı
            btn.Click += (s, e) => {
                selectedType = type;
                this.Close();
            };

            this.Controls.Add(btn);
        }
    }
}