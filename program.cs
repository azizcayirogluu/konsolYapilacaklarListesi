using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<string> gorevler = new List<string>();
    static string dosyaYolu = "gorevler.txt";

    static void Main()
    {
        Console.Title = "ToDo List Uygulaması";

        DosyadanYukle();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== TO DO LIST ===");
            Console.WriteLine("1) Görevleri Listele");
            Console.WriteLine("2) Görev Ekle");
            Console.WriteLine("3) Görev Sil");
            Console.WriteLine("4) Kaydet");
            Console.WriteLine("5) Çıkış");
            Console.Write("Seçim: ");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1": Listele(); break;
                case "2": Ekle(); break;
                case "3": Sil(); break;
                case "4": Kaydet(); break;
                case "5": Kaydet(); return;
                default:
                    Console.WriteLine("Hatalı seçim!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void Listele()
    {
        Console.Clear();
        Console.WriteLine("--- Görev Listesi ---");

        if (gorevler.Count == 0)
        {
            Console.WriteLine("Henüz bir görev eklenmemiş.");
        }
        else
        {
            for (int i = 0; i < gorevler.Count; i++)
                Console.WriteLine($"{i + 1}) {gorevler[i]}");
        }

        Console.WriteLine("\nDevam etmek için bir tuşa bas...");
        Console.ReadKey();
    }

    static void Ekle()
    {
        Console.Clear();
        Console.Write("Yeni görev: ");
        string gorev = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(gorev))
        {
            gorevler.Add(gorev);
            Console.WriteLine("Görev eklendi!");
        }
        else
        {
            Console.WriteLine("Boş görev eklenemez!");
        }

        Console.ReadKey();
    }

    static void Sil()
    {
        Listele();
        Console.Write("\nSilmek istediğin görev numarası: ");

        if (int.TryParse(Console.ReadLine(), out int num))
        {
            if (num > 0 && num <= gorevler.Count)
            {
                gorevler.RemoveAt(num - 1);
                Console.WriteLine("Görev silindi!");
            }
            else
            {
                Console.WriteLine("Geçersiz görev numarası!");
            }
        }
        else
        {
            Console.WriteLine("Sayı gir!");
        }

        Console.ReadKey();
    }

    static void Kaydet()
    {
        File.WriteAllLines(dosyaYolu, gorevler);
        Console.WriteLine("Görevler kaydedildi!");
        System.Threading.Thread.Sleep(700);
    }

    static void DosyadanYukle()
    {
        if (File.Exists(dosyaYolu))
        {
            gorevler = new List<string>(File.ReadAllLines(dosyaYolu));
        }
    }
}
