using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for clsDatabase
/// </summary>
public class clsDatabase
{
    public static void createDSN()
    {
        try
        {
            if (!Directory.Exists(@"C:\Adode"))
            {
                Directory.CreateDirectory(@"C:\Adode");
            }

            string path = @"C:\Adode\odbc.dsn";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            // Delete the file if it exists.
            if (!File.Exists(path))
            {
                // Create the file.
                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes
                        ("[ODBC]"
                        + System.Environment.NewLine + "DRIVER=" + "MySQL ODBC 3.51 Driver"
                        + System.Environment.NewLine + "UID=" + "root"
                        + System.Environment.NewLine + "SERVER=" + "LOCALHOST"
                        + System.Environment.NewLine + "PORT=" + "3309"
                        + System.Environment.NewLine + "OPTION=3"
                        + System.Environment.NewLine + "DATABASE=" + "datachip"
                        + System.Environment.NewLine + "PWD=" + "p@$$word"
                        );
                    fs.Write(info, 0, info.Length);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void deleteDSN()
    {
        try
        {
            string path = @"C:\Adode\odbc.dsn";
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            if (Directory.Exists(@"C:\Adode"))
            {
                Directory.Delete(@"C:\Adode");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}