using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;


namespace TestRpgGame
{
    internal class Excelitem // 엑셀에 있는 아이템 리스트 가져와서 - 각 아이템 클래스 리스트에 넣어주는 역할을 합니다.
    {
        WeaponItem item = new WeaponItem("-", "-", false, false, 0, 0, 0, 0);
        DefenseItem DpItem = new DefenseItem("", "", false, false, 0, 0, 0, "", 0);
        UseItem useItem = new UseItem("-", "-", false, 0, 0, 0, 0, 0);

        static Excel.Application excelApp = null;
        static Excel.Workbook workBook = null;
        static Excel.Worksheet workSheet = null;

        public Excelitem()
        {
        }

        public void start()
        {
            try
            {
                //string desktopPath = ".\\TextRpg-ItemList.xlsx";  // 파일 경로
                //string path = Path.Combine(desktopPath, "TextRpg-ItemList.xlsx");    // 엑셀 파일 저장 경로 , 엑셀 이름

                //string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);  // 바탕화면 경로
                //string path = Path.Combine(desktopPath, "Excel.xlsx");

                string filePath = Path.GetFullPath("./Item/") + "List3.xlsx";

                //Console.WriteLine(Path.GetFullPath("./Item/") + "List3.xlsx");
                Console.Write("\n         로딩 중 ");

                excelApp = new Excel.Application();                             // 엑셀 어플리케이션 생성
                workBook = excelApp.Workbooks.Open(filePath);                       // 워크북 열기
                for (int i = 1; i <= workBook.Worksheets.Count; i++)
                {
                    workSheet = workBook.Worksheets.get_Item(i) as Excel.Worksheet; // 엑셀 첫번째 워크시트 가져오기

                    //Excel.Range range = workSheet.UsedRange;    // 사용중인 셀 범위를 가져오기

                    switch (i)
                    {
                        case 1:
                            MakeSheet1Item(workSheet.UsedRange); //소모 아이템 제작
                            break;
                        case 2:
                            MakeSheet2Item(workSheet.UsedRange); //무기 아이템 제작
                            break;
                        case 3:
                            MakeSheet3Item(workSheet.UsedRange); //장비 아이템 제작
                            break;
                        default:
                            break;

                    }
                    
                }

                // DpItem.MakeItemScript();


                workBook.Close(true);   // 워크북 닫기
                excelApp.Quit();        // 엑셀 어플리케이션 종료
            }
            finally
            {
                ReleaseObject(workSheet);
                ReleaseObject(workBook);
                ReleaseObject(excelApp);


            }
        }
        // 무기 아이템 제작
        void MakeSheet2Item(Excel.Range range)
        {
            Console.Write(". ");
            //Console.WriteLine(range.Rows.Count);
            item.ArrSizeMake(range.Rows.Count);

            for (int row = 1; row <= 14; row++) // 가져온 행 만큼 반복
            {
                string Ename = (string)(range.Cells[row, 1] as Excel.Range).Value2;
                int Ead = (int)(range.Cells[row, 2] as Excel.Range).Value2;
                int Edp = (int)(range.Cells[row, 3] as Excel.Range).Value2;
                int Eprice = (int)(range.Cells[row, 4] as Excel.Range).Value2;
                string Edesc = (string)(range.Cells[row, 5] as Excel.Range).Value2;

                item.WpItemInShopList(Ename, Ead, Edp, Eprice, Edesc, row - 1);

                //Console.WriteLine($"무기 아이템 {row}개 완료");
            }
        }

        // 사용 아이템 제작
        void MakeSheet1Item(Excel.Range range)
        {
            Console.Write(". ");
            //Console.WriteLine(range.Rows.Count);
            useItem.ArrSizeMake(range.Rows.Count);

            for (int row = 1; row <= 4; row++) // 가져온 행 만큼 반복
            {
                string Ename = (string)(range.Cells[row, 1] as Excel.Range).Value2;
                int Ehp = (int)(range.Cells[row, 2] as Excel.Range).Value2;
                int Eip = (int)(range.Cells[row, 3] as Excel.Range).Value2;
                int Eprice = (int)(range.Cells[row, 4] as Excel.Range).Value2;
                string Edesc = (string)(range.Cells[row, 5] as Excel.Range).Value2;

                useItem.UseItemInShopList(Ename, Ehp, Eip, Eprice, Edesc, row - 1);

                //Console.WriteLine($"소모 아이템 {row}개 완료");
            }
        }

        // 방어구 아이템 제작
        void MakeSheet3Item(Excel.Range range)
        {
            Console.Write(". ");
            //Console.WriteLine(range.Rows.Count);
            int DebugRangecount = 21;
            DpItem.ArrSizeMake(DebugRangecount);

            for (int row = 1; row <= DebugRangecount; row++) // 가져온 행 만큼 반복 + 오류때문에 값 지정했음.
            {
                //Console.WriteLine(DebugRangecount);
                string Ename = (string)(range.Cells[row, 1] as Excel.Range).Value2;
                int Ead = (int)(range.Cells[row, 2] as Excel.Range).Value2;
                int Edp = (int)(range.Cells[row, 3] as Excel.Range).Value2;
                string Eset = (string)(range.Cells[row, 4] as Excel.Range).Value2;
                int Eprice = (int)(range.Cells[row, 5] as Excel.Range).Value2;
                string Edesc = (string)(range.Cells[row, 6] as Excel.Range).Value2;

                DpItem.DpItemInShopList(Ename, Ead, Edp, Eset, Eprice, Edesc, row - 1);

                //Console.WriteLine($"장비 아이템 {row}개 완료");
            }
        }

        

        /// <summary>
        /// 액셀 객체 해제 메소드
        /// </summary>
        /// <param name="obj"></param>
        static void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);  // 액셀 객체 해제
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();   // 가비지 수집
            }
        }
    }
}
