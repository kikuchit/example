using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace ConfigurationSample
{
    class DisplayGraphics : IDisposable
    {
        Bitmap bmp;
        Graphics grp;
        float width;
        float height;

        /// <summary>
        /// コンストラクタ
        /// イメージの元ネタになるビットマップと、
        /// 描画用グラフィックのオブジェクトを生成する。
        /// </summary>
        /// <param name="width">横幅</param>
        /// <param name="height">縦幅</param>
        public DisplayGraphics(float width, float height) {
            this.width = width;
            this.height = height;
            this.bmp = new Bitmap((int)width, (int)height);
            this.grp = Graphics.FromImage(bmp);
        }

        /// <summary>
        /// 文字列フィールド書き出し
        /// </summary>
        /// <param name="field"></param>
        public void DrawField(FieldString field)
        {
            this.grp.FillRectangle(field.BackColor, field.Rect);
            this.grp.DrawString(
                field.DisplayString,
                field.StringFont,
                field.StringColor,
                field.Rect,
                field.StringFormat);
        }

        /// <summary>
        /// イメージフィールド書き出し
        /// </summary>
        /// <param name="field"></param>
        public void DrawField(FieldImage field)
        {
            this.grp.FillRectangle(field.BackColor, field.Rect);
            this.grp.DrawImage(new Bitmap(field.ImagePath), field.Rect);
        }

        /// <summary>
        /// ファイル保存
        /// </summary>
        /// <param name="filename"></param>
        public void Save(string filename) {
            this.bmp.Save(@filename);
        }

        /// <summary>
        /// ビットマップデータをbyte配列に変換して返す
        /// </summary>
        /// <returns>ビットマップデータのbyte配列</returns>
        public byte[] GetBytes()
        {
            byte[] bmpData = null;
            using(var ms = new MemoryStream())
            {
                this.bmp.Save(ms, ImageFormat.Bmp);
                bmpData = ms.ToArray();
            }
            return bmpData;
        }

        /// <summary>
        /// オブジェクト破棄の処理
        /// </summary>
        public void Dispose()
        {
            this.grp.Dispose();
            this.bmp.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
