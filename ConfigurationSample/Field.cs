using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Config;
using System.Collections;

namespace Field
{
    class Display {
        private FieldBackground background;

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
            this.background = new FieldBackground(config.BackgroundField);
            this.numberField = new FieldString(config.NumberField);
            this.trialField = new FieldString(config.TrialField);
            this.recordField = new FieldString(config.RecordField);
            this.resultField = new FieldImage(config.ResultField);
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

    abstract class Field
    {
        protected PointF position;
        protected float width;
        protected float height;

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

        public Field(DefaultField config)
        {
            this.position = new PointF(config.Position.X, config.Position.Y);
            this.width = config.Size.Width;
            this.height = config.Size.Height;
            this.rect = new RectangleF(this.position.X, this.position.Y, this.width, this.height);
            this.backColor = new SolidBrush(ConfigToColor(config.BackColor));
        }

        protected static Color ConfigToColor(ColorItem colorConfig)
        {
            return Color.FromArgb(
                        colorConfig.Alpha,
                        colorConfig.Red,
                        colorConfig.Green,
                        colorConfig.Blue);
        }
    }

    class FieldBackground : Field
    {
        public FieldBackground(DefaultField config) : base(config) { }
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


        public FieldString(StringField config) : base(config)
        {
            this.displayString = null;
            this.stringFont = new Font(config.StringFont.FamilyName, config.StringFont.EmSize);
            this.stringColor = new SolidBrush(ConfigToColor(config.StringColor));
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

        public FieldImage(ImageField config) : base(config)
        {
            this.imagePath = config.Image.Path;
        }
    }
}
