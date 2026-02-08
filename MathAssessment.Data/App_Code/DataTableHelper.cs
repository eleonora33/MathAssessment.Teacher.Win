using System;
using System.Collections.Generic;
using System.Data;

namespace MathAssessment.Data.App_Code  
{
    public static class DataTableHelper
    {
        
        public static DataTable CreateDataTable(Dictionary<string, Type> columnNameWithType)
        {
            if (columnNameWithType == null)
                throw new ArgumentNullException(nameof(columnNameWithType));

            DataTable resultTable = new DataTable();

            foreach (KeyValuePair<string, Type> columnDefinition in columnNameWithType)
            {
                string columnName = columnDefinition.Key;
                Type columnDataType = columnDefinition.Value;

                resultTable.Columns.Add(columnName, columnDataType);
            }

            return resultTable;
        }

        public static void AddRowToTable(DataTable targetTable, params object[] rowCellValues)
        {
            if (targetTable == null)
                throw new ArgumentNullException(nameof(targetTable));

            object[] preparedRowValues = new object[rowCellValues.Length];

            for (int valueIndex = 0; valueIndex < rowCellValues.Length; valueIndex++)
            {
                object currentValue = rowCellValues[valueIndex];

                preparedRowValues[valueIndex] =
                    currentValue == null
                        ? DBNull.Value
                        : currentValue;
            }

            targetTable.Rows.Add(preparedRowValues);
        }

        public static void ClearAllRows(
            DataTable targetTable)
        {
            if (targetTable == null)
                throw new ArgumentNullException(nameof(targetTable));

            targetTable.Rows.Clear();
        }
    }
}
