using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ConfigurationSample
{
    class FieldFactory
    {
        public static Field MakeField(DefaultField fieldConfig)
        {
            Field result = null;
            Type type = fieldConfig.GetType();
            if(type.Equals(typeof(DefaultField)))
            {
                result = MakeDefault(fieldConfig);
            }
            else if (type.Equals(typeof(StringField)))
            {
                result = MakeFieldString((StringField)fieldConfig);
            }
            else if (type.Equals(typeof(ImageField)))
            {
                result = MakeFieldImage((ImageField)fieldConfig);
            }
            else
            {
                throw new ArgumentException("fieldConfig型不正：" + type.ToString());
            }

            return result;
        }

        private static Field MakeDefault(DefaultField config)
        {
            return new Field(
                new PointF(config.Position.X, config.Position.Y),
                config.Size.Width,
                config.Size.Height,
                new SolidBrush(config.BackColor.ConfigToColor()));
        }

        private static Field MakeFieldString(StringField config)
        {
            return new FieldString(
                new PointF(config.Position.X, config.Position.Y),
                config.Size.Width,
                config.Size.Height,
                new SolidBrush(config.BackColor.ConfigToColor()),
                new Font(config.StringFont.FamilyName, config.StringFont.EmSize),
                new SolidBrush(config.StringColor.ConfigToColor()));
        }

        private static Field MakeFieldImage(ImageField config)
        {
            return new FieldImage(
                new PointF(config.Position.X, config.Position.Y),
                config.Size.Width,
                config.Size.Height,
                new SolidBrush(config.BackColor.ConfigToColor()),
                config.Image.Path);
        }
    }
}
