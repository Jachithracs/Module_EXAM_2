using ContactListTesting.Utilities;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasekaroModel.Utilities
{
    internal class ExcelUtils
    {
        public static List<ExcelData> ReadExcelDataCreateAccount(string excelFilePath, string sheetName)
        {
            List<ExcelData> excelDataList = new List<ExcelData>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });

                    var dataTable = result.Tables[sheetName];

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            ExcelData excelData = new ExcelData
                            {
                                FirstName = GetValueOrDefault(row, "firstname"),
                                LastName = GetValueOrDefault(row, "lastname"),
                                Email = GetValueOrDefault(row, "email"),
                                Password = GetValueOrDefault(row, "password")
                            };

                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }
                }
            }

            return excelDataList;
        }
        public static List<ExcelDataAddContact> ReadExcelDataAddContact(string excelFilePath, string sheetName)
        {
            List<ExcelDataAddContact> excelDataList = new List<ExcelDataAddContact>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });

                    var dataTable = result.Tables[sheetName];

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            ExcelDataAddContact excelData = new ExcelDataAddContact
                            {
                                FirstName = GetValueOrDefault(row, "firstname"),
                                LastName = GetValueOrDefault(row, "lastname"),
                                DateofBirth = GetValueOrDefault(row, "dateofbirth"),
                                Email = GetValueOrDefault(row, "email"),
                                Phone = GetValueOrDefault(row, "phone"),
                                Address1 = GetValueOrDefault(row, "address1"),
                                Address2 = GetValueOrDefault(row, "address2"),
                                City = GetValueOrDefault(row, "city"),
                                State = GetValueOrDefault(row, "state"),
                                PostalCode = GetValueOrDefault(row, "postalcode"),
                                Country = GetValueOrDefault(row, "country")

                            };

                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }
                }
            }

            return excelDataList;
        }
        
        static string GetValueOrDefault(DataRow row, string columnName)
        {
            Console.WriteLine(row + "  " + columnName);
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }
    }
}
