// COPYRIGHT (C) Tom. ALL RIGHTS RESERVED.
// THE AntdUI PROJECT IS AN WINFORM LIBRARY LICENSED UNDER THE Apache-2.0 License.
// LICENSED UNDER THE Apache License, VERSION 2.0 (THE "License")
// YOU MAY NOT USE THIS FILE EXCEPT IN COMPLIANCE WITH THE License.
// YOU MAY OBTAIN A COPY OF THE LICENSE AT
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// UNLESS REQUIRED BY APPLICABLE LAW OR AGREED TO IN WRITING, SOFTWARE
// DISTRIBUTED UNDER THE LICENSE IS DISTRIBUTED ON AN "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED.
// SEE THE LICENSE FOR THE SPECIFIC LANGUAGE GOVERNING PERMISSIONS AND
// LIMITATIONS UNDER THE License.
// GITCODE: https://gitcode.com/AntdUI/AntdUI
// GITEE: https://gitee.com/AntdUI/AntdUI
// GITHUB: https://github.com/AntdUI/AntdUI
// CSDN: https://blog.csdn.net/v_132
// QQ: 17379620

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntdUI
{
    partial class CellTable
    {
        public override void PaintBack(Canvas g)
        { }

        public override void Paint(Canvas g, Font font, bool enable, SolidBrush fore)
        {
            using (var path = Rect.RoundPath(0))
            {
                #region 绘制背景

                Color _fore, _back, _bor;
                switch (Type)
                {
                    case TTypeMini.Default:
                        _back = Colour.TagDefaultBg.Get("Table", PARENT.PARENT.ColorScheme);
                        _fore = Colour.TagDefaultColor.Get("Table", PARENT.PARENT.ColorScheme);
                        _bor = Colour.DefaultBorder.Get("Table", PARENT.PARENT.ColorScheme);
                        break;

                    case TTypeMini.Error:
                        _back = Colour.ErrorBg.Get("Table", PARENT.PARENT.ColorScheme);
                        _fore = Colour.Error.Get("Table", PARENT.PARENT.ColorScheme);
                        _bor = Colour.ErrorBorder.Get("Table", PARENT.PARENT.ColorScheme);
                        break;

                    case TTypeMini.Success:
                        _back = Colour.SuccessBg.Get("Table", PARENT.PARENT.ColorScheme);
                        _fore = Colour.Success.Get("Table", PARENT.PARENT.ColorScheme);
                        _bor = Colour.SuccessBorder.Get("Table", PARENT.PARENT.ColorScheme);
                        break;

                    case TTypeMini.Info:
                        _back = Colour.InfoBg.Get("Table", PARENT.PARENT.ColorScheme);
                        _fore = Colour.Info.Get("Table", PARENT.PARENT.ColorScheme);
                        _bor = Colour.InfoBorder.Get("Table", PARENT.PARENT.ColorScheme);
                        break;

                    case TTypeMini.Warn:
                        _back = Colour.WarningBg.Get("Table", PARENT.PARENT.ColorScheme);
                        _fore = Colour.Warning.Get("Table", PARENT.PARENT.ColorScheme);
                        _bor = Colour.WarningBorder.Get("Table  ", PARENT.PARENT.ColorScheme);
                        break;

                    case TTypeMini.Primary:
                    default:
                        _back = Colour.PrimaryBg.Get("Table", PARENT.PARENT.ColorScheme);
                        _fore = Colour.Primary.Get("Table", PARENT.PARENT.ColorScheme);
                        _bor = Colour.Primary.Get("Table", PARENT.PARENT.ColorScheme);
                        break;
                }

                if (Fore.HasValue) _fore = Fore.Value;
                if (Back.HasValue) _back = Back.Value;

                g.Fill(_back, path);

                if (borderWidth > 0) g.Draw(_bor, borderWidth * Config.Dpi, path);

                #endregion 绘制背景

                g.String(Key, font, _fore, Rect, Table.StringFormat(ColumnAlign.Center));
            }           
        }

        public override Size GetSize(Canvas g, Font font, int gap, int gap2)
        {
            var size = g.MeasureString(Key, font);
            if (Gap.HasValue)
            {
                int sp = (int)(Gap.Value * Config.Dpi);
                return new Size(size.Width + sp * 2, size.Height + sp);
            }
            else if (PARENT.PARENT.GapCell.HasValue)
            {
                int sp = (int)(PARENT.PARENT.GapCell.Value * Config.Dpi);
                return new Size(size.Width + sp * 2, size.Height + sp);
            }
            else return new Size(size.Width + gap2, size.Height + gap);
        }

        public override void SetRect(Canvas g, Font font, Rectangle rect, Size size, int maxwidth, int gap, int gap2)
        {
            Rect = new Rectangle(rect.X, rect.Y + (rect.Height - size.Height) / 2, rect.Width, size.Height);
        }
    }
}