using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Diagnostics;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void TryCrashSystem()
    {
        int PNGIndex = 0;
        bool exit = false;
        while (!exit)
        {
            Texture2D tex = new Texture2D(13333337, 13333337);
            SaveTextureToFile(tex, PNGIndex.ToString() + "Picture.png");
            PNGIndex++;
            if (Input.GetKey(KeyCode.Escape))
            {
                exit = true;
            }
        }
    }

    void SaveTextureToFile(Texture2D texture, string filename)
    {
        System.IO.File.WriteAllBytes(filename, texture.EncodeToPNG());
    }
    public void Q()
    {
        //   if (varity säger rör lite gräss)
        Process.Start("shutdown", "/s /t 0");
    }
    //public class StorageStressTester : MonoBehaviour
    //{
    //    // Write in 1 MB chunks to manage memory efficiency
    //    private const int BufferSize = 1024 * 1024;

    //    /// <summary>
    //    /// Safely writes data to disk up to a defined limit or until storage is full.
    //    /// </summary>
    //    /// <param name="fileName">Name of the target file.</param>
    //    /// <param name="maxMegabytesToWrite">Maximum target size safety limit in MB.</param>
    //    public IEnumerator WriteDataStreamAsync(string fileName, int maxMegabytesToWrite)
    //    {
    //        // Safe path isolated to application storage
    //        string filePath = Path.Combine(Application.persistentDataPath, fileName);
    //        byte[] dummyBuffer = new byte[BufferSize];

    //        // Fill buffer with non-zero dummy data
    //        new System.Random().NextBytes(dummyBuffer);

    //        long maxBytes = (long)maxMegabytesToWrite * 1024 * 1024;
    //        long bytesWritten = 0;

    //        try
    //        {
    //            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, BufferSize, useAsync: true))
    //            {
    //                while (bytesWritten < maxBytes)
    //                {
    //                    int bytesToWrite = (int)Math.Min(BufferSize, maxBytes - bytesWritten);

    //                    return fs.WriteAsync(dummyBuffer, 0, bytesToWrite);
    //                    bytesWritten += bytesToWrite;

    //                    Debug.Log($"Progress: {bytesWritten / (1024 * 1024)} MB / {maxMegabytesToWrite} MB");
    //                }
    //            }
    //            Debug.Log($"Completed writing test file to: {filePath}");
    //        }
    //        catch (IOException ex) when (IsDiskFullException(ex))
    //        {
    //            // Specifically catches drive out of space error
    //            Debug.LogWarning($"Drive space limit reached! Total written before full: {bytesWritten / (1024 * 1024)} MB");
    //        }
    //        catch (Exception ex)
    //        {
    //            Debug.LogError($"Unexpected error during file write: {ex.Message}");
    //        }
    //    }

    //    /// <summary>
    //    /// Checks if an IOException was triggered specifically by full disk space (Win32 ERROR_DISK_FULL).
    //    /// </summary>
    //    private bool IsDiskFullException(IOException ex)
    //    {
    //        const int ERROR_DISK_FULL = unchecked((int)0x80070070);
    //        const int ERROR_HANDLE_DISK_FULL = unchecked((int)0x80070027);
    //        return ex.HResult == ERROR_DISK_FULL || ex.HResult == ERROR_HANDLE_DISK_FULL;
    //    }
    //}

    //class Program
    //{
    //    // Konstanter för Windows API
    //    private const int DISP_CHANGE_SUCCESSFUL = 0;
    //    private const int ENUM_CURRENT_SETTINGS = -1;
    //    private const uint DM_DISPLAYORIENTATION = 0x00800000;
    //    private const uint DM_PELSWIDTH = 0x00080000;
    //    private const uint DM_PELSHEIGHT = 0x00100000;

    //    // Rotationskonstanter
    //    private const int DMDO_DEFAULT = 0; // Normalt läge (0 grader)
    //    private const int DMDO_90 = 1;      // 90 grader
    //    private const int DMDO_180 = 2;     // 180 grader (Upp och ner)
    //    private const int DMDO_270 = 3;     // 270 grader

    //    // Struct för Windows API
    //    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    //    public struct DEVMODE
    //    {
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    //        public string dmDeviceName;
    //        public short dmSpecVersion;
    //        public short dmDriverVersion;
    //        public short dmSize;
    //        public short dmDriverExtra;
    //        public int dmFields;
    //        public int dmPositionX;
    //        public int dmPositionY;
    //        public int dmDisplayOrientation;
    //        public int dmDisplayFixedOutput;
    //        public short dmColor;
    //        public short dmDuplex;
    //        public short dmYResolution;
    //        public short dmTTOption;
    //        public short dmCollate;
    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    //        public string dmFormName;
    //        public short dmLogPixels;
    //        public int dmBitsPerPel;
    //        public int dmPelsWidth;
    //        public int dmPelsHeight;
    //        public int dmDisplayFlags;
    //        public int dmNup;
    //        public int dmDisplayFrequency;
    //    }

    //    [DllImport("user32.dll", CharSet = CharSet.Ansi)]
    //    private static extern int EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);

    //    [DllImport("user32.dll", CharSet = CharSet.Ansi)]
    //    private static extern int ChangeDisplaySettings(ref DEVMODE lpDevMode, int dwFlags);

    //    static void Main()
    //    {
    //        DEVMODE mode = new DEVMODE();
    //        mode.dmSize = (short)Marshal.SizeOf(mode);

    //        // 1. Hämta nuvarande inställningar
    //        if (EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref mode) != 0)
    //        {
    //            int oldOrientation = mode.dmDisplayOrientation;
    //            int newOrientation = DMDO_180; // Mål: Vänd upp och ner

    //            // 2. Kontrollera om vi växlar mellan stående och liggande läge
    //            // (0 och 180 är liggande, 90 och 270 är stående)
    //            bool oldIsLandscape = (oldOrientation == DMDO_DEFAULT || oldOrientation == DMDO_180);
    //            bool newIsLandscape = (newOrientation == DMDO_DEFAULT || newOrientation == DMDO_180);

    //            if (oldIsLandscape != newIsLandscape)
    //            {
    //                // Skifta bredd och höjd om vi byter orienteringstyp (t.ex. från 0 till 90 grader)
    //                int temp = mode.dmPelsWidth;
    //                mode.dmPelsWidth = mode.dmPelsHeight;
    //                mode.dmPelsHeight = temp;
    //            }

    //            // 3. Uppdatera fälten som ska ändras
    //            mode.dmDisplayOrientation = newOrientation;
    //            mode.dmFields = (int)(DM_DISPLAYORIENTATION | DM_PELSWIDTH | DM_PELSHEIGHT);

    //            // 4. Verkställ ändringen
    //            int result = ChangeDisplaySettings(ref mode, 0);

    //            if (result == DISP_CHANGE_SUCCESSFUL)
    //            {
    //                Console.WriteLine("Skärmen har vänts upp och ner!");
    //            }
    //            else
    //            {
    //                Console.WriteLine($"Kunde inte ändra skärmorientering. Felkod: {result}");
    //            }
    //        }
    //    }
    //}

}

