using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace ConfigurationSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var ac = ApplicationConfig.GetInstanse();
            var display = new Display(ac);
            display.NumberField.DisplayString = "number";
            display.TrialField.DisplayString = "trial";
            display.RecordField.DisplayString = "record";

            using (var grp = new DisplayGraphics(ac.BackgroundField.Size.Width, ac.BackgroundField.Size.Height))
            {
                grp.DrawStringField(display.NumberField);
                grp.DrawStringField(display.TrialField);
                grp.DrawStringField(display.RecordField);
                grp.DrawImageField(display.ResultField);
                grp.Save(@"c:\sample.bmp");
            }
        }
    }
}

