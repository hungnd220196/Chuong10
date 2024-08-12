using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Channels;

namespace Chuong10
{
    internal class Program
    {

        static void ProcessString(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
        }

        static void Main(string[] args)
        {
            byte[] a = new byte[5];
            // nhap mang
            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine("a{0}=", i + 1);
                    a[i] = Convert.ToByte(Console.ReadLine());

                }
            }
            catch (FormatException ex)
            {
                //Console.WriteLine(ex.Message);
                Console.WriteLine("khong nhap ki tu cho amng so");
            }
            catch (OverflowException ex)
            {

                Console.WriteLine("khong duoc nhap gia tri ngoai mien 0-255");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("loi vuot qua pham vi cua mang");
            }
            // in mang
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{a[i]}");
            }
            Console.WriteLine();

            //vd cau lenh throw
            try
            {
                string s = null;
                //if (s == null)

                //    {
                //    Console.WriteLine("test cau lenh throw");
                //    throw new ArgumentNullException();
                //}
                ProcessString(s);
            }
            catch (Exception)
            {

                Console.WriteLine("doi so khong duoc null");
            }

            // vi du tu khoa finally
            FileStream outStream = null;
            FileStream inStream = null;
            try
            {
                // mo file de ghi tai lieu
                outStream = File.OpenWrite("DestinationFIle.txt");
                // mo file de doc du lieu
                inStream = File.OpenRead("BogusInputFile.txt");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally 
            {
                if (outStream != null)
                {
                    outStream.Close();
                    Console.WriteLine("outStram closed");
                }
                if (inStream != null)
                {
                    inStream.Close();
                    Console.WriteLine("instream closed");
                }
            }


           /*
           1) Tại sao chúng ta không luôn luôn sử dụng câu lệnh catch không có tham số để bắt các lỗi?

           Sử dụng catch không có tham số sẽ bắt tất cả các loại ngoại lệ, nhưng điều này có thể không an toàn hoặc không hiệu quả vì bạn không biết loại ngoại lệ nào đã xảy ra và không thể xử lý chúng một cách cụ thể. 
           Việc bắt tất cả các ngoại lệ có thể dẫn đến việc che giấu các lỗi nghiêm trọng hoặc không dự đoán được, làm cho việc gỡ lỗi trở nên khó khăn.


           2) Tại sao tôi phải tìm hiểu nhiều về các ngoại lệ và cách thức xử lý các ngoại lệ khi chúng được phát sinh?

           Hiểu rõ về các loại ngoại lệ và cách xử lý chúng giúp bạn viết mã ổn định và an toàn hơn. Nó cho phép bạn:

           Xử lý các tình huống bất ngờ một cách hợp lý.
           Đưa ra thông báo lỗi hữu ích cho người dùng.
           Ngăn chặn ứng dụng bị sập đột ngột.
           Bảo vệ dữ liệu khỏi bị hỏng hóc.
           Cải thiện khả năng gỡ lỗi và bảo trì mã.


           3) Các từ khóa được sử dụng để xử lý ngoại lệ là gì?
           Các từ khóa chính trong C# dùng để xử lý ngoại lệ bao gồm:

           try: Khối lệnh nơi có thể xảy ra ngoại lệ.
           catch: Bắt giữ và xử lý ngoại lệ.
           finally: Khối lệnh sẽ luôn được thực hiện, bất kể ngoại lệ có xảy ra hay không.
           throw: Phát sinh một ngoại lệ.


           4) Phân biệt giữa lỗi và ngoại lệ?

           Lỗi (Error): Là những vấn đề nghiêm trọng, thường liên quan đến phần cứng hoặc hệ thống, mà chương trình không thể kiểm soát hoặc phục hồi, ví dụ như lỗi phần cứng hoặc lỗi bộ nhớ.

           Ngoại lệ (Exception): Là các vấn đề phát sinh trong quá trình thực thi mã mà có thể được kiểm soát hoặc xử lý, ví dụ như chia cho số 0, lỗi cú pháp, hoặc lỗi logic trong mã.


           5) Khi thực hiện việc bắt giữ các ngoại lệ nếu có nhiều mức bắt giữ ngoại lệ thì chúng ta sẽ thực hiện mức nào: từ chi tiết đến tổng quát, hay từ tổng quát đến chi tiết?

           Ta sẽ thực hiện việc bắt ngoại lệ từ chi tiết đến tổng quát. Điều này cho phép bạn xử lý các ngoại lệ cụ thể trước khi bắt giữ tất cả các ngoại lệ tổng quát hơn.


           6) Câu lệnh nào được dùng để phát sinh ngoại lệ?

           Câu lệnh throw được sử dụng để phát sinh ngoại lệ trong C#.


           7) Loại nào sau đây nên được xử lý theo ngoại lệ và loại nào thì nên được xử lý bởi các mã lệnh thông thường?

           a. Giá trị nhập vào của người dùng không nằm trong mức cho phép.
           → Xử lý bằng mã lệnh thông thường (validation trước khi thao tác).

           b. Tập tin không được viết mà thực hiện viết.
           → Xử lý bằng ngoại lệ (vì đó là một lỗi không mong đợi trong quá trình thao tác file).

           c. Đối số truyền vào cho phương thức chứa giá trị không hợp lệ.
           → Xử lý bằng ngoại lệ (throw ArgumentException nếu cần thiết).

           d. Đối số truyền vào cho phương thức chứa kiểu không hợp lệ.
           → Xử lý bằng ngoại lệ (throw InvalidCastException nếu cần thiết).


           8) Nguyên nhân nào dẫn đến phát sinh ngoại lệ?
           Ngoại lệ có thể phát sinh do nhiều nguyên nhân, bao gồm:

           Lỗi logic trong mã.
           Tương tác với phần cứng hoặc hệ điều hành không thành công.
           Dữ liệu nhập vào không hợp lệ.
           Các điều kiện không mong đợi trong quá trình thực thi chương trình (ví dụ: chia cho 0).


           9) Khi nào thì ngoại lệ xuất hiện?

           c. Trong khi thực thi chương trình.
           Ngoại lệ thường xuất hiện trong quá trình thực thi chương trình khi gặp phải tình huống không mong muốn.


           10) Khi nào thì khối lệnh trong finally được thực hiện?

           Khối lệnh trong finally sẽ luôn được thực hiện sau khối try và catch, bất kể ngoại lệ có xảy ra hay không. Nó được dùng để dọn dẹp tài nguyên, đóng kết nối, hoặc thực hiện các tác vụ cần thiết khác sau khi hoàn thành khối try/catch.


           11) Trong namespace nào chứa các lớp liên quan đến việc xử lý các ngoại lệ? Hãy cho biết một số lớp xử lý ngoại lệ quan trọng trong namespace này?

           Namespace System chứa các lớp liên quan đến việc xử lý ngoại lệ trong C#. Một số lớp quan trọng bao gồm:

           System.Exception: Lớp cơ bản cho tất cả các ngoại lệ.
           System.ArgumentException: Ngoại lệ khi đối số không hợp lệ.
           System.InvalidOperationException: Ngoại lệ khi hoạt động không hợp lệ.
           System.NullReferenceException: Ngoại lệ khi truy cập đối tượng rỗng.
            */


            //12.
            int Sothu1=1, Sothu2=0,Ketqua;

            try
            {
               Ketqua = Sothu1 / Sothu2;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Lỗi: Không thể chia cho 0.");
            }

            //13

            string fname = "test3.txt";
            string buffer;

            try
            {
                StreamReader sReader = File.OpenText(fname);
                while ((buffer = sReader.ReadLine()) != null)
                {
                    Console.WriteLine(buffer);
                }
                sReader.Close(); 
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Lỗi: Không tìm thấy tệp '{0}'.", fname);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Lỗi: Không có quyền truy cập tệp '{0}'.", fname);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Lỗi I/O: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi không xác định: {0}", ex.Message);
            }

        }

    }
}
