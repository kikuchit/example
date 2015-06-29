using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Config
{
    public class ApplicationConfig {
        private DefaultField backgroundField;
        public DefaultField BackgroundField
        {
            get { return this.backgroundField; }
        }

        private StringField numberField;
        public StringField NumberField {
            get { return this.numberField; }
        }

        private StringField trialField;
        public StringField TrialField
        {
            get { return this.trialField; }
        }
        
        private StringField recordField;
        public StringField RecordField
        {
            get { return this.recordField; }
        }

        private ImageField resultField;
        public ImageField ResultField
        {
            get { return this.resultField; }
        }

        private static ApplicationConfig instance = null;

        private ApplicationConfig() {
            this.backgroundField = (Config.DefaultField)ConfigurationManager.GetSection("backgroundField");
            this.numberField = (Config.StringField)ConfigurationManager.GetSection("numberField");
            this.trialField = (Config.StringField)ConfigurationManager.GetSection("trialField");
            this.recordField = (Config.StringField)ConfigurationManager.GetSection("recordField");
            this.resultField = (Config.ImageField)ConfigurationManager.GetSection("resultField");
        }

        public static ApplicationConfig GetInstanse() {
            if (instance != null) {
                return instance;
            }

            instance = new ApplicationConfig();
            return instance;
        }
    }

    /// <summary>
    /// 各領域の設定
    /// </summary>
    public class DefaultField : ConfigurationSection
    {
        /// <summary>
        /// position要素
        /// </summary>
        [ConfigurationProperty("position", IsRequired = true)]
        public PositionItem Position
        {
            get{ return (PositionItem)this["position"]; }
        }

        /// <summary>
        /// size要素
        /// </summary>
        [ConfigurationProperty("size", IsRequired = true)]
        public SizeItem Size
        {
            get{ return (SizeItem)this["size"]; }
        }

        /// <summary>
        /// backColor要素
        /// </summary>
        [ConfigurationProperty("backColor", IsRequired = true)]
        public ColorItem BackColor
        {
            get{ return (ColorItem)this["backColor"]; }
        }
    }

    /// <summary>
    /// 文字列領域の設定
    /// </summary>
    public class StringField : DefaultField
    {
        /// <summary>
        /// stringFont要素
        /// </summary>
        [ConfigurationProperty("stringFont", IsRequired = true)]
        public FontItem StringFont
        {
            get { return (FontItem)this["stringFont"]; }
        }

        /// <summary>
        /// stringColor要素
        /// </summary>
        [ConfigurationProperty("stringColor", IsRequired = true)]
        public ColorItem StringColor
        {
            get { return (ColorItem)this["stringColor"]; }
        }
    }

    /// <summary>
    /// 画像領域の設定
    /// </summary>
    public class ImageField : DefaultField
    {
        /// <summary>
        /// image要素
        /// </summary>
        [ConfigurationProperty("image", IsRequired = true)]
        public ImageItem Image
        {
            get { return (ImageItem)this["image"]; }
        }
    }

    /// <summary>
    /// position要素の定義
    /// </summary>
    public class PositionItem : ConfigurationElement
    {
        /// <summary>
        /// x属性
        /// </summary>
        [ConfigurationProperty("x", IsRequired = true)]
        public float X
        {
            get{ return (float)this["x"]; }
            set{ this["x"] = value; }
        }

        /// <summary>
        /// y属性
        /// </summary>
        [ConfigurationProperty("y", IsRequired = true)]
        public float Y
        {
            get{ return (float)this["y"]; }
            set{ this["y"] = value; }
        }

        /// <summary>
        /// 診断用文字列を返す
        /// </summary>
        /// <returns>診断用文字列</returns>
        public override string ToString()
        {
            var buf = new StringBuilder();
            buf.Append("[");
            buf.Append("x=").Append(this.X);
            buf.Append(", y=").Append(this.Y);
            buf.Append("]");
            return buf.ToString();
        }
    }

    /// <summary>
    /// size要素の定義
    /// </summary>
    public class SizeItem : ConfigurationElement
    {
        /// <summary>
        /// width属性
        /// </summary>
        [ConfigurationProperty("width", IsRequired = true)]
        public float Width
        {
            get{ return (float)this["width"]; }
            set{ this["width"] = value; }
        }

        /// <summary>
        /// height属性
        /// </summary>
        [ConfigurationProperty("height", IsRequired = true)]
        public float Height
        {
            get{ return (float)this["height"]; }
            set{ this["height"] = value; }
        }

        /// <summary>
        /// 診断用文字列を返す
        /// </summary>
        /// <returns>診断用文字列</returns>
        public override string ToString()
        {
            var buf = new StringBuilder();
            buf.Append("[");
            buf.Append("width=").Append(this.Width);
            buf.Append(", height=").Append(this.Height);
            buf.Append("]");
            return buf.ToString();
        }
    }

    /// <summary>
    /// color要素の定義
    /// </summary>
    public class ColorItem : ConfigurationElement
    {
        /// <summary>
        /// alpha属性
        /// </summary>
        [ConfigurationProperty("alpha", IsRequired = true)]
        public int Alpha
        {
            get{ return (int)this["alpha"]; }
            set{ this["alpha"] = value; }
        }

        /// <summary>
        /// red属性
        /// </summary>
        [ConfigurationProperty("red", IsRequired = true)]
        public int Red
        {
            get{ return (int)this["red"]; }
            set{ this["red"] = value; }
        }

        /// <summary>
        /// green属性
        /// </summary>
        [ConfigurationProperty("green", IsRequired = true)]
        public int Green
        {
            get{ return (int)this["green"]; }
            set{ this["green"] = value; }
        }

        /// <summary>
        /// blue属性
        /// </summary>
        [ConfigurationProperty("blue", IsRequired = true)]
        public int Blue
        {
            get{ return (int)this["blue"]; }
            set{ this["blue"] = value; }
        }

        /// <summary>
        /// 診断用文字列を返す
        /// </summary>
        /// <returns>診断用文字列</returns>
        public override string ToString()
        {
            var buf = new StringBuilder();
            buf.Append("[");
            buf.Append("alpha=").Append(this.Alpha);
            buf.Append(", red=").Append(this.Red);
            buf.Append(", green=").Append(this.Green);
            buf.Append(", blue=").Append(this.Blue);
            buf.Append("]");
            return buf.ToString();
        }
    }

    /// <summary>
    /// font要素の定義
    /// </summary>
    public class FontItem : ConfigurationElement
    {
        /// <summary>
        /// familyName属性
        /// </summary>
        [ConfigurationProperty("familyName", IsRequired = true)]
        public string FamilyName
        {
            get{ return (string)this["familyName"]; }
            set{ this["familyName"] = value; }
        }

        /// <summary>
        /// emSize属性
        /// </summary>
        [ConfigurationProperty("emSize", IsRequired = true)]
        public int EmSize
        {
            get{ return (int)this["emSize"]; }
            set{ this["emSize"] = value; }
        }

        /// <summary>
        /// 診断用文字列を返す
        /// </summary>
        /// <returns>診断用文字列</returns>
        public override string ToString()
        {
            var buf = new StringBuilder();
            buf.Append("[");
            buf.Append("familyName=").Append(this.FamilyName);
            buf.Append(", emSize=").Append(this.EmSize);
            buf.Append("]");
            return buf.ToString();
        }
    }

    /// <summary>
    /// image要素の定義
    /// </summary>
    public class ImageItem : ConfigurationElement
    {
        /// <summary>
        /// path属性
        /// </summary>
        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get { return (string)this["path"]; }
            set { this["path"] = value; }
        }

        /// <summary>
        /// 診断用文字列を返す
        /// </summary>
        /// <returns>診断用文字列</returns>
        public override string ToString()
        {
            var buf = new StringBuilder();
            buf.Append("[");
            buf.Append("path=").Append(this.Path);
            buf.Append("]");
            return buf.ToString();
        }
    }
}
