using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Field;

namespace ConfigurationSample
{
    class MyGraphics
    {
        Bitmap bmp;
        Graphics grp;

        public MyGraphics(float width, float height) {
            this.bmp = new Bitmap((int)width, (int)height);
            this.grp = Graphics.FromImage(bmp);
        }

        public void DrawBackground(FieldBackground field) {
            this.grp.FillRectangle(field.BackColor, field.Rect);
        }

        public void DrawStringField(FieldString field)
        {
            this.grp.FillRectangle(field.BackColor, field.Rect);
            this.grp.DrawString(
                field.DisplayString,
                field.StringFont,
                field.StringColor,
                field.Rect,
                field.StringFormat);
        }

        public void DrawImageField(FieldImage field)
        {
            this.grp.FillRectangle(field.BackColor, field.Rect);
            this.grp.DrawImage(new Bitmap(field.ImagePath), field.Rect);
        }

        public void Save(string filename) {
            this.bmp.Save(@filename);
        }

        public void Dispose() {
            this.grp.Dispose();
            this.bmp.Dispose();
        }
    }
}
