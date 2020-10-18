using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;

using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace Domain
{
    public enum TypeData
    {
        Email = 0,
        Document = 1,
        Name = 3,
        Phone = 4
    }



   

    public static partial class ObjectCustomer
    {


        public static DateTime ConvertUnixToTime(this long unix)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = start.AddMilliseconds(unix).ToLocalTime();
            return date;
        }

        public static DateTime ConvertUnixToTime(this long? unix)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = start.AddMilliseconds((long)unix).ToLocalTime();
            return date;
        }

        public static long ConvertTimeToUnix(this DateTime dateTime)
        {
            return (long)(dateTime.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
        }


        public static string RandomString(this Random random, int length = 12)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public static string String<T>(this T entity)
        {
            return JsonConvert.SerializeObject(entity);
        }



        public static IDictionary<string, object> ToDictionary(this JObject @object)
        {
            var result = @object.ToObject<Dictionary<string, object>>();

            var JObjectKeys = (from r in result
                               let key = r.Key
                               let value = r.Value
                               where value.GetType() == typeof(JObject)
                               select key).ToList();

            var JArrayKeys = (from r in result
                              let key = r.Key
                              let value = r.Value
                              where value.GetType() == typeof(JArray)
                              select key).ToList();

            JArrayKeys.ForEach(key => result[key] = ((JArray)result[key]).Values().Select(x => ((JValue)x).Value).ToArray());
            JObjectKeys.ForEach(key => result[key] = ToDictionary(result[key] as JObject));

            return result;
        }


        

        public static string RemoveAccentsWithRegEx(this string inputString)
        {
            Regex replace_a_Accents = new Regex("[á|à|ä|â]", RegexOptions.Compiled);
            Regex replace_e_Accents = new Regex("[é|è|ë|ê]", RegexOptions.Compiled);
            Regex replace_i_Accents = new Regex("[í|ì|ï|î]", RegexOptions.Compiled);
            Regex replace_o_Accents = new Regex("[ó|ò|ö|ô]", RegexOptions.Compiled);
            Regex replace_u_Accents = new Regex("[ú|ù|ü|û]", RegexOptions.Compiled);
            inputString = replace_a_Accents.Replace(inputString, "a");
            inputString = replace_e_Accents.Replace(inputString, "e");
            inputString = replace_i_Accents.Replace(inputString, "i");
            inputString = replace_o_Accents.Replace(inputString, "o");
            inputString = replace_u_Accents.Replace(inputString, "u");
            return inputString;
        }

        public static string NameEnum<T>(this T value)
        {
            if (value.GetType().IsEnum)
            {
                return Enum.GetName(typeof(T), value);
            }
            return "";
        }

        public static string StringToHex(this string str)
        {
            byte[] ba = Encoding.Default.GetBytes(str.ToString().ToLower());
            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");
            return hexString.ToLower();
        }

        public static string HexToString<T>(this string str)
        {
            byte[] data = FromHex(str.ToString().ToLower());
            string s = Encoding.ASCII.GetString(data);
            return s.ToLower();
        }

        public static byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }


        public static TypeData IsData<T>(this T data)
        {
            if (data.IsValidEmail())
            {
                return TypeData.Email;
            }
            else if (data.IsDocument())
            {
                return TypeData.Document;
            }
            else if (data.IsPhone())
            {
                return TypeData.Phone;
            }
            else
            {
                return TypeData.Name;
            }

        }


      
        public static bool IsDocument<T>(this T doc)
        {
            try
            {
                return int.TryParse(doc.ToString(), out int i) && i.ToString().Length == 8 || i.ToString().Length == 10;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }



        public static bool IsPhone<T>(this T value)
        {
            return value.ToString().All(char.IsNumber) && value.ToString().Length > 5 && value.ToString().Length <13;
        }

        public static bool IsValidEmail<T>(this T mail)
        {
            string email = mail.ToString();
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                static string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            try
            {

                bool isValidEmail = Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                return isValidEmail;
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }


        public static bool IsBase64<T>(this T str)
        {
            try
            {

                if (string.IsNullOrEmpty(str.ToString()) || str.ToString().Length % 4 != 0 ||
                    str.ToString().Contains(" ") || str.ToString().Contains("\t") || str.ToString().Contains("\r") || str.ToString().Contains("\n"))
                {
                    return false;
                }
                Convert.FromBase64String(str.ToString());
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }


        

    }
}
