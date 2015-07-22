using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;

namespace ConfigurationSample
{
    class Display {
        private Field background;

        private FieldString numberField;
        public FieldString NumberField {
            get { return this.numberField; }
        }

        private FieldString trialField;
        public FieldString TrialField
        {
            get { return this.trialField; }
        }

        private FieldString recordField;
        public FieldString RecordField
        {
            get { return this.recordField; }
        }

        private FieldImage resultField;
        public FieldImage ResultField
        {
            get { return this.resultField; }
        }
        
        public Display(ApplicationConfig config) {
            this.background = (Field)FieldFactory.MakeField(config.BackgroundField);
            this.numberField = (FieldString)FieldFactory.MakeField(config.NumberField);
            this.trialField = (FieldString)FieldFactory.MakeField(config.TrialField);
            this.recordField = (FieldString)FieldFactory.MakeField(config.RecordField);
            this.resultField = (FieldImage)FieldFactory.MakeField(config.ResultField);
        }

        public List<Field> GetList() {
            List<Field> list = new List<Field>();
            list.Add(this.numberField);
            list.Add(this.trialField);
            list.Add(this.recordField);
            list.Add(this.resultField);
            return list;
        }
    }

    class Field
    {
        protected PointF position;
        public PointF Position
        {
            get { return this.position; }
        }

        protected RectangleF rect;
        public RectangleF Rect
        {
            get { return this.rect; }
        }

        protected SolidBrush backColor;
        public SolidBrush BackColor
        {
            get { return this.backColor; }
        }

        public Field(PointF position, float width, float height, SolidBrush backColor)
        {
            this.position = position;
            this.rect = new RectangleF(this.position.X, this.position.Y, width, height);
            this.backColor = backColor;
        }
    }

    class FieldString : Field
    {
        private string displayString;
        public string DisplayString {
            get { return this.displayString; }
            set { this.displayString = value; }
        }

        private Font stringFont;
        public Font StringFont
        {
            get { return this.stringFont; }
        }

        private SolidBrush stringColor;
        public SolidBrush StringColor
        {
            get { return this.stringColor; }
        }

        private StringFormat stringFormat;
        public StringFormat StringFormat
        {
            get { return this.stringFormat; }
        }


        public FieldString(
            PointF position,
            float width,
            float height,
            SolidBrush backColor,
            Font stringFont,
            SolidBrush stringColor)
            : base(position, width, height, backColor)
        {
            this.displayString = null;
            this.stringFont = stringFont;
            this.stringColor = stringColor;
            this.stringFormat = new StringFormat();
            this.stringFormat.Alignment = StringAlignment.Center;
            this.stringFormat.LineAlignment = StringAlignment.Center;
        }
    }

    class FieldImage : Field
    {
        private string imagePath;
        public string ImagePath
        {
            get { return this.imagePath; }
        }

        public FieldImage(PointF position, float width, float height, SolidBrush backColor, string imagePath)
            : base(position, width, height, backColor)
        {
            this.imagePath = imagePath;
        }
    }
}
