﻿// COPYRIGHT (C) Tom. ALL RIGHTS RESERVED.
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AntdUI
{
    partial class Table
    {
        /// <summary>
        /// 选中改变事件
        /// </summary>
        public delegate void CheckEventHandler(object sender, TableCheckEventArgs e);

        /// <summary>
        /// 点击事件
        /// </summary>
        public delegate void ClickEventHandler(object sender, TableClickEventArgs e);

        /// <summary>
        /// 移动事件
        /// </summary>
        public delegate void HoverEventHandler(object sender, TableHoverEventArgs e);

        /// <summary>
        /// 按钮点击事件
        /// </summary>
        public delegate void ClickButtonEventHandler(object sender, TableButtonEventArgs e);

        /// <summary>
        /// Checked 属性值更改时发生
        /// </summary>
        [Description("Checked 属性值更改时发生"), Category("行为")]
        public event CheckEventHandler? CheckedChanged;

        public class CheckStateEventArgs : EventArgs
        {
            public CheckStateEventArgs(ColumnCheck column, CheckState value)
            {
                Column = column;
                Value = value;
            }

            /// <summary>
            /// 触发表头对象
            /// </summary>
            public ColumnCheck Column { get; private set; }

            /// <summary>
            /// 数值
            /// </summary>
            public CheckState Value { get; private set; }
        }

        /// <summary>
        /// CheckState类型事件
        /// </summary>
        public delegate void CheckStateEventHandler(object sender, CheckStateEventArgs e);

        /// <summary>
        /// 全局 CheckState 属性值更改时发生
        /// </summary>
        [Description("全局 CheckState 属性值更改时发生"), Category("行为")]
        public event CheckStateEventHandler? CheckedOverallChanged;

        internal void OnCheckedOverallChanged(ColumnCheck column, CheckState checkState) => CheckedOverallChanged?.Invoke(this, new CheckStateEventArgs(column, checkState));

        /// <summary>
        /// 单击时发生
        /// </summary>
        [Description("单击时发生"), Category("行为")]
        public event ClickEventHandler? CellClick;

        /// <summary>
        /// 滑动时发生
        /// </summary>
        [Description("滑动时发生"), Category("行为")]
        public event HoverEventHandler? CellHover;

        /// <summary>
        /// 单击按钮时发生
        /// </summary>
        [Description("单击按钮时发生"), Category("行为")]
        public event ClickButtonEventHandler? CellButtonClick;

        /// <summary>
        /// 按下按钮时发生
        /// </summary>
        [Description("按下按钮时发生"), Category("行为")]
        public event ClickButtonEventHandler? CellButtonDown;

        /// <summary>
        /// 放下按钮时发生
        /// </summary>
        [Description("放下按钮时发生"), Category("行为")]
        public event ClickButtonEventHandler? CellButtonUp;

        /// <summary>
        /// 双击时发生
        /// </summary>
        [Description("双击时发生"), Category("行为")]
        public event ClickEventHandler? CellDoubleClick;

        #region 编辑

        /// <summary>
        /// 编辑前事件
        /// </summary>
        public delegate bool BeginEditEventHandler(object sender, TableEventArgs e);

        /// <summary>
        /// 编辑前事件文本框样式
        /// </summary>
        public delegate void BeginEditInputStyleEventHandler(object sender, TableBeginEditInputStyleEventArgs e);

        /// <summary>
        /// 编辑后事件
        /// </summary>
        public delegate bool EndEditEventHandler(object sender, TableEndEditEventArgs e);

        /// <summary>
        /// 编辑后事件
        /// </summary>
        public delegate bool EndValueEditEventHandler(object sender, TableEndValueEditEventArgs e);

        /// <summary>
        /// 编辑后事件
        /// </summary>
        public delegate void EndEditCompleteEventHandler(object sender, ITableEventArgs e);

        /// <summary>
        /// 编辑前发生
        /// </summary>
        [Description("编辑前发生"), Category("行为")]
        public event BeginEditEventHandler? CellBeginEdit;

        /// <summary>
        /// 编辑前文本框样式发生
        /// </summary>
        [Description("编辑前文本框样式发生"), Category("行为")]
        public event BeginEditInputStyleEventHandler? CellBeginEditInputStyle;

        /// <summary>
        /// 编辑后发生
        /// </summary>
        [Description("编辑后发生"), Category("行为")]
        public event EndEditEventHandler? CellEndEdit;

        /// <summary>
        /// 编辑后发生
        /// </summary>
        [Description("编辑后发生"), Category("行为")]
        public event EndValueEditEventHandler? CellEndValueEdit;

        /// <summary>
        /// 编辑完成后发生
        /// </summary>
        [Description("编辑完成后发生"), Category("行为")]
        public event EndEditCompleteEventHandler? CellEditComplete;

        #endregion

        #region 绘制

        /// <summary>
        /// 绘制单元格时发生
        /// </summary>
        public delegate void CellPaintEventHandler(object sender, TablePaintEventArgs e);
        public delegate void CellPaintRowEventHandler(object sender, TablePaintRowEventArgs e);

        /// <summary>
        /// 绘制单元格之前发生
        /// </summary>
        public delegate void CellPaintBeginEventHandler(object sender, TablePaintBeginEventArgs e);

        /// <summary>
        /// 绘制行时发生
        /// </summary>
        [Description("绘制行时发生"), Category("行为")]
        public event CellPaintRowEventHandler? RowPaint;

        /// <summary>
        /// 绘制行前发生
        /// </summary>
        [Description("绘制行前发生"), Category("行为")]
        public event CellPaintRowEventHandler? RowPaintBegin;

        /// <summary>
        /// 绘制单元格时发生
        /// </summary>
        [Description("绘制单元格时发生"), Category("行为")]
        public event CellPaintEventHandler? CellPaint;

        /// <summary>
        /// 绘制单元格之前发生
        /// </summary>
        [Description("绘制单元格之前发生"), Category("行为")]
        public event CellPaintBeginEventHandler? CellPaintBegin;

        #endregion

        public delegate CellStyleInfo? SetRowStyleEventHandler(object sender, TableSetRowStyleEventArgs e);
        /// <summary>
        /// 设置行样式
        /// </summary>
        public event SetRowStyleEventHandler? SetRowStyle;

        public class CellStyleInfo
        {
            /// <summary>
            /// 背景颜色
            /// </summary>
            public Color? BackColor { get; set; }

            /// <summary>
            /// 文字颜色
            /// </summary>
            public Color? ForeColor { get; set; }
        }

        /// <summary>
        /// 行排序时发生
        /// </summary>
        [Description("行排序时发生"), Category("行为")]
        public event IntEventHandler? SortRows;

        /// <summary>
        /// 树行排序时发生
        /// </summary>
        [Description("树行排序时发生"), Category("行为")]
        public event SortTreeEventHandler? SortRowsTree;

        public delegate void SortTreeEventHandler(object sender, TableSortTreeEventArgs e);

        public delegate bool SortModeEventHandler(object sender, TableSortModeEventArgs e);

        /// <summary>
        /// 点击排序后发生
        /// </summary>
        [Description("点击排序后发生"), Category("行为")]
        public event SortModeEventHandler? SortModeChanged;

        /// <summary>
        /// 选中变化后发生
        /// </summary>
        [Description("选中变化后发生"), Category("行为")]
        public event EventHandler? SelectIndexChanged;

        /// <summary>
        /// 自定义排序
        /// </summary>
        [Description("自定义排序"), Category("行为")]
        public event Comparison<string>? CustomSort;

        /// <summary>
        /// 展开事件
        /// </summary>
        public delegate void ExpandEventHandler(object sender, TableExpandEventArgs e);

        /// <summary>
        /// 展开改变时发生
        /// </summary>
        [Description("展开改变时发生"), Category("行为")]
        public event ExpandEventHandler? ExpandChanged;

        #region 筛选

        /// <summary>
        /// Table的列筛选关闭前的处理事件
        /// </summary>
        /// <param name="sender">Table</param>
        /// <param name="e">事件参数</param>
        public delegate void TableFilterPopupEndEventHandler(object sender, TableFilterPopupEndEventArgs e);

        /// <summary>
        /// Table的列筛选弹出前的数据处理事件
        /// </summary>
        /// <param name="sender">Table</param>
        /// <param name="e">事件参数</param>
        public delegate void TableFilterPopupBeginEventHandler(object sender, TableFilterPopupBeginEventArgs e);

        /// <summary>
        /// Table的筛选数据变更事件
        /// </summary>
        /// <param name="sender">Table</param>
        /// <param name="e">事件参数</param>
        public delegate void TableFilterDataChangedEventHandler(object sender, TableFilterDataChangedEventArgs e);

        /// <summary>
        /// <summary>
        /// 筛选窗口弹出前发生
        /// </summary>
        [Description("筛选窗口弹出前发生"), Category("行为")]
        public event TableFilterPopupBeginEventHandler? FilterPopupBegin;
        /// <summary>
        /// 筛选窗口关闭前发生
        /// </summary>
        [Description("筛选窗口关闭前发生"), Category("行为")]
        public event TableFilterPopupEndEventHandler? FilterPopupEnd;

        /// <summary>
        /// 筛选数据变更后发生
        /// </summary>
        [Description("筛选数据变更后发生"), Category("行为")]
        public event TableFilterDataChangedEventHandler? FilterDataChanged;

        #endregion
    }
}