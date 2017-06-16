using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = File.ReadAllText(@"C:\Users\A738567\Documents\Visual Studio 2017\Projects\ConsoleApp1\ConsoleApp7\TextFile1.txt");

            GridDisplay(data);

            //DisplayHexAndTextData(data,new );
        }

        static void GridDisplay(string message)
        {
            int iColByChar = 25;
            int inumDataRows;

            DataTable dataTable = new DataTable();

            for (int i = 0; i < iColByChar + 1; i++)
            {
                DataColumn column = new DataColumn();
                if (i != 0)
                {
                    column.ColumnName = (i - 1).ToString();
                }

                dataTable.Columns.Add(column);
            }

            DataColumn messageDataColum = new DataColumn();

            if (true)
                messageDataColum.ColumnName = "Ebcidic";
            else
                messageDataColum.ColumnName = "Ascii";

            dataTable.Columns.Add(messageDataColum);

            inumDataRows = message.Length / iColByChar;

            if (inumDataRows * iColByChar != message.Length)
                inumDataRows++;

            for (int i = 0, j = 0; i < inumDataRows; i++)
            {
                //First count column
                DataRow dataRow = dataTable.NewRow();

                if (i != 0)
                    dataRow[0] = "+" + i * iColByChar;

                for (j = 0; j < iColByChar && (i * iColByChar + j < message.Length); j++)
                {
                    char c = message[i * iColByChar + j];

                    dataRow[j + 1] = ((ushort)c).ToString("X2");
                }

                string value = string.Empty;

                if (i < message.Length / iColByChar)
                {
                    string str = string.Empty;
                    str = message.Substring(i * iColByChar, j);
                    value = str.Replace("\0", ".");
                }
                else
                {
                    for (int k = j; k < iColByChar; k++)
                    {
                        value = "";
                    }

                    string str2 = string.Empty;
                    str2 = message.Substring(i * iColByChar, j);
                    value = str2.Replace("\0", ".");
                }

                if (true)
                    dataRow["Ebcidic"] = (value);
                else
                    dataRow["Ascii"] = value;

                dataTable.Rows.Add(dataRow);
            }

        }

        static void DisplayHexAndTextData(string data, Table uWGrid, bool bAscii)
        {
            int iColByChar = 25;
            int iCharColWidth = 20;
            int iAsciiColWidth = 270;
            int inumDataRows;

            uWGrid.Rows.Clear();
            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.BackColor = Color.FromArgb(229, 229, 229);
            headerRow.Font.Bold = true;
            uWGrid.Rows.Add(headerRow);

            //Add header
            for (int i = 0; i < iColByChar + 2; i++)
            {
                TableHeaderCell cl = new TableHeaderCell();
                if (i == iColByChar + 1)
                {
                    if (bAscii)
                    {
                        cl.Text = "Ascii";
                    }
                    else
                    {
                        cl.Text = "Ebcdic";
                    }
                    cl.Width = new Unit(iAsciiColWidth);
                }
                else if (i != 0)
                {
                    cl.Text = (i - 1).ToString();
                    cl.Width = new Unit(iCharColWidth);
                }
                headerRow.Cells.Add(cl);
            }

            inumDataRows = data.Length / iColByChar;
            if (inumDataRows * iColByChar != data.Length)
                inumDataRows++;

            for (int i = 0, j = 0; i < inumDataRows; i++)
            {
                TableRow newRow = new TableRow();

                //First count column
                TableCell newCell = new TableCell();
                if (i != 0)
                    newCell.Text = "+" + i * iColByChar;
                newCell.BackColor = Color.FromArgb(229, 229, 229);
                newCell.Font.Bold = true;
                newRow.Cells.Add(newCell);

                Color cellBackColor = Color.White;
                if (i % 2 == 0)
                    cellBackColor = Color.FromArgb(229, 238, 249);

                for (j = 0; j < iColByChar && (i * iColByChar + j < data.Length); j++)
                {
                    char c = data[i * iColByChar + j];
                    TableCell newItem = new TableCell();
                    newItem.Text = ((ushort)(char)c).ToString("X2");
                    newItem.BackColor = cellBackColor;
                    newRow.Cells.Add(newItem);
                }
                if (i < data.Length / iColByChar)
                {
                    string str = string.Empty;
                    str = data.Substring(i * iColByChar, j);
                    str = str.Replace("\0", ".");
                    TableCell newItem = new TableCell();
                    newItem.Text = str;
                    newItem.BackColor = cellBackColor;
                    newRow.Cells.Add(newItem);
                }
                else
                {
                    for (int k = j; k < iColByChar; k++)
                    {
                        TableCell newItem = new TableCell();
                        newItem.Text = "";
                        newItem.BackColor = cellBackColor;
                        newRow.Cells.Add(newItem);
                    }
                    string str2 = string.Empty;
                    str2 = data.Substring(i * iColByChar, j);
                    str2 = str2.Replace("\0", ".");
                    TableCell newItem1 = new TableCell();
                    newItem1.Text = str2;
                    newItem1.BackColor = cellBackColor;
                    newRow.Cells.Add(newItem1);
                }

                if (bAscii == false)
                    newRow.Cells[iColByChar + 1].Text = HttpUtility.HtmlEncode(StringToEbdcdict((string)newRow.Cells[iColByChar + 1].Text));
                else
                    newRow.Cells[iColByChar + 1].Text = HttpUtility.HtmlEncode(newRow.Cells[iColByChar + 1].Text.ToString());

                uWGrid.Rows.Add(newRow);
            }
        }

        static string StringToEbdcdict(string textMessage)
        {
            return textMessage;
        }
    }
}
