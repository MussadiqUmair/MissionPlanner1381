﻿using System;
using System.Collections.Generic;
using SkiaSharp;

namespace System.Drawing
{
    public class FontFamily
    {
        public static FontFamily GenericSansSerif { get; set; } =
            new FontFamily() {Name = SKTypeface.Default.FamilyName};

        public static FontFamily GenericMonospace { get; set; } =
            new FontFamily() {Name = SKTypeface.Default.FamilyName};

        public static IEnumerable<FontFamily> Families
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Name { get; set; }

        public FontFamily()
        {
        }

        public int GetCellAscent(FontStyle fontStyle)
        {
            return 0;
        }

        public int GetCellDescent(FontStyle fontStyle)
        {
            return 0;
        }

        public bool IsStyleAvailable(FontStyle bold)
        {
            return false;
        }

        public int GetLineSpacing(FontStyle style)
        {
            return 1;
        }
    }
}