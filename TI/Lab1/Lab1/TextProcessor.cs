namespace Lab1;

public class TextProcessor
{
    private static List<char> alphabet = new List<char>("абвгдеёжзийклмнопрстуфхцчшщъыьэюя");
    private static int  n = alphabet.Count;
    private static List<char> convertToList(string text)
    {
        List<char> textList = new List<char>();
        foreach (char c in text)
        {
            if ((c >= 'А' && c <= 'Я') || (c >= 'а' && c <= 'я') || c == 'Ё' || c == 'ё' )
            {
                textList.Add(c);
            }
        }
        return textList;
    }

    public static string DecimationEncryption(string text, int key)
    {
        //E = (i*k) mod n
        //n = 33
        List<char> textList = convertToList(text);
        List<char> resultList = new List<char>();
        
        for (int i = 0; i < textList.Count; i++)
        {
            if (textList[i] == ' ')
            {
                resultList.Add(textList[i]);
            }
            else
            {
                resultList.Add(alphabet[(alphabet.IndexOf(textList[i]) * key) % n]);
            }

        }
        return new string(resultList.ToArray());
    }

    public static string DecimationDecryption(string text, int key)
    {
        //D = (i + n)/k
        
        List<char> textList = convertToList(text);
        List<char> resultList = new List<char>();
        
        for (int i = 0; i < textList.Count; i++)
        {
            if (textList[i] == ' ')
            {
                resultList.Add(textList[i]);
            }
            else
            {
                int k = alphabet.IndexOf(textList[i]);
                int temmp = k / key;
                
                    while (k % key != 0)
                    {
                        k += n;
                    }
                

                resultList.Add(alphabet[k / key ]);
            }

        }
        return new string(resultList.ToArray());
    }
    

    public static string VizhinerEncryption(string text, string key)
    {
        List<char> textList = convertToList(text);
        List<char> keyList = convertToList(key);
        List<char> resultList = new List<char>();
        int keyIndex = 0;

        for (int i = 0; i < textList.Count; i++)
        {
            if (textList[i] == ' ')
            {
                resultList.Add(textList[i]);
            }
            else
            {
                int k;
                if (keyIndex < keyList.Count)
                {
                    k = alphabet.IndexOf(keyList[keyIndex]); 
                }
                else
                {
                    int temp_k = alphabet.IndexOf(textList[keyIndex - keyList.Count]);
                    if (temp_k == -1)
                    {
                        keyIndex++;
                    }
                    k = alphabet.IndexOf(textList[keyIndex - keyList.Count]);
                    
                }
                int m = alphabet.IndexOf(textList[i]);
                resultList.Add(alphabet[(k + m) % n]);
                keyIndex++;
                
            }
        }
        return new string(resultList.ToArray());
    }

    public static string VizhinerDecryption(string text, string key)
    {
        List<char> textList = convertToList(text);
        List<char> keyList = convertToList(key);
        List<char> resultList = new List<char>();
        int keyIndex = 0;

        for (int i = 0; i < textList.Count; i++)
        {
            if (textList[i] == ' ')
            {
                resultList.Add(textList[i]);
            }
            else
            {
                int k;
                if (keyIndex < keyList.Count)
                {
                    k = alphabet.IndexOf(keyList[keyIndex]); 
                }
                else
                {
                    k = alphabet.IndexOf(resultList[keyIndex - keyList.Count]);
                }
                int m = alphabet.IndexOf(textList[i]);
                resultList.Add(alphabet[(m - k + n) % n]);
                keyIndex++;
            }
        }
        return new string(resultList.ToArray());
        
    }

    
    
    
}