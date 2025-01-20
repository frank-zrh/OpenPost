using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenPostLib.Environment
{
    public static class EnvTool
    {
        //get folder for current executable
        public static string GetExeFolder()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        //the profile name is default.json saved in the exe folder
        public static string GetDefaultProfilePath()
        {
            return System.IO.Path.Combine(GetExeFolder(), "default.json");
        }

        //get history folder from exe folder, if not exist, create it
        public static string GetHistoryFolder()
        {
            var historyFolder = System.IO.Path.Combine(GetExeFolder(), "history");
            if (!System.IO.Directory.Exists(historyFolder))
            {
                System.IO.Directory.CreateDirectory(historyFolder);
            }
            return historyFolder;
        }

        //get or create a sub folder under history folder with ID of request in GUID format
        public static string GetRequestFolder(Guid requestId)
        {
            var requestFolder = System.IO.Path.Combine(GetHistoryFolder(), requestId.ToString());
            if (!System.IO.Directory.Exists(requestFolder))
            {
                System.IO.Directory.CreateDirectory(requestFolder);
            }
            return requestFolder;
        }

        //list all the files in the request folder and convert the file name from date time value "yyyyMMddHHmmss" to DateTime and sort them with newest first
        public static List<DateTime> GetRequestHistory(Guid requestId)
        {
            var requestFolder = GetRequestFolder(requestId);
            var files = System.IO.Directory.GetFiles(requestFolder);
            var history = new List<DateTime>();
            foreach (var file in files)
            {
                var fileName = System.IO.Path.GetFileNameWithoutExtension(file);
                if (DateTime.TryParseExact(fileName, "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out var dt))
                {
                    history.Add(dt);
                }
            }
            history.Sort();
            history.Reverse();
            return history;
        }

        //add a new file in the request folder with date time value "yyyyMMddHHmmss" as file name
        public static string SaveRequestHistory(Guid requestId, object content)
        {
            var requestFolder = GetRequestFolder(requestId);
            var fileName = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            var filePath = System.IO.Path.Combine(requestFolder, fileName + ".json");
            var jsonString = JsonSerializer.Serialize(content, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(filePath, jsonString);
            return filePath;
        }

        //get Request content from a file in the request folder
        public static T LoadRequestHistory<T>(Guid requestId, DateTime dt)
        {
            var requestFolder = GetRequestFolder(requestId);
            var fileName = dt.ToString("yyyyMMddHHmmss");
            if(!System.IO.File.Exists(System.IO.Path.Combine(requestFolder, fileName + ".json")))
            {
                return default(T);
            }
            var filePath = System.IO.Path.Combine(requestFolder, fileName + ".json");
            var jsonString = System.IO.File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        public static string ToHex(byte[] data)
        {
            var hex = new System.Text.StringBuilder();
            int i = 0;
            while (i < data.Length)
            {
                hex.AppendFormat("{0:X8}  ", i);
                int lineLength = 32;
                bool isUnicodeContinuation = false;

                for (int j = 0; j < lineLength; j++)
                {
                    if (i + j < data.Length)
                    {
                        hex.AppendFormat("{0:X2} ", data[i + j]);
                        if (j == 31 && (data[i + j] & 0x80) != 0)
                        {
                            isUnicodeContinuation = true;
                            lineLength++;
                        }
                    }
                    else
                    {
                        hex.Append("   ");
                    }
                    if (j == 15)
                    {
                        hex.Append(" ");
                    }
                }

                hex.Append(" ");
                for (int j = 0; j < lineLength && i + j < data.Length; j++)
                {
                    if (data[i + j] >= 32 && data[i + j] <= 126)
                    {
                        hex.Append((char)data[i + j]);
                    }
                    else
                    {
                        try
                        {
                            // Try to decode as UTF-8
                            int charLength = 1;
                            if ((data[i + j] & 0xE0) == 0xC0) charLength = 2;
                            else if ((data[i + j] & 0xF0) == 0xE0) charLength = 3;
                            else if ((data[i + j] & 0xF8) == 0xF0) charLength = 4;

                            if (i + j + charLength <= data.Length)
                            {
                                var charBytes = new byte[charLength];
                                Array.Copy(data, i + j, charBytes, 0, charLength);
                                hex.Append(System.Text.Encoding.UTF8.GetString(charBytes));
                                j += charLength - 1;
                            }
                            else
                            {
                                hex.Append('.');
                            }
                        }
                        catch
                        {
                            hex.Append('.');
                        }
                    }
                }
                hex.AppendLine();

                i += lineLength;
            }
            return hex.ToString();
        }

        //display text content to hex format string and each row has 32 bytes
        public static string ToHex(string text)
        {
            return ToHex(System.Text.Encoding.UTF8.GetBytes(text));
        }

    }
}