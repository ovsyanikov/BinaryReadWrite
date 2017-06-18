using System;
using System.IO;
using System.Text;

namespace BinaryReadWrite
{

    class Book {

        public string BookTitle { get; set; }
        public int BookPages { get; set; }
        public double BookPrice { get; set; }

        public string BookAuthor { get; set; }

        public override string ToString()
        {
            return $"Название: {BookTitle}\nАвтор: {BookAuthor}\nСтраницы: {BookPages}\nЦена: {BookPrice}\n\n";
        }

        public void WriteBinary( BinaryWriter bw ) {

            bw.Write(BookTitle);
            bw.Write(BookAuthor);
            bw.Write(BookPages);
            bw.Write(BookPrice);

        }//WriteBinary

        public void ReadBook(BinaryReader br) {
            //byte[] bytesArray = new byte[2048];

            //br.Read(bytesArray, 0, 2048);

            BookTitle = br.ReadString();
            BookAuthor = br.ReadString();
            BookPages = br.ReadInt32();
            BookPrice = br.ReadDouble();

        }

    }

    class Program
    {
        static void Main(string[] args){

            //Бинарная запись
            //FileStream source = new FileStream("digits.bin", FileMode.OpenOrCreate);
            //BinaryWriter bw = new BinaryWriter(source,Encoding.Default);

            //bw.Write(15);
            //bw.Write("тестовая строка\n");
            //bw.Write(3.14);

            //bw.Close();
            //source.Close();

            //Бинарное чтение

            //FileStream fs = new FileStream("digits.bin", FileMode.Open);
            //BinaryReader br = new BinaryReader(fs,Encoding.Default);

            //int digit = br.ReadInt32();
            //string myStr = br.ReadString();
            //double doubleDigit = br.ReadDouble();

            //fs.Close();
            //br.Close();

            //Console.WriteLine($"Целое: {digit}\nСтрока: {myStr}\nВещ. число: {doubleDigit}\n");

            Book classic = new Book() {

                BookAuthor = "Достаевский",
                BookTitle = "Преступление и наказание",
                BookPages = 250,
                BookPrice = 1920.55

            };

            FileStream bookStream = new FileStream("book.bin", FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(bookStream, Encoding.Default);

            classic.WriteBinary(bw);

            Console.WriteLine("Hello!");

            bookStream.Close();
            bw.Close();

            Console.WriteLine($"Книга в исходном виде:{classic}");

            bookStream = new FileStream("book.bin", FileMode.Open);
            BinaryReader br = new BinaryReader(bookStream, Encoding.Default);

            Book bookToRead = new Book();

            bookToRead.ReadBook(br);

            Console.WriteLine($"Книга после бинарного чтения:{bookToRead}");

            bookStream.Close();
            br.Close();

        }

    }
}
