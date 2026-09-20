using Hotel_Buisness;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Global_Classes
{
    public class clsGlobal
    {
        public static clsUser CurrentUser;// المستخدم الدي قام بتسجيل الدخول
                                          //  يحفظ كلمة السر و اسم النستخدم باملف من اجل يرجع يستخدمهن
        public static string ApplicationFolder =>
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData), "Hotel_system");

        public static string SettingsFile =>
            Path.Combine(
                ApplicationFolder, "settings.txt");

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            try
            {
                if (Username == "" && File.Exists(SettingsFile))
                {
                    File.Delete(SettingsFile);
                    return true;

                }
                string dataToSave = Username + "#//#" + Password;

                using (StreamWriter writer = new StreamWriter(SettingsFile))
                {
                    writer.WriteLine(dataToSave);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }





        // يرجع بيانات الذي داخل الملف
        public static bool GetStoredCredential(ref string Username, ref string Password)
        {




            try
            {


                if (File.Exists(SettingsFile))
                {

                    using (StreamReader reader = new StreamReader(SettingsFile))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line); // Output each line of data to the console
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                            Password = result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }


    }
}
