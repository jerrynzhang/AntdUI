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
    /// <summary>
    /// 单元格
    /// </summary>
    public partial class CellTable : ICell
    {
        /// <summary>
        /// 单元格
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public CellTable(string key,string value)
        {   
            _key = key;
            _value = value; 
        } 

        public CellTable(string key, string value, TTypeMini type)
        {
            _key = key;
            _value = value;
            _type = type;
        }

        #region 属性

        private Color? fore;

        /// <summary>
        /// 字体颜色
        /// </summary>
        public Color? Fore
        {
            get => fore;
            set
            {
                if (fore == value) return;
                fore = value;
                OnPropertyChanged();
            }
        }

        private Color? back;

        /// <summary>
        /// 背景颜色
        /// </summary>
        public Color? Back
        {
            get => back;
            set
            {
                if (back == value) return;
                back = value;
                OnPropertyChanged();
            }
        }

        private float borderWidth = 1F;

        /// <summary>
        /// 边框宽度
        /// </summary>
        public float BorderWidth
        {
            get => borderWidth;
            set
            {
                if (borderWidth == value) return;
                borderWidth = value;
                OnPropertyChanged();
            }
        }

        private TTypeMini _type = TTypeMini.Default;

        /// <summary>
        /// 类型
        /// </summary>
        public TTypeMini Type
        {
            get => _type;
            set
            {
                if (_type == value) return;
                _type = value;
                OnPropertyChanged();
            }
        }

        private string _key;
        private string _value;

        /// <summary>
        /// 文本 Key
        /// </summary>
        public string Key
        {
            get => _key;
            set
            {
                if (_key == value) return;
                _key = value;
                OnPropertyChanged(true);
            }
        }

        /// <summary>
        /// 文本 Value
        /// </summary>
        public string Value 
        {
            get => _value;
            set 
            {
                if (_value == value) return;
                _value = value;
                OnPropertyChanged(true);
            }
        }

        /// <summary>
        /// 间距
        /// </summary>
        public int? Gap { get; set; }

        #endregion 属性

        #region 设置

        public CellTable SetFore(Color? value)
        {
            fore = value;
            return this;
        }

        public CellTable SetBack(Color? value)
        {
            back = value;
            return this;
        }

        public CellTable SetBorderWidth(float value = 0F)
        {
            borderWidth = value;
            return this;
        }

        public CellTable SetType(TTypeMini value = TTypeMini.Success)
        {
            _type = value;
            return this;
        }

        public CellTable SetGap(int? value)
        {
            Gap = value;
            return this;
        }

        #endregion 设置

        public override string ToString() => _key;
    }
}